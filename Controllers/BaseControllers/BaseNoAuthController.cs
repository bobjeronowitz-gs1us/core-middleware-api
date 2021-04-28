using GS1US.Framework.Common.Logging;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GS1US.Framework.API.Controllers.BaseControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseNoAuthController : ControllerBase
    {
        protected IGS1USAppInsightsLogger Logger { get; }
        public BaseNoAuthController(IGS1USAppInsightsLogger logger)
        {
            this.Logger = logger;
        }

        public int GetStatusCodeFromException(string exceptionMsg)
        {
            var str = !string.IsNullOrWhiteSpace(exceptionMsg) && exceptionMsg.Length > 2 ? 
                                            exceptionMsg.Substring(exceptionMsg.Length - 3) 
                                            : "";

            return Int32.TryParse(str, out int j) ? j : 500;
        }

        public IActionResult ThrowHttpException(Exception e) 
        {
            System.Diagnostics.Debug.WriteLine(e, nameof(Exception));
            this.Logger.Error(e, e.Message);
            var errorCode = this.GetStatusCodeFromException(e.Message);

            return this.StatusCode(errorCode, e.Message);
        }
    }
}
