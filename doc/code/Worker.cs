using GoodAccess.Shared;
using CLIService.GoodAccess.Main;
using Microsoft.AspNetCore.DataProtection;
using GoodAccess.Shared.Auth.Service;
using GoodAccess.Shared.Auth.Boundary;
using CLIService.GoodAccess.UserProfile.Boundary;
using CLIService.GoodAccess.Gateways.Boundary;
using CLIService.GoodAccess.Gateways.Service;
using CLIService.GoodAccess.UserProfile.Service;
using GoodAccess.Shared.Main;
using GoodAccess.Shared.Proto.Boundary;
using GoodAccess.Shared.Proto.Boundary.Protocols.Agents;
using GoodAccess.Shared.Proto.Boundary.Protocols;
using GoodAccess.Shared.Proto.Boundary.Protocols.Agents;
using GoodAccess.Shared.Proto.Boundary.Protocols.Wireguard;
using GoodAccess.Shared.Proto.Domain;
using GoodAccess.Shared.Proto.Service;
using CLIService.GoodAccess.Vpn.Domain;
using CLIService.GoodAccess.Vpn.Service;
using CLIService.GoodAccess.Main.Storage;

namespace CLIService.GoodAccess
{
    public class Worker : BackgroundService
    {
        private readonly Logger _logger;
        private readonly IDataProtectionProvider _protectionProvider;
        private CliMessenger? _cliMessenger;
        private AuthService? _authService;
        private CliRepository _cliRepository;
        private VpnService _vpnService;

        public Worker(IDataProtectionProvider protectionProvider, Logger logger)
        {
            _logger = logger;
            _protectionProvider = protectionProvider;
            Init();
        }

        private void Init()
        {
            _logger.Info("Initializing CLIService Worker...");

            string rootFolder = "/opt/GoodAccess/";
            string configsPath = Path.Combine(rootFolder, "configs");
            string storagePath = Path.Combine(configsPath, "cli_settings.json");

            string apiHost = "https://api.goodaccess-pre-release.dev.samohyb.cz";
            string purpose = "GoodAccessService.GoodAccess.v1";
            string appVersion = "1.0.0";

            CreateFolders(rootFolder, configsPath);

            DeviceIdentifierGetter deviceIdentifierGetter = new DeviceIdentifierGetter(_logger);
            string deviceUuid = deviceIdentifierGetter.GetUUID();

            IDataProtector protector = _protectionProvider.CreateProtector(purpose);
            WebApiClientStorage webApiClientStorage = new WebApiClientStorage();

            ApiClient apiClient = new ApiClient(
                logger: _logger,
                apiHost: apiHost,
                webApiClientStorage: webApiClientStorage
            );
            apiClient.SetHeaderInformations(appVersion, deviceUuid);

            var storage = new CliStorage(storagePath, _logger, protector);
            _cliRepository = new CliRepository(
                storage,
                _logger
            );

            _authService = new AuthService(
                _logger,
                webApiClientStorage,
                new WebApiAuthClient(_logger, apiClient),
                new AuthRepository(storage, _logger)
            );

            InternetConnection internetConnection = new InternetConnection(_logger);

            string configDir = "/opt/GoodAccess/configs";
            if (!Directory.Exists(configDir)) Directory.CreateDirectory(configDir);

            var agentsList = new List<IAgent>
            {
                new OpenVPN(
                    _logger,
                    new ProtocolProcess(_logger),
                    Path.Combine(configDir, "ga_mgmt_pwd"),
                    Path.Combine(configDir, "ga_creds"),
                    Path.Combine(configDir, "ga_config.ovpn"),
                    "/usr/sbin/openvpn"
                )
            };
            
            agentsList.Add(new WireGuard(_logger, new WireGuardLinuxManager(_logger)));
            

            IAgent[] agents = agentsList.ToArray();

            VpnManager vpnManager = new VpnManager(_logger, agents, internetConnection);

            _vpnService = new VpnService(
                new ProtoService(
                    _logger,
                    _authService,
                    new ConnectionRepository(new CliConnectionStorage()),
                    new WebApiCertificateClient(_logger, apiClient),
                    new WebApiConfigClient(_logger, apiClient),
                    new WebApiDeviceAccessLogClient(_logger, apiClient),
                    vpnManager,
                    agents,
                    new CertificateInstaller(_logger, Path.Combine(configDir, "ca.crt")),
                    internetConnection
                ), 
                vpnManager, 
                new UserProfileService(_cliRepository, _logger), 
                _logger
            );

            GatewayService gatewayService = new GatewayService(new WebApiGatewayClient(_logger, apiClient), _authService, _logger);

            _cliMessenger = new CliMessenger(
                _logger,
                new SenderReader(_logger, "ga-cli.sock"),
                _authService,
                gatewayService,
                new UserProfileService(_cliRepository, _logger),
                new StatusService(new UserProfileService(_cliRepository, _logger), _vpnService, gatewayService),
                _vpnService,
                internetConnection
            );
        }

        private void CreateFolders(string rootFolder, string configsPath)
        {
            if (!Directory.Exists(rootFolder)) Directory.CreateDirectory(rootFolder);
            if (!Directory.Exists(configsPath)) Directory.CreateDirectory(configsPath);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.Info("Starting GoodAccess CLI Service...");

            try
            {
                if (_cliMessenger != null) await _cliMessenger.Start(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                Environment.Exit(1);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _cliMessenger?.Stop();
            return base.StopAsync(cancellationToken);
        }
    }
}
