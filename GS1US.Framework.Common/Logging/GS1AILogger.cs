using GS1US.Framework.Common.Configuration.Logging;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GS1US.Framework.Common.Logging
{
    /// <summary>
    /// A placeholder Logger that can be built out.
    /// </summary>
    public class GS1AILogger : IGS1USAppInsightsLogger
    {

        public GS1AILogger(string instrumentationKey, bool autoFlushToAppInsight)
        {
            this.instrumentationKey = instrumentationKey;
            this._autoFlushToAppInsight = autoFlushToAppInsight;
        }

        private LogLevel _loglevel;
        public LogLevel LogLevel { get => _loglevel; set { _loglevel = value; } }

        private ILoggingContextService LoggingContextService { get; }

        public GS1AILogger(ILoggingContextService loggingContextService)
        {
            this.LoggingContextService = loggingContextService;
            this._loglevel = LogLevel.Information;
        }

        private TelemetryClient _telemetryClient;
        private Dictionary<string, TelemetryClient> _telemetryClientArray = new Dictionary<string, TelemetryClient>();
        private TelemetryClient TelemetryClient
        {
            get
            {
                if (_telemetryClientArray.ContainsKey(instrumentationKey))
                    return _telemetryClientArray[instrumentationKey];

                if (_telemetryClient == null || _telemetryClient.InstrumentationKey != instrumentationKey)
                {
                    var config = TelemetryConfiguration.CreateDefault();
                    config.InstrumentationKey = instrumentationKey;
                    InitializeTelemetryClient(new TelemetryClient(config));
                }
                return _telemetryClient;
            }
            set { _telemetryClient = value; _telemetryClientArray[instrumentationKey] = value; }
        }

        private string instrumentationKey;
        private bool _autoFlushToAppInsight = false;

        public bool IsEnabled(LogLevel logLevel)
        {
            return this.LogLevel == LogLevel;
        }

        public void Init(string name)
        {

        }

        public void SetLogLevel(LogLevel logLevel)
        {
            this.LogLevel = LogLevel;
        }


        public void AddAppInsightsConnections(AppInsightsConnection appInsightsConnection)
        {
            this.LoggingContextService.AddLoggingSettings(appInsightsConnection);
        }

        public void AddAppInsightsConnections(IEnumerable<AppInsightsConnection> appInsightsConnections)
        {
            this.LoggingContextService.AddLoggingSettings(appInsightsConnections);
        }

        public void SetLoggingConfiguration(string instrumentationKey, bool? autoFlushToAppInsight, LogLevel logLevel)
        {
            this.instrumentationKey = instrumentationKey;
            this._autoFlushToAppInsight = autoFlushToAppInsight ?? true;
            if (logLevel != LogLevel.None) this.LogLevel = LogLevel;
        }

        public void Flush()
        {
            // TODO: testing - turn this off
            if (this._autoFlushToAppInsight)
                TelemetryClient.Flush();

            //TelemetryClient.Flush();
        }

        public void InitializeTelemetryClient(TelemetryClient telemetryClient)
        {
            telemetryClient.InstrumentationKey = instrumentationKey;
            this.TelemetryClient = telemetryClient;
        }

        public void LogToApplicationInsights(string message, SeverityLevel severityLevel = SeverityLevel.Warning,
                                        Exception ex = null, IDictionary<string, object> properties = null)
        {
            var optionalParams = new Dictionary<string, string>();
            if (null != properties) {
                foreach (KeyValuePair<string, object> obj in properties)
                {
                    optionalParams.Add(obj.Key, obj.Value.ToString());
                }
            }

            LogToAppInsights(message, severityLevel, ex, optionalParams);
        }

        private void LogToAppInsights(string message, SeverityLevel severityLevel = SeverityLevel.Warning,
                                       Exception ex = null, IDictionary<string, string> properties = null)
        {
            if (severityLevel == SeverityLevel.Error)
            {
                TelemetryClient.TrackException(ex, properties);
            }
            
            TelemetryClient.TrackTrace(message, severityLevel, properties);
            
            TelemetryClient.Flush();
        }

        public void Error(string message, IDictionary<string, string> properties = null)
        {
            LogToAppInsights(message, severityLevel: SeverityLevel.Error, properties: properties);
        }

        public void Error(string message)
        {
            LogToAppInsights(message);
        }

        private string GetMethodName()
        {
            StackTrace stackTrace = new StackTrace();
            // Get calling method name
            return stackTrace.GetFrame(2).GetMethod().Name;
        }

        public void Exception(Exception ex, IDictionary<string, string> properties = null)
        {

            this.LogToAppInsights(message: $"Application Exception: {ex.Message}",
                ex: ex, severityLevel: this.ExceptionSeverityLevel, properties: properties);
        }

        public void Trace(string message)
        {
            TelemetryClient.TrackTrace(message);
        }

        public void Trace(string message, IDictionary<string, string> properties = null)
        {
            TelemetryClient.TrackTrace(message, properties);
        }

        public void Trace(string message, SeverityLevel severityLevel, IDictionary<string, string> properties = null)
        {
            TelemetryClient.TrackTrace(message, severityLevel, properties);
        }

        private SeverityLevel _exceptionSeverityLevel = SeverityLevel.Error;
        public SeverityLevel ExceptionSeverityLevel { get => _exceptionSeverityLevel; set { _exceptionSeverityLevel = value; } }

        public bool IsDebugEnabled => this.LogLevel == LogLevel.Debug;

        public bool IsInfoEnabled => this.LogLevel == LogLevel.Information;

        public bool IsWarnEnabled => this.LogLevel == LogLevel.Warning;

        public bool IsErrorEnabled => this.LogLevel == LogLevel.Error;

        public bool IsFatalEnabled => this.LogLevel == LogLevel.Critical;

        public void Debug(string message)
        {
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Information);
        }

        public void Debug(Exception exception, string message)
        {
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Information);
        }

        public void Debug(string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message, ex: exception);
        }

        public void Debug(Guid messageId, string message)
        {
            var props = new Dictionary<string, string> { { "correlationId", messageId.ToString() } };
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, properties: props);

        }

        public void Debug(Guid messageId, Exception exception, string message)
        {
            var props = new Dictionary<string, string> { { "correlationId", messageId.ToString() } };
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Error, properties: props);
        }

        public void Debug(Guid messageId, string format, params object[] args)
        {
            var message = $"{messageId}: {string.Format(format, args)}";
            var props = new Dictionary<string, string> { { "correlationId", messageId.ToString() } };

            this.LogToAppInsights(message: message, properties: props);
        }

        public void Debug(Guid messageId, Exception exception, string format, params object[] args)
        {
            var message = $"{messageId}: {string.Format(format, args)}";
            var props = new Dictionary<string, string> { { "correlationId", messageId.ToString() } };

            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Error, properties: props);
        }

        public void Error(Exception exception, string message)
        {
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Error);
        }

        public void Error(string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Error);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Error);
        }

        public void Error(Guid messageId, string message)
        {
            message = $"{messageId}: {message}";
            var props = new Dictionary<string, string> { { "correlationId", messageId.ToString() } };

            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Error, properties: props);
        }

        public void Error(Guid messageId, Exception exception, string message)
        {
            message = $"{messageId}: {message}";
            var props = new Dictionary<string, string> { { "correlationId", messageId.ToString() } };

            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Error, properties: props);
        }

        public void Error(Guid messageId, string format, params object[] args)
        {
            var message = string.Format(format, args);
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Error);
        }

        public void Error(Guid messageId, Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Error);
        }

        public void Fatal(string message)
        {
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Critical);
        }

        public void Fatal(Exception exception, string message)
        {
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Critical);
        }

        public void Fatal(string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Critical);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Critical);
        }

        public void Fatal(Guid messageId, string message)
        {
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Critical);
        }

        public void Fatal(Guid messageId, Exception exception, string message)
        {
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Critical);
        }

        public void Fatal(Guid messageId, string format, params object[] args)
        {
            var message = string.Format(format, args);
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Critical);
        }

        public void Fatal(Guid messageId, Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Critical);
        }

        //public void TestLogToAI(Exception exception, string message)
        //{
        //    var methodName = GetMethodName();
        //    this.Error($"{methodName}: {message}");
        //}

        public void Info(string message)
        {
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Information);
        }

        public void Info(Exception exception, string message)
        {
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Information);
        }

        public void Info(string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Information);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Information);
        }

        public void Info(Guid messageId, string message)
        {
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Information);
        }

        public void Info(Guid messageId, Exception exception, string message)
        {
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Information);
        }

        public void Info(Guid messageId, string format, params object[] args)
        {
            var message = string.Format(format, args);
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Information);
        }

        public void Info(Guid messageId, Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Information);
        }

        public void Warn(string message)
        {
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Warning);
        }

        public void Warn(Exception exception, string message)
        {
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Warning);
        }

        public void Warn(string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Warning);
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Warning);
        }

        public void Warn(Guid messageId, string message)
        {
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Warning);
        }

        public void Warn(Guid messageId, Exception exception, string message)
        {
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Warning);
        }

        public void Warn(Guid messageId, string format, params object[] args)
        {
            var message = string.Format(format, args);
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, severityLevel: SeverityLevel.Warning);
        }

        public void Warn(Guid messageId, Exception exception, string format, params object[] args)
        {
            var message = string.Format(format, args);
            message = $"{messageId}: {message}";
            this.LogToAppInsights(message: message, ex: exception, severityLevel: SeverityLevel.Warning);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this.TelemetryClient.StartOperation<RequestTelemetry>("");
        }

        public IOperationHolder<RequestTelemetry> BeginScope<TState>(TState state, string operationName = "")
        {
            operationName = string.IsNullOrWhiteSpace(operationName) ? operationName : "Operation:" + new Guid().ToString();

            return this.TelemetryClient.StartOperation<RequestTelemetry>(operationName);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var jsonLine = JsonConvert.SerializeObject(new
            {
                logLevel,
                eventId,
                parameters = (state as IEnumerable<KeyValuePair<string, object>>)?.ToDictionary(i => i.Key, i => i.Value),
                message = formatter(state, exception),
                exception = exception?.GetType().Name
            });
        }

        public void FlushNow()
        {
            TelemetryClient.Flush();
        }

        /* PRIVATE METHODS */
        private static string DictionaryToString(IDictionary<string, string> value)
        {
            return $"{{ {string.Join(", ", value?.Select(o => $"\"{o.Key}\": \"{o.Value}\"") ?? new string[0])} }}";
        }
    }
}
