using System;
namespace Stratos.Logging
{
    public class Log : ILog
    {
        private readonly Action<string> logDebug;
        private readonly Action<string, Exception> logError;
        private readonly Action<string> logInfo;
		private readonly Action<string, Exception> logWarn;

        public Log(Action<string> logInfo, Action<string> logDebug, Action<string, Exception> logWarn, Action<string, Exception> logError)
        {
            this.logInfo = logInfo;
            this.logDebug = logDebug;
			this.logWarn = logWarn;
            this.logError = logError;

        }

        public void Info(string message)
        {
            logInfo(message);
        }

        public void Debug(string message)
        {
            logDebug(message);
        }

		public void Error(string message, Exception exception)
        {
			logError(message, exception);
        }

		public void Warning(string message, Exception exception)
        {
			logWarn(message, exception);
        }
    }
}
