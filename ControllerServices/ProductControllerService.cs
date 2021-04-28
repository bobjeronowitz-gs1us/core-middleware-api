using AutoMapper;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.API.Models;
using GS1US.Framework.Common.Authentication;
using GS1US.Framework.Common.Logging;
using GS1US.Framework.DAL.Services.Entities;
using GS1US.Framework.Domain.Services.Interfaces;
using GS1US.Framework.Domain.Services.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GS1US.Framework.API.ControllerServices
{
    public class ProductControllerService : IProductControllerService
    {   
        private IGS1USAppInsightsLogger Logger { get; }
        private IMapper Mapper { get; }
        private readonly IProductDomainService _productDomainService;
        private IClaimsPrincipalService ClaimsPrincipalService { get; }

        public ProductControllerService(IProductDomainService productDomainService,
                                            IClaimsPrincipalService claimsPrincipalService,
                                            IMapper mapper, IGS1USAppInsightsLogger logger)
        {
            _productDomainService = productDomainService;
            Logger = logger;
            Mapper = mapper;
            this.ClaimsPrincipalService = claimsPrincipalService;
        }

        public Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            this.Logger.Info("Got Here");

            var userId = this.ClaimsPrincipalService.GetIdentityName();
            var userName = this.ClaimsPrincipalService.GetSamAccountName();
            return _GetProducts(false);
        }

        public Task<IEnumerable<ProductViewModel>> GetRegistryProductsAsync()
        {
            return _GetProducts(true);
        }

        private async Task<IEnumerable<ProductViewModel>> _GetProducts(bool isRegistry) {
            try
            {
                var response = isRegistry ? await _productDomainService.GetRegistryProducts() : await _productDomainService.GetProducts();

                if (!response.Any())
                {
                    return null;
                }

                var content = MapProductResult<ProductViewModel>(response);

                return content;
            }
            catch (Exception e)
            {
                var msg = $"ProductControllerService: Failed to get products data: {e.Message}";
                Logger.Error(e, msg);
                throw new Exception(message: msg);
            }

            return null;
        }

        public Task<ProductViewModel> GetProductById(int id) 
        {
            return _GetProductById(id, false);
        }

        public Task<ProductViewModel> GetRegistryProductById(int id)
        {
            return _GetProductById(id, true);
        }

        private async Task<ProductViewModel> _GetProductById(int id, bool isRegistry) 
        {
            try
            {
                ProductDto response = isRegistry ? await _productDomainService.GetRegistryProductById(id) : await _productDomainService.GetProductById(id);

                if (response == null)
                {
                    return null;
                }

                var content = MapProduct<ProductViewModel>(response);

                return content;
            }
            catch (Exception e)
            {
                Logger.Error(e, $"Failed to get product by id: {id}");
            }

            return null;
        }

        public Task<IEnumerable<ProductViewModel>> SearchProductsAsync(SearchCriteria searchCriteria) 
        {
            return _SearchProductsAsync(searchCriteria, false);
        }

        public Task<IEnumerable<ProductViewModel>> SearchRegistryProductsAsync(SearchCriteria searchCriteria)
        {
            return _SearchProductsAsync(searchCriteria, true);
        }

        private async Task<IEnumerable<ProductViewModel>> _SearchProductsAsync(SearchCriteria searchCriteria, bool isRegistry)
        {
            try
            {
                IEnumerable<ProductDto> response = isRegistry ? await _productDomainService.SearchRegistryProducts(searchCriteria) : await _productDomainService.SearchProducts(searchCriteria);

                if (!response.Any())
                {
                    return null;
                }

                var content = MapProductResult<ProductViewModel>(response);

                return content;
            }
            catch (Exception e)
            {
                var msg = $"ProductControllerServiceSearch: Failed to get products data: {e.Message}";
                Logger.Error(e, msg);
                throw new Exception(message: msg);
            }
        }

        public async Task<IEnumerable<TestProductViewModel>> GetTestProductsAsync()
        {
            try
            {
                var response = await _productDomainService.GetProducts();

                if (!response.Any())
                {
                    return null;
                }

                var content = MapProductResult<TestProductViewModel>(response);

                return content;
            }
            catch (Exception e)
            {
                var msg = $"ProductControllerServiceSearch: Failed to get products data: {e.Message}";
                Logger.Error(e, msg);
                throw new Exception(message: msg);
            }
        }

        private IEnumerable<T> MapProductResult<T>(IEnumerable<ProductDto> products) 
        {
            return this.Mapper.Map<IEnumerable<T>>(products);
        }

        private T MapProduct<T>(ProductDto product)
        {
            return this.Mapper.Map<T>(product);
        }
    }
}
