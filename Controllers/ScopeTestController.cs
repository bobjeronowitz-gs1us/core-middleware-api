using GS1US.Framework.API.Controllers.BaseControllers;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.API.Security;
using GS1US.Framework.Common.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GS1US.Framework.API.Controllers
{
    public class TestScopesController : BaseJwtScopedController
    {
        private const string TEST_READ_SCOPE = "product.read";
        private readonly IValuesControllerService _valuesService;

        public TestScopesController(IValuesControllerService valuesService, 
                                        IGS1USAppInsightsLogger logger) : base(logger)
        {
            _valuesService = valuesService;
        }

        [HttpGet]
        [B2CScope(ScopeName = TestScopesController.TEST_READ_SCOPE)]
        public IEnumerable<string> Get()
        {

            var testData = new List<string>();
            testData.Add("Item 1");
            testData.Add("Item 2");
            testData.Add("Item 3");
            testData.Add("Item 4");
            testData.Add("Item 5");

            return _valuesService.GetValues();
        }
    }
}
