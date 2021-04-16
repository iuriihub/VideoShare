using System;

namespace VideoShare.Infrastructure.Interfaces
{
    public interface IExtendedLogger<out T> : IExtendedLogger
    {
    }

    public interface IExtendedLogger
    {
        string Action { get; set; }
        string CorrelationId { get; set; }

        void LogFatal(string message, Exception ex, params object[] parameters);
        void LogFatal(string message, params object[] parameters);
        void LogFatal(string message, string correlationId, Exception ex, params object[] parameters);
        void LogFatal(string message, string correlationId, params object[] parameters);

        void LogError(string message, Exception ex, params object[] parameters);
        void LogError(string message, params object[] parameters);
        void LogError(string message, string correlationId, Exception ex, params object[] parameters);
        void LogError(string message, string correlationId, params object[] parameters);

        void LogWarning(string message, Exception ex, params object[] parameters);
        void LogWarning(string message, params object[] parameters);
        void LogWarning(string message);
        void LogWarning(string message, string correlationId, Exception ex, params object[] parameters);
        void LogWarning(string message, string correlationId, params object[] parameters);
        void LogWarning(string message, string correlationId);

        void LogInformation(string message, Exception ex, params object[] parameters);
        void LogInformation(string message, params object[] parameters);
        void LogInformation(string message);
        void LogInformation(string message, string correlationId, Exception ex, params object[] parameters);
        void LogInformation(string message, string correlationId, params object[] parameters);
        void LogInformation(string message, string correlationId);

        void LogTrace(string message, Exception ex, params object[] parameters);
        void LogTrace(string message, params object[] parameters);
        void LogTrace(string message);
        void LogTrace(string message, string correlationId, Exception ex, params object[] parameters);
        void LogTrace(string message, string correlationId, params object[] parameters);
        void LogTrace(string message, string correlationId);

        void LogDebug(string message, Exception ex, params object[] parameters);
        void LogDebug(string message, params object[] parameters);
        void LogDebug(string message);
    }
}
