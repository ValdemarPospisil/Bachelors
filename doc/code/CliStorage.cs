using System.Text.Json;
using GoodAccess.Shared;
using Microsoft.AspNetCore.DataProtection;
using GoodAccess.Shared.Auth.Domain;
using CLIService.GoodAccess.UserProfile.Domain;

namespace CLIService.GoodAccess.Main.Storage
{
    public class CliStorage : IAuthStorage
    {
        private readonly Logger _logger;
        private readonly IDataProtector _protector;
        private readonly string _path;
        private readonly object _fileLock = new object();
        private string _lastAccessedLinuxUid = "";

        public CliStorage(string path, Logger logger, IDataProtector protector)
        {
            _path = path;
            _logger = logger;
            _protector = protector;
        }

        public void SetCurrentLinuxId(string linuxId)
        {
            _lastAccessedLinuxUid = linuxId;
        }


        public void SetRefreshToken(string deviceAccountIdentifier, string token, string teamName, string userUUID)
        {
            UpdateData(data =>
            {
                if (!data.ActiveSessions.ContainsKey(deviceAccountIdentifier))
                    data.ActiveSessions[deviceAccountIdentifier] = new ActiveSession();

                var session = data.ActiveSessions[deviceAccountIdentifier];
                session.RefreshToken = token;
                session.TeamName = teamName;
                session.UserUuid = userUUID;

                if (!data.UserPreferences.ContainsKey(userUUID))
                    data.UserPreferences[userUUID] = new UserPreferences();
            });
        }

        public RefreshToken GetRefreshToken(string deviceAccountIdentifier)
        {
            var data = ReadFile();
            if (data.ActiveSessions.TryGetValue(deviceAccountIdentifier, out var session))
            {
                if (string.IsNullOrEmpty(session.RefreshToken)) throw new Exception("TokenEmpty");
                return new RefreshToken(deviceAccountIdentifier, session.RefreshToken, session.TeamName, session.UserUuid);
            }
            throw new Exception("NoSuchToken");
        }

        public string GetUserUUID(string deviceAccountIdentifier)
        {
            var data = ReadFile();
            if (data.ActiveSessions.TryGetValue(deviceAccountIdentifier, out var session))
            {
                return session.UserUuid;
            }
            throw new Exception("SessionNotFound");
        }

        public void ClearLoginData(string deviceAccountIdentifier)
        {
            UpdateData(data =>
            {
                if (data.ActiveSessions.ContainsKey(deviceAccountIdentifier))
                    data.ActiveSessions.Remove(deviceAccountIdentifier);
            });
        }

        public string GetDeviceAccountIdentifier() => _lastAccessedLinuxUid;
        public string? GetUserName() => null;

        public UserPreferences? GetPreferences(string userUuid)
        {
            var data = ReadFile();
            return data.UserPreferences.ContainsKey(userUuid) ? data.UserPreferences[userUuid] : null;
        }

        public GatewayDetailCache? GetGatewayDetails(string gwUuid)
        {
             var data = ReadFile();
             return data.KnownGateways.ContainsKey(gwUuid) ? data.KnownGateways[gwUuid] : null;
        }

        public void SavePreferences(string userUuid, string protocol, string gwUuid, string gwName, string gwIp, string countryCode)
        {
            UpdateData(data =>
            {
                if (!data.UserPreferences.ContainsKey(userUuid))
                    data.UserPreferences[userUuid] = new UserPreferences();

                var p = data.UserPreferences[userUuid];
                p.PreferredProtocol = protocol;
                p.PreferredGatewayUuid = gwUuid;

                if (!string.IsNullOrEmpty(gwUuid))
                {
                    data.KnownGateways[gwUuid] = new GatewayDetailCache
                    {
                        Name = gwName,
                        Ip = gwIp,
                        CountryCode = countryCode
                    };
                }
            });
        }

        public ActiveSession? GetSession(string linuxUid)
        {
            var data = ReadFile();
            return data.ActiveSessions.ContainsKey(linuxUid) ? data.ActiveSessions[linuxUid] : null;
        }

        public void SetUserNameForSession(string linuxUid, string userName)
        {
            UpdateData(data =>
            {
                if (data.ActiveSessions.TryGetValue(linuxUid, out var session))
                    session.UserName = userName;
            });
        }

        public void SetPersistent(bool enabled, string ownerUid)
        {
            UpdateData(data =>
            {
                data.GlobalSettings.PersistentConnectionEnabled = enabled;
                if (enabled) data.GlobalSettings.PersistentOwnerUid = ownerUid;
            });
        }

        public (bool Persistent, string OwnerUid) GetGlobalConfig()
        {
            var data = ReadFile();
            return (data.GlobalSettings.PersistentConnectionEnabled, data.GlobalSettings.PersistentOwnerUid);
        }

        private void UpdateData(Action<CliStorageRoot> updateAction)
        {
            lock (_fileLock)
            {
                var data = ReadFile();
                updateAction(data);
                WriteFile(data);
            }
        }

        private void WriteFile(object json)
        {
            using (StreamWriter sw = File.CreateText(this._path))
            {
                sw.WriteLine(this._protector.Protect(JsonSerializer.Serialize(json)));
            }
        }

        private CliStorageRoot ReadFile()
        {
            try
            {
                if (!File.Exists(this._path))
                {
                    using (StreamWriter sw = File.CreateText(this._path))
                    {
                        string emptyJson = JsonSerializer.Serialize(new CliStorageRoot());
                        sw.WriteLine(this._protector.Protect(emptyJson));
                    }
                    return new CliStorageRoot();
                }
                else
                {
                    string result = "";
                    using (StreamReader sr = new StreamReader(this._path))
                    {
                        string? line;
                        while ((line = sr.ReadLine()) != null) result += line;
                    }
                    if (string.IsNullOrWhiteSpace(result)) return new CliStorageRoot();
                    return JsonSerializer.Deserialize<CliStorageRoot>(this._protector.Unprotect(result)) ?? new CliStorageRoot();
                }
            }
            catch (Exception e)
            {
                _logger.Info(exception: e);
                return new CliStorageRoot();
            }
        }
    }
}
