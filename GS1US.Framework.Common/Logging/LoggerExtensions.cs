using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Logging;
using System;

namespace GS1US.Framework.Common.Logging
{
    public static class LoggerExtensions
    {
        /// <summary>
        ///     Gets the application insights severity level.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <returns>SeverityLevel.</returns>
        /// <exception cref="NotSupportedException">Unknown Severity Level</exception>
        public static SeverityLevel ToSeverityLevel(this LogLevel severity)
        {
            switch (severity)
            {
                case LogLevel.Critical:
                    return SeverityLevel.Critical;
                case LogLevel.Error:
                    return SeverityLevel.Error;
                case LogLevel.Warning:
                    return SeverityLevel.Warning;
                case LogLevel.Information:
                    return SeverityLevel.Information;
                case LogLevel.Debug:
                    return SeverityLevel.Verbose;
                default:
                    throw new NotSupportedException("Unknown Log Level " + severity);
            }
        }
    }
}
