using GS1US.Framework.API.Controllers.BaseControllers;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.Common.Logging;
using GS1US.Framework.Common.Logging.Models;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Controllers
{
    public class LoggerController : BaseNoAuthController
    {
        private ILoggerControllerService LoggerService { get; }
        private IValuesControllerService ValuesService { get; }

        public LoggerController(ILoggerControllerService loggerService,
                                    IValuesControllerService valuesService,
                                    IGS1USAppInsightsLogger logger): base(logger)
        {
            LoggerService = loggerService;
            this.ValuesService = valuesService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.ValuesService.GetValues());
        }

        [HttpPost]
        [Route("Critical")]
        public async Task<IActionResult> Critical([FromBody] LoggerItem loggerItem)
        {
            var log = await this.LoggerService.LogObject(loggerItem, GetSeverityLevel(LogLevel.Critical, loggerItem.LogLevel));
            return Ok(log);
        }

        [HttpPost]
        [Route("SearchProducts")]
        public async Task<IActionResult> SearchProducts([FromBody] LoggerItem loggerItem)
        {
            // var logItem = new LoggerItem() { Message = message };
            var log = await this.LoggerService.LogObject(loggerItem, LogLevel.Error);
            return Ok(log);
        }

        [HttpPost]
        [Route("Error")]
        public async Task<IActionResult> Error([FromBody] LoggerItem loggerItem)
        {
            var log = await this.LoggerService.LogObject(loggerItem, GetSeverityLevel(LogLevel.Error, loggerItem.LogLevel));
            return Ok(log);
        }

        [HttpPost]
        [Route("Warning")]
        public async Task<IActionResult> Warning([FromBody] LoggerItem loggerItem)
        {
            var log = await this.LoggerService.LogObject(loggerItem, GetSeverityLevel(LogLevel.Warning, loggerItem.LogLevel));
            return Ok(log);
        }

        [HttpPost]
        [Route("Info")]
        public async Task<IActionResult> Info([FromBody] LoggerItem loggerItem)
        {
            var log = await this.LoggerService.LogObject(loggerItem, GetSeverityLevel(LogLevel.Information, loggerItem.LogLevel));
            return Ok(log);
        }

        [HttpPost]
        [Route("Debug")]
        public async Task<IActionResult> Debug([FromBody] LoggerItem loggerItem)
        {
            var log = await this.LoggerService.LogObject(loggerItem, GetSeverityLevel(LogLevel.Debug, loggerItem.LogLevel));
            return Ok(log);
        }

        [HttpPost]
        [Route("Trace")]
        public async Task<IActionResult> Trace([FromBody] LoggerItem loggerItem)
        {
            var log = await this.LoggerService.LogObject(loggerItem, GetSeverityLevel(LogLevel.Trace, loggerItem.LogLevel));
            return Ok(log);
        }

        private LogLevel GetSeverityLevel(LogLevel defaultLevel, LogLevel logLevel = LogLevel.None) 
        {
            return logLevel != LogLevel.None ? logLevel : defaultLevel;
        }
    }
}
