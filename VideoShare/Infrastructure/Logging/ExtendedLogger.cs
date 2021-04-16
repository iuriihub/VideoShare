using System;
using Newtonsoft.Json;
using NLog;
using VideoShare.Infrastructure.Interfaces;

namespace VideoShare.Infrastructure.Logging
{
    public class ExtendedLogger<T> : IExtendedLogger<T>
    {
        private readonly ILogger _logger;

        public string CorrelationId { get; set; }
        public string Action { get; set; }

        public ExtendedLogger()
        {
            Action = string.Empty;
            _logger = LogManager.GetLogger(typeof(T).Name);
        }

        private void Log(LogLevel logLevel, string message, Exception ex, params object[] parameters)
        {
            LogEventInfo eventInfo = new LogEventInfo(logLevel, _logger.Name, message);
            eventInfo.Exception = ex;
            eventInfo.Properties["correlationId"] = CorrelationId;
            eventInfo.Properties["action"] = Action;

            try
            {
                if (parameters != null && parameters.Length == 1 && parameters[0] is string)
                {
                    eventInfo.Properties["parameters"] = (string)parameters[0];
                }
                else
                {
                    eventInfo.Properties["parameters"] = JsonConvert.SerializeObject(parameters, Formatting.None);
                }
            }
            catch
            {
                eventInfo.Properties["parameters"] = "parameter serialization failed";
            }

            _logger.Log(typeof(T), eventInfo);
        }

        public void LogDebug(string message)
        {
            Log(LogLevel.Debug, message, null, null);
        }

        public void LogDebug(string message, params object[] parameters)
        {
            Log(LogLevel.Debug, message, null, parameters);
        }

        public void LogDebug(string message, Exception ex, params object[] parameters)
        {
            Log(LogLevel.Debug, message, ex, parameters);
        }

        public void LogError(string message, params object[] parameters)
        {
            Log(LogLevel.Error, message, null, parameters);
        }

        public void LogError(string message, string correlationId, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Error, message, null, parameters);
        }

        public void LogError(string message, Exception ex, params object[] parameters)
        {
            Log(LogLevel.Error, message, ex, parameters);
        }

        public void LogError(string message, string correlationId, Exception ex, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Error, message, ex, parameters);
        }

        public void LogFatal(string message, params object[] parameters)
        {
            Log(LogLevel.Fatal, message, null, parameters);
        }

        public void LogFatal(string message, Exception ex, params object[] parameters)
        {
            Log(LogLevel.Fatal, message, ex, parameters);
        }

        public void LogFatal(string message, string correlationId, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Fatal, message, null, parameters);
        }

        public void LogFatal(string message, string correlationId, Exception ex, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Fatal, message, ex, parameters);
        }

        public void LogInformation(string message)
        {
            Log(LogLevel.Info, message, null, null);
        }

        public void LogInformation(string message, params object[] parameters)
        {
            Log(LogLevel.Info, message, null, parameters);
        }

        public void LogInformation(string message, Exception ex, params object[] parameters)
        {
            Log(LogLevel.Info, message, ex, parameters);
        }

        public void LogInformation(string message, string correlationId)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Info, message, null, null);
        }

        public void LogInformation(string message, string correlationId, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Info, message, null, parameters);
        }

        public void LogInformation(string message, string correlationId, Exception ex, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Info, message, ex, parameters);
        }

        public void LogTrace(string message)
        {
            Log(LogLevel.Trace, message, null, null);
        }

        public void LogTrace(string message, params object[] parameters)
        {
            Log(LogLevel.Trace, message, null, parameters);
        }

        public void LogTrace(string message, Exception ex, params object[] parameters)
        {
            Log(LogLevel.Trace, message, ex, parameters);
        }

        public void LogTrace(string message, string correlationId)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Trace, message, null, null);
        }

        public void LogTrace(string message, string correlationId, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Trace, message, null, parameters);
        }

        public void LogTrace(string message, string correlationId, Exception ex, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Trace, message, ex, parameters);
        }

        public void LogWarning(string message)
        {
            Log(LogLevel.Warn, message, null, null);
        }

        public void LogWarning(string message, params object[] parameters)
        {
            Log(LogLevel.Warn, message, null, parameters);
        }

        public void LogWarning(string message, Exception ex, params object[] parameters)
        {
            Log(LogLevel.Warn, message, ex, parameters);
        }

        public void LogWarning(string message, string correlationId)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Warn, message, null, null);
        }

        public void LogWarning(string message, string correlationId, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Warn, message, null, parameters);
        }

        public void LogWarning(string message, string correlationId, Exception ex, params object[] parameters)
        {
            CorrelationId = correlationId;
            Log(LogLevel.Warn, message, ex, parameters);
        }
    }
}
