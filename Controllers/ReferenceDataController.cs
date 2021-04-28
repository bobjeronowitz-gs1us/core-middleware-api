using GS1US.Framework.API.Controllers.BaseControllers;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.API.Security;
using GS1US.Framework.Common.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Controllers
{
    public class ReferenceDataController : BaseNoAuthController
    {
        private const string PRODUCT_READ_SCOPE = "product.read";
        private IReferenceDataControllerService ReferenceDataService { get; }

        public ReferenceDataController(IReferenceDataControllerService referenceDataService, 
                                            IGS1USAppInsightsLogger logger): base(logger) 
        {
            ReferenceDataService = referenceDataService;
        }
        
        [HttpGet]
        [Route("GetAllReferenceData")]
        // [B2CScope(ScopeName = ReferenceDataController.PRODUCT_READ_SCOPE)]
        public async Task<IActionResult> GetAllReferenceData()
        {
            try
            {
                var t = await this.ReferenceDataService.GetAllReferenceData();
                if (t == null) 
                {
                    return this.StatusCode(400, "Error retrieving reference data. No Reference Data Found");
                }
                return Ok(t);
            }
            catch (Exception e)
            {   
                return this.ThrowHttpException(e);
            }
        }

        [HttpGet]
        [Route("GetReferenceDataByArea")]
        [B2CScope(ScopeName = ReferenceDataController.PRODUCT_READ_SCOPE)]
        public async Task<IActionResult> GetReferenceData(string applicationArea) // ie: applicationArea = product
        {  
            try
            {
                var t = await this.ReferenceDataService.GetReferenceDataByApplicationArea(applicationArea);
                if (t == null)
                {
                    return this.StatusCode(400, "Error retrieving reference data. No Reference Data Found");
                }
                
                return Ok(t);
            }
            catch (Exception e)
            {
                return this.ThrowHttpException(e);
            }
        }
    }
}
