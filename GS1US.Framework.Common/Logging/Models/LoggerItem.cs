using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace GS1US.Framework.Common.Logging.Models
{
    public class LoggerItem
    {
        public string ApplicationId { get; set; }
        public string Message { get; set; }
        public LogLevel LogLevel { get; set; }
        #nullable enable
        public Exception? Ex { get; set; }
        public LogCategories Category { get; set; }
        public object? Obj { get; set; }
        public IDictionary<string, object>? ExtendedProperties { get; set; }
    }
}
