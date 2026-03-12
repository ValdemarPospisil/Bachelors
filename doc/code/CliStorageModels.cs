using System.Collections.Generic;

namespace CLIService.GoodAccess.Main.Storage
{
    public class CliStorageRoot
    {
        public GlobalConfig GlobalSettings { get; set; } = new();

        public Dictionary<string, ActiveSession> ActiveSessions { get; set; } = new();

        public Dictionary<string, UserPreferences> UserPreferences { get; set; } = new();

        public Dictionary<string, GatewayDetailCache> KnownGateways { get; set; } = new();
    }

    public class GlobalConfig
    {
        public string ServiceVersion { get; set; } = "";
        public bool PersistentConnectionEnabled { get; set; }
        public string PersistentOwnerUid { get; set; } = "";
    }

    public class ActiveSession
    {
        public string UserUuid { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public string TeamName { get; set; } = "";
        public string UserName { get; set; } = "";
    }

    public class UserPreferences
    {
        public string PreferredProtocol { get; set; } = "WireGuard";
        public string PreferredGatewayUuid { get; set; } = "";
    }

    public class GatewayDetailCache
    {
        public string Name { get; set; } = "";
        public string Ip { get; set; } = "";
        public string CountryCode { get; set; } = "";
    }
}
