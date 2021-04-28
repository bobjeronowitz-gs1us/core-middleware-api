using GS1US.Framework.API.Controllers.BaseControllers;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.API.Models;
using GS1US.Framework.API.Security;
using GS1US.Framework.Common.Logging;
using GS1US.Framework.DAL.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Controllers
{
    public class ProductController : BaseJwtScopedController
    {
        private const string PRODUCT_READ_SCOPE = "product.read";
        private const string PRODUCT_WRITE_SCOPE = "product.write";

        private IProductControllerService ProductControllerService { get; }

        public ProductController(IProductControllerService productControllerService,
                                    IGS1USAppInsightsLogger logger) : base(logger)
        {
            this.ProductControllerService = productControllerService;
        }

        [HttpGet]
        [B2CScope(ScopeName = ProductController.PRODUCT_READ_SCOPE)]
        public Task<IEnumerable<ProductViewModel>> Get()
        {
            return this.ProductControllerService.GetProductsAsync();
        }

        [HttpGet]
        [B2CScope(ScopeName = ProductController.PRODUCT_READ_SCOPE)]
        [Route("GetAllProducts")]
        public Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            return this.ProductControllerService.GetProductsAsync();
        }

        [HttpGet]
        [B2CScope(ScopeName = ProductController.PRODUCT_READ_SCOPE)]
        [Route("GetProductById")]
        public Task<ProductViewModel> GetProductById(string id)
        {
            Int32.TryParse(id, out int prodId);
            return this.ProductControllerService.GetProductById(prodId);
        }

        [HttpPost]
        [B2CScope(ScopeName = ProductController.PRODUCT_READ_SCOPE)]
        [Route("SearchProducts")]
        public async Task<IActionResult> SearchProducts([FromBody] SearchCriteria searchCriteria)
        {   
            var products = await this.ProductControllerService.SearchProductsAsync(searchCriteria);
            return Ok(products);
        }

        [HttpGet]
        [B2CScope(ScopeName = ProductController.PRODUCT_READ_SCOPE)]
        [Route("GetTestProducts")]
        public async Task<IActionResult> GetTestProducts()
        {
            var products = await this.ProductControllerService.GetTestProductsAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}
