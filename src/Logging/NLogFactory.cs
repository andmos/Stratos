using System;
using NLog;

namespace Stratos.Logging
{
    public class NLogFactory : ILogFactory
    {
        public NLogFactory()
        {
            SetupLogger();
        }

        public ILog GetLogger(Type type)
        {
			var logger = LogManager.GetLogger(type.ToString());
			return new Log(logger.Info, logger.Debug, logger.Warn, logger.Error);
        }

        private void SetupLogger() 
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") 
			{ 
				Layout = "${longdate} ${logger} ${level} ${message} ${newline} ${exception} ${exception:format=Type}",
				FileName = "${basedir}/logs/Stratos.log",
                
			};
			config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);         
			config.AddTarget(logfile);
                     
            LogManager.Configuration = config;
        }
    }
}
