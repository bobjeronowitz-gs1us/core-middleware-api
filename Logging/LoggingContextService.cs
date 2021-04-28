using GS1US.Framework.Common.Configuration.Logging;
using GS1US.Framework.Common.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GS1US.Framework.API.Logging
{
    /// <summary>
    /// Use for tracing http errors
    /// TBD: Needs to be updated to get real values
    /// Put in for a stub example
    /// </summary>
    public class LoggingContextService : ILoggingContextService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private AILoggingSettings _loggingSettings;
        private AILoggingSettings LogSettings
        {
            get
            {
                if (_loggingSettings == null)
                    _loggingSettings = new AILoggingSettings();
                if (_loggingSettings.AppInsightsConnections == null)
                    _loggingSettings.AppInsightsConnections = new List<AppInsightsConnection>();

                return _loggingSettings;
            }
        }

        public LoggingContextService(IOptions<AILoggingSettings> loggingSettings, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _loggingSettings = loggingSettings?.Value ?? new AILoggingSettings();
        }

        public void AddLoggingSettings(AppInsightsConnection appInsightsConnection)
        {
            this.LogSettings.AppInsightsConnections.Add(appInsightsConnection);
        }

        public void AddLoggingSettings(IEnumerable<AppInsightsConnection> appInsightsConnections)
        {
            this.LogSettings.AppInsightsConnections.AddRange(appInsightsConnections);
        }


        public string GetMachineName()
        {
            return Environment.MachineName;
        }

        public string GetRequestPath()
        {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null)
                return string.Empty;
            return Microsoft.AspNetCore.Http.Extensions.UriHelper.BuildAbsolute(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host, _httpContextAccessor.HttpContext.Request.PathBase, _httpContextAccessor.HttpContext.Request.Path);
        }

        public string GetTraceIdentifier()
        {
            return _httpContextAccessor?.HttpContext?.TraceIdentifier;
        }

        public string GetUserName()
        {
            return _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? String.Empty;
        }

        public string GetAppInsightsKey()
        {
            return this.LogSettings.AppInsightsConnections.FirstOrDefault()?.InstrumentationKey;
        }

        public string GetAppInsightsKey(string connectionKey)
        {
            var connection = this.LogSettings.AppInsightsConnections.Find(c => c.ConnectionName == connectionKey);
            return connection.InstrumentationKey;
        }

    }
}
