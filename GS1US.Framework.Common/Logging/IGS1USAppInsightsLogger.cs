using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace GS1US.Framework.Common.Logging
{
    public interface IGS1USAppInsightsLogger : ILogger
    {
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        void SetLoggingConfiguration(string instrumentationKey, bool? autoFlushToAppInsight, LogLevel logLevel = LogLevel.None);

        void LogToApplicationInsights(string message, SeverityLevel severityLevel = SeverityLevel.Warning,
                                        Exception ex = null, IDictionary<string, object> properties = null);
        /// <summary>
        /// Application Insights definitions
        /// </summary>
        /// <param name="telemetryClient"></param>
        void InitializeTelemetryClient(TelemetryClient telemetryClient);
        void Trace(string message, IDictionary<string, string> properties = null);
        void Error(string message, IDictionary<string, string> properties = null);
        void Exception(Exception ex, IDictionary<string, string> properties = null);
        void Trace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties = null);
        void Flush();
        void FlushNow();

        /// <summary>
        /// Initializes logger instance.
        /// </summary>
        /// <param name="message">message string</param>
        void Init(string name);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">message string</param>
        void Debug(string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Debug(Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Debug(string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Debug(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="message">message string</param>
        void Debug(Guid messageId, string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Debug(Guid messageId, Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary> 
        /// <param name="messageId">GUID message ID</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Debug(Guid messageId, string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Debug(Guid messageId, Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">message string</param>
        void Info(string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Info(Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Info(string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Info(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="message">message string</param>
        void Info(Guid messageId, string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Info(Guid messageId, Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary> 
        /// <param name="messageId">GUID message ID</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Info(Guid messageId, string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Info(Guid messageId, Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">message string</param>
        void Warn(string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Warn(Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Warn(string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Warn(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="message">message string</param>
        void Warn(Guid messageId, string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Warn(Guid messageId, Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary> 
        /// <param name="messageId">GUID message ID</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Warn(Guid messageId, string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Warn(Guid messageId, Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">message string</param>
        void Error(string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Error(Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Error(string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Error(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="message">message string</param>
        void Error(Guid messageId, string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Error(Guid messageId, Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary> 
        /// <param name="messageId">GUID message ID</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Error(Guid messageId, string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Error(Guid messageId, Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">message string</param>
        void Fatal(string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Fatal(Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Fatal(string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Fatal(Exception exception, string format, params object[] args);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="message">message string</param>
        void Fatal(Guid messageId, string message);

        /// <summary>
        /// Logs an exception and a message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="message">message string</param>
        void Fatal(Guid messageId, Exception exception, string message);

        /// <summary>
        /// Logs a formatted message.
        /// </summary> 
        /// <param name="messageId">GUID message ID</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Fatal(Guid messageId, string format, params object[] args);

        /// <summary>
        /// Logs an exception and a formatted message.
        /// </summary>
        /// <param name="messageId">GUID message ID</param>
        /// <param name="exception">exception object</param>
        /// <param name="format">message string format</param>
        /// <param name="args">message string parameters</param>
        void Fatal(Guid messageId, Exception exception, string format, params object[] args);
    }
}
