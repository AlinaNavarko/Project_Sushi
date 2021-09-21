using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace Project_sushi
{
    public static class LoggingService
    {
        /*  static LoggingService()
          {
              Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.File("project_sushi_log.log", fileSizeLimitBytes: 1000, rollOnFileSizeLimit: true) // ограничение размера файла лога 30 кб
                  .CreateLogger();
          }
          public static void AddEventToLog(string message) => Log.Information(message);*/

        public static ILog Log { get; } = LogManager.GetLogger(typeof(LoggingService));
        public static void AddEventToLog(string message)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(new FileInfo(@"..\..\..\Services\log4net.config"));
            Log.Info(message);
        }
    }
}
