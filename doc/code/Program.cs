using GoodAccess.Shared;
using CLIService.GoodAccess;
using CLIService.GoodAccess.Main;
using Microsoft.AspNetCore.DataProtection;

namespace CLIService
{
    class Program
    {

        public static async Task Main(string[] args)
        {
            Logger logger = new ServiceLogger();
            logger.Info("Starting CLIService...");

            string keysPath = "/opt/GoodAccess/configs/DataProtection-Keys";

            if (!Directory.Exists(keysPath))
            {
                Directory.CreateDirectory(keysPath);
                if (OperatingSystem.IsLinux())
                {
                    try
                    {
                        System.Diagnostics.Process.Start("chmod", $"700 {keysPath}");
                    }
                    catch { }
                }
            }

            try
            {
                IHost host = Host.CreateDefaultBuilder(args)
                .UseSystemd()
                .ConfigureServices(services =>
                {
                    services.AddDataProtection()
                        .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
                        .SetApplicationName("CLIService");

                    services.AddSingleton(logger);
                    services.AddHostedService<Worker>();
                })
                .Build();

                await host.RunAsync();
            }
            catch (Exception ex)
            {
                logger.Info("Error occured during starting service");
                logger.Error(ex);
            }
        }
    }
}
