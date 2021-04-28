using GS1US.Framework.API.Controllers.BaseControllers;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.Common.Logging;
using Microsoft.AspNetCore.Mvc;

namespace GS1US.Framework.API.Controllers
{
    public class TestController : BaseNoAuthController
    {
        private readonly IValuesControllerService _valuesService;
        public TestController(IValuesControllerService valuesService, IGS1USAppInsightsLogger logger): base(logger)
        {
            _valuesService = valuesService;
        }

        [HttpGet]
        public IActionResult Get()
        {   
            return Ok(_valuesService.GetValues());
        }
    }
}
