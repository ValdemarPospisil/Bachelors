using GoodAccess.Shared;
using CLIService.GoodAccess.Main;
using System.Text.Json;
using GoodAccess.Shared.Auth.Service;
using CLIService.GoodAccess.Gateways.Service;
using CLIService.GoodAccess.UserProfile.Service;
using CLIService.GoodAccess.Vpn.Service;
using GoodAccess.Shared.Proto.Domain;
using GoodAccess.Shared.Proto.Service;
using GoodAccess.Shared.Main;

namespace CLIService.GoodAccess
{
    public class CliMessenger
    {
        private readonly Logger _logger;
        private readonly SenderReader _senderReader;
        private readonly AuthService _authService;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly GatewayService _gatewayService;
        private readonly UserProfileService _userProfileService;
        private readonly StatusService _statusService;
        private readonly VpnService _vpnService;
        private readonly InternetConnection _internetConnection;

        private CancellationTokenSource? _persistentToken;

        public CliMessenger(
            Logger logger,
            SenderReader senderReader,
            AuthService authService,
            GatewayService gatewayService,
            UserProfileService userProfileService,
            StatusService statusService,
            VpnService vpnService,
            InternetConnection internetConnection)
        {
            _logger = logger;
            _senderReader = senderReader;
            _authService = authService;
            _gatewayService = gatewayService;
            _userProfileService = userProfileService;
            _statusService = statusService;
            _vpnService = vpnService;
            _internetConnection = internetConnection;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task Start(CancellationToken stoppingToken)
        {
            bool pipeCreated = _senderReader.CreatePipe();

            if (!pipeCreated)
            {
                _logger.Info("Failed to create SenderReader pipe.");
                return;
            }

            if (pipeCreated)
            {
                PersistentConnection();
            }

          while (!stoppingToken.IsCancellationRequested)
          {
              try
              {
                  _logger.Info("Waiting for CLI client...");
             
                  await _senderReader.WaitForConnectionAsync(stoppingToken);
            
                  await ProcessMessages(stoppingToken);
              }
              catch (OperationCanceledException)
              {
                  break;
              }
              catch (IOException ex)
              {
                  _logger.Info($"[PipeError] Pipe is broken (Client killed?): {ex.Message}. Restarting listener...");
                  _senderReader.ReinitializePipe();
              }
              catch (ObjectDisposedException)
              {
                  _logger.Info("[PipeError] Pipe was disposed. Reinitializing...");
                  _senderReader.ReinitializePipe();
              }
              catch (Exception ex)
              {
                  _logger.Error(ex);
                  _senderReader.ReinitializePipe();
              }
              finally
              {
                  _senderReader.Disconnect();
              }
          }

            _senderReader.Stop();
        }

        public void Stop()
        {
            _persistentToken?.Cancel();
            _senderReader.Stop();
        }

        private void PersistentConnection()
        {
            var (persistentEnabled, ownerUid) = _userProfileService.GetGlobalConfig();

            if (persistentEnabled && !string.IsNullOrEmpty(ownerUid) && _vpnService.HasSavedConnection())
            {
                _persistentToken = new CancellationTokenSource();

                Task.Run(async () =>
                {
                    try
                    {
                        await _internetConnection.WaitUntilInternetIsAvailable();
                        if (_persistentToken.Token.IsCancellationRequested) return;

                        _logger.Info($"[Persistent] Restoring connection for owner: {ownerUid}");

                        _userProfileService.SetCurrentLinuxId(ownerUid);

                        if (_authService.IsUserLoggedIn(ownerUid))
                        {
                            _vpnService.TriggerPersistentConnect();
                        }
                        else
                        {
                            _logger.Info("[Persistent] Cannot connect. User credentials not found or expired.");
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e);
                    }
                }, _persistentToken.Token);
            }
            else
            {
                _logger.Info($"[Persistent] Skipped. Enabled={persistentEnabled}, HasData={_vpnService.HasSavedConnection()}, Owner={ownerUid}");
            }
        }

        private async Task ProcessMessages(CancellationToken token)
        {
            while (!token.IsCancellationRequested && _senderReader.IsConnected)
            {
                string? rawMessage = await _senderReader.ReadMessageAsync();
                if (rawMessage == null) break;

                string response = await HandleCommand(rawMessage);
                await _senderReader.SendMessageAsync(response);
            }
        }

        private string _lastContextLinuxId = "";

        private async Task<string> HandleCommand(string rawJson)
        {
            var responseWrapper = new ResponseEnvelope { Success = false, Data = null, Error = "" };

            try
            {
                var request = JsonSerializer.Deserialize<IpcRequest>(rawJson, _jsonOptions);
                string command = request?.Command ?? "";
                JsonElement payload = request?.Payload ?? new JsonElement();
                JsonElement context = request?.Context ?? new JsonElement();
                _logger.Info(payload.ToString());
                _logger.Info(context.ToString());

                string linuxId = GetStringProperty(context, "uid");
                if (string.IsNullOrEmpty(linuxId)) linuxId = GetStringProperty(context, "LinuxId");
                bool isRoot = GetBooleanProperty(context, "IsRoot");

                _logger.Info($"Command received: {command}, LinuxId: {linuxId}");
                if (!string.IsNullOrEmpty(linuxId))
                {
                    _userProfileService.SetCurrentLinuxId(linuxId);

                    if (_lastContextLinuxId != linuxId)
                    {
                        _logger.Info($"[ContextSwitch] Switching context from '{_lastContextLinuxId}' to '{linuxId}'");
                    
                        _authService.ReloadSession();
                    
                        _lastContextLinuxId = linuxId;
                    }
                }

                switch (command.ToLower())
                {

                    case "login":
                        await HandleLogin(payload, linuxId, responseWrapper);
                        break;

                    case "logout":
                        await HandleLogout(linuxId, responseWrapper);
                        break;

                    case "check_state":
                        await HandleCheckState(linuxId, responseWrapper);
                        break;

                    case "status":
                        await HandleStatus(linuxId, responseWrapper);
                        break;

                    case "connect":
                        await HandleConnect(payload, linuxId, responseWrapper);
                        break;

                    case "disconnect":
                        await HandleDisconnect(linuxId, isRoot, responseWrapper);
                        break;

                    case "get_gateways":
                        responseWrapper.Success = true;
                        var result = await _gatewayService.GetGateways();
                        responseWrapper.Data = result;
                        break;

                    case "save_config":
                        await HandleSaveConfig(payload, linuxId, responseWrapper);
                        break;

                    default:
                        responseWrapper.Success = false;
                        responseWrapper.Error = $"Unknown command: {command}";
                        break;
                }
            }
            catch (JsonException ex)
            {
                _logger.Error(ex);
                responseWrapper.Success = false;
                responseWrapper.Error = "JSON Parsing Error: " + ex.Message;
            }
            catch (NetworkException ex)
            {
                _logger.Error(ex);
                responseWrapper.Success = false;
                responseWrapper.Error = "no_internet_connection";
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                responseWrapper.Success = false;
                responseWrapper.Error = ex.Message;
            }

            return JsonSerializer.Serialize(responseWrapper, _jsonOptions);
        }

        // --- Command Handlers ---

        private async Task HandleLogin(JsonElement payload, string linuxId, ResponseEnvelope response)
        {
            if (!EnsureUserNotLoggedIn(linuxId, response)) return;

            string teamName = GetStringProperty(payload, "TeamName");
            string userName = GetStringProperty(payload, "UserName");
            string password = GetStringProperty(payload, "Password");

            if (string.IsNullOrEmpty(teamName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                response.Success = false;
                response.Error = "missing_credentials";
                return;
            }

            try
            {
                _logger.Info("Calling API Login...");

                bool success = await _authService.Login(teamName, userName, password, linuxId);

                if (success)
                {
                    _userProfileService.SaveLoginUsername(userName, linuxId);

                    response.Success = true;
                    response.Data = new { Message = "Login successful" };
                }
                else
                {
                    response.Success = false;
                    response.Error = "Login failed";
                }
            }
            catch (InvalidCredentialsException)
            {
                response.Success = false;
                response.Error = "invalid_credentials";
            }
        }

        private async Task HandleLogout(string linuxId, ResponseEnvelope response)
        {
            try
            {
                if (!EnsureUserLoggedIn(linuxId, response)) return;
                if (!EnsureNotConnectedByOtherUser(linuxId, response)) return;

                _authService.ClearLoginData();
                response.Success = true;
                response.Data = "Logged out successfully";
            }
            finally { }
        }

        private async Task HandleCheckState(string linuxId, ResponseEnvelope response)
        {
            bool isLoggedIn = _authService.IsUserLoggedIn(linuxId);
            bool isConnected = _vpnService.IsConnected();

            var (persistentEnabled, ownerUid) = _userProfileService.GetGlobalConfig();
            bool isAnotherUserConnected = isConnected && persistentEnabled && !string.IsNullOrEmpty(ownerUid) && ownerUid != linuxId;
            string userName = "";
            if (isLoggedIn)
            {
                var profile = _userProfileService.GetUserProfile(linuxId);
                userName = profile?.UserName ?? "";
            }

            _logger.Info($"[CheckState] LinuxId={linuxId}, LoggedIn={isLoggedIn}, Connected={isConnected}, Persistent={persistentEnabled}, Owner={ownerUid}, AnotherUser={isAnotherUserConnected}");

            response.Success = true;
            response.Data = new
            {
                IsLoggedIn = isLoggedIn,
                IsConnected = isConnected,
                UserName = userName,
                IsAnotherUserConnected = isAnotherUserConnected
            };
            await Task.CompletedTask;
        }

        private async Task HandleStatus(string linuxId, ResponseEnvelope response)
        {
            try
            {
                if (!EnsureNotConnectedByOtherUser(linuxId, response)) return;

                var status = await _statusService.GetAggregatedStatus(linuxId);
                response.Success = true;
                response.Data = status;
            }
            finally { }
        }

        private async Task HandleSaveConfig(JsonElement payload, string linuxId, ResponseEnvelope response)
        {
            try
            {
                string gatewayId = GetStringProperty(payload, "GatewayId");
                string gatewayName = GetStringProperty(payload, "GatewayName");
                string gatewayIp = GetStringProperty(payload, "GatewayIp");
                string countryCode = GetStringProperty(payload, "GatewayCountryCode");
                string protocol = GetStringProperty(payload, "Protocol");
                bool persistent = GetBooleanProperty(payload, "Persistent");

                if (string.IsNullOrEmpty(gatewayId) || string.IsNullOrEmpty(protocol))
                {
                    response.Success = false;
                    response.Error = "Missing GatewayId or Protocol";
                    return;
                }

                _userProfileService.SaveConfiguration(gatewayId, gatewayName, gatewayIp, countryCode, protocol, persistent, linuxId);

                response.Success = true;
                response.Data = "Configuration saved successfully";
            }
            finally { }
        }

        private async Task HandleConnect(JsonElement payload, string linuxId, ResponseEnvelope response)
        {
            try
            {
                _persistentToken?.Cancel();
            }
            catch { }

            if (!EnsureNotConnectedByOtherUser(linuxId, response)) return;
            if (!EnsureNotConnected(response)) return;
            if (!EnsureUserLoggedIn(linuxId, response)) return;

            try
            {
                await _vpnService.Connect(payload, linuxId);

                var status = await _statusService.GetAggregatedStatus(linuxId);

                if (status.Status == "Connected" || status.Status == "Connecting")
                {
                    response.Success = true;
                    response.Data = new
                    {
                        GatewayName = status.ConnectedGatewayName,
                        GatewayIp = status.ConnectedGatewayIp,
                        GatewayCountryCode = status.ConnectedGatewayCountryCode,
                        Protocol = status.ConnectedProtocol,
                        IsRecommended = status.IsRecommended
                    };
                }
                else
                {
                    response.Success = false;
                    response.Error = "connection_failed_or_timeout";
                }
            }
            finally { }
        }

        private async Task HandleDisconnect(string linuxId, bool isRoot, ResponseEnvelope response)
        {
            try
            {
                _persistentToken?.Cancel();
            }
            catch { }

            var (persistentEnabled, ownerUid) = _userProfileService.GetGlobalConfig();
            bool isAnotherUserOwner = !string.IsNullOrEmpty(ownerUid) && ownerUid != linuxId;

            if (_vpnService.IsConnected() && persistentEnabled && isAnotherUserOwner)
            {
                if (isRoot)
                {
                    _logger.Info($"[Disconnect] Forcing disconnect by root user {linuxId} against owner {ownerUid}");
                    await _vpnService.Disconnect();

                    if (!string.IsNullOrEmpty(ownerUid))
                    {  
                        _userProfileService.SetPersistentMode(false, ownerUid);
                    }
             
                    response.Success = true;
                    response.Data = "Another user has been disconnected successfully (forced by admin)";
                    return;
                }
                else
                {
                    response.Success = false;
                    response.Error = "connected_by_other_user";
                    return;
                }
            }

            if (!EnsureUserLoggedIn(linuxId, response)) return;
    
            if (!_vpnService.IsConnected())
            {
                response.Success = false;
                response.Error = "not_connected";
            }
            else
            {
                await _vpnService.Disconnect();
                response.Success = true;
                response.Data = "Disconnected successfully";
            }
        }

        // --- Helpers ---

        private bool EnsureUserLoggedIn(string linuxId, ResponseEnvelope response)
        {
            if (!_authService.IsUserLoggedIn(linuxId))
            {
                response.Success = false;
                response.Error = "not_logged_in";
                return false;
            }
            return true;
        }

        private bool EnsureUserNotLoggedIn(string linuxId, ResponseEnvelope response)
        {
            if (_authService.IsUserLoggedIn(linuxId))
            {
                response.Success = false;
                response.Error = "already_logged_in";
                return false;
            }
            return true;
        }

        private bool EnsureNotConnectedByOtherUser(string linuxId, ResponseEnvelope response)
        {
            var (persistentEnabled, ownerUid) = _userProfileService.GetGlobalConfig();
            if (_vpnService.IsConnected() && persistentEnabled && !string.IsNullOrEmpty(ownerUid) && ownerUid != linuxId)
            {
                response.Success = false;
                response.Error = "connected_by_other_user";
                return false;
            }
            return true;
        }

        private bool EnsureNotConnected(ResponseEnvelope response)
        {
            if (_vpnService.IsConnected())
            {
                response.Success = false;
                response.Error = "already_connected";
                return false;
            }
            return true;
        }

        private string GetStringProperty(JsonElement element, string propertyName)
        {
            if (element.ValueKind == JsonValueKind.Undefined || element.ValueKind == JsonValueKind.Null)
            {
                return "";
            }

            if (element.TryGetProperty(propertyName, out JsonElement prop) ||
                element.TryGetProperty(propertyName.ToLower(), out prop))
            {
                return prop.GetString() ?? "";
            }
            return "";
        }

        private bool GetBooleanProperty(JsonElement element, string propertyName)
        {
            if (element.TryGetProperty(propertyName, out JsonElement prop) ||
                element.TryGetProperty(propertyName.ToLower(), out prop))
            {
                if (prop.ValueKind == JsonValueKind.True) return true;
                if (prop.ValueKind == JsonValueKind.False) return false;
            }
            return false;
        }

        // --- DTO Classes ---

        private class IpcRequest
        {
            public string Command { get; set; } = "";
            public JsonElement Payload { get; set; }
            public JsonElement Context { get; set; }
        }

        private class ResponseEnvelope
        {
            public bool Success { get; set; }
            public object? Data { get; set; }
            public string? Error { get; set; }
        }
    }
}
