using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.API.Models;
using GS1US.Framework.API.Security;
using GS1US.Framework.DAL.Services.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GS1US.Framework.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[EnableCors("AccessControlCors")]
    public class RegistryProductController : ControllerBase
    {
        private const string REGISTRY_READ_SCOPE = "product.read";
        private readonly IProductControllerService _productControllerService;

        public RegistryProductController(IProductControllerService productControllerService)
        {
            _productControllerService = productControllerService;
        }

        [HttpGet]
        [B2CScope(ScopeName = RegistryProductController.REGISTRY_READ_SCOPE)]
        public Task<IEnumerable<ProductViewModel>> Get()
        {
            return _productControllerService.GetProductsAsync();
        }

        [HttpGet]
        [B2CScope(ScopeName = RegistryProductController.REGISTRY_READ_SCOPE)]
        [Route("GetAllProducts")]
        public Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            return _productControllerService.GetRegistryProductsAsync();
        }

        [HttpGet]
        [B2CScope(ScopeName = RegistryProductController.REGISTRY_READ_SCOPE)]
        [Route("GetProductById")]
        public IActionResult GetProductById(string id)
        {
            Int32.TryParse(id, out int prodId);
            var product = _productControllerService.GetRegistryProductById(prodId);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        
        [HttpPost]
        [B2CScope(ScopeName = RegistryProductController.REGISTRY_READ_SCOPE)]
        [Route("SearchProducts")]
        public Task<IEnumerable<ProductViewModel>> SearchProducts([FromBody] SearchCriteria searchCriteria)
        {   
            return _productControllerService.SearchRegistryProductsAsync(searchCriteria);
        }
    }
}
