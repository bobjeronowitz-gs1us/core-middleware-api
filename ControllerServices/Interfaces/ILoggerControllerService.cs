using GS1US.Framework.Common.Logging.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS1US.Framework.API.ControllerServices.Interfaces
{
    public interface ILoggerControllerService
    {
        Task<bool> LogObject(string appId, string message, LogLevel logLevel, Exception ex, LogCategories category, object obj, IDictionary<string, object> extendedProperties = null);
        Task<bool> LogObject(LoggerItem loggerItem, LogLevel logLevel);
    }
}
