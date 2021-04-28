using GS1US.Framework.Common.Configuration.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Common.Logging
{
    public interface ILoggingContextService
    {
        void AddLoggingSettings(AppInsightsConnection appInsightsConnection);
        void AddLoggingSettings(IEnumerable<AppInsightsConnection> appInsightsConnection);

        /// <summary>
        /// Gets request application insights key
        /// </summary>
        /// <returns></returns>
        string GetAppInsightsKey();

        /// <summary>
        /// Gets request application insights key
        /// </summary>
        /// <returns></returns>
        string GetAppInsightsKey(string connectionKey);

        /// <summary>
        /// Gets request path
        /// </summary>
        /// <returns></returns>
        string GetRequestPath();

        /// <summary>
        /// Gets user name
        /// </summary>
        /// <returns></returns>
        string GetUserName();

        /// <summary>
        /// Gets trace identifier
        /// </summary>
        /// <returns></returns>
        string GetTraceIdentifier();

        /// <summary>
        /// Gets machine name
        /// </summary>
        /// <returns></returns>
        string GetMachineName();
    }
}
