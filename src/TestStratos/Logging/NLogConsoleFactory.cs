using System;
using NLog;
using Stratos.Logging;

namespace TestStratos.Logging
{
    public class NLogConsoleFactory : ILogFactory 
    {
        public NLogConsoleFactory()
        {
            SetupLogger();
        }

        public ILog GetLogger(Type type)
        {
            var logger = LogManager.GetCurrentClassLogger(type);
            return new Log(logger.Info, logger.Debug, logger.Warn, logger.Error);
        }

        private void SetupLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
			var logconsole = new NLog.Targets.ConsoleTarget("logconsole")
			{
				Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception}"
			};
			config.AddTarget(logconsole);
            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logconsole);

            LogManager.Configuration = config;
        }
    }
}
