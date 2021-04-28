using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.Common.Logging;
using GS1US.Framework.Common.Logging.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS1US.Framework.API.ControllerServices
{
    public class LoggerControllerService : ILoggerControllerService
    {
        private IGS1USAppInsightsLogger Logger { get; }

        public LoggerControllerService(IGS1USAppInsightsLogger logger)
        {
            Logger = logger;
        }

        public async Task<bool> LogObject(string appId, string message, LogLevel logLevel, Exception ex, LogCategories category, object obj, IDictionary<string, object> extendedProperties)
        {
            var logSucceed = false;
            await Task.Run(() => LogObjectAsync());

            return logSucceed;
        }

        public async Task<bool> LogObject(LoggerItem loggerItem, LogLevel logLevel)
        {
            var logSucceed = false;
            this.Logger.LogToApplicationInsights(loggerItem.Message, loggerItem.LogLevel.ToSeverityLevel(), loggerItem.Ex, loggerItem.ExtendedProperties);
         
            await Task.Run(() => LogObjectAsync());

            return logSucceed;
        }

        /// <summary>
        /// Used just to simultate an async
        /// </summary>
        private static void LogObjectAsync()
        {
            
        }

        
    }
}
