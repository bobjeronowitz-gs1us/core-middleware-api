using AutoMapper;
using GS1US.Framework.DAL.Services.MockRepositories.Interfaces;
using GS1US.Framework.DAL.Services.Entities;
using GS1US.Framework.Domain.Services.Interfaces;
using GS1US.Framework.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GS1US.Framework.Common.Logging;

namespace GS1US.Framework.Domain.Services.Implementations
{
    public class ProductDomainService : IProductDomainService
    {
        private IGS1USAppInsightsLogger Logger { get; }
        private IMapper Mapper { get; }
        private IProductsDataStore ProductDataStore { get; }

        public ProductDomainService(IProductsDataStore productDataStore,
                                            IMapper mapper, IGS1USAppInsightsLogger logger)
        {
            ProductDataStore = productDataStore;
            this.Mapper = mapper;
            this.Logger = logger;
        }

        public Task<IEnumerable<ProductDto>> GetProducts() 
        {
            return _GetProducts(false);
        }

        public Task<IEnumerable<ProductDto>> GetRegistryProducts()
        {
            return _GetProducts(true);
        }

        private async Task<IEnumerable<ProductDto>> _GetProducts(bool isRegistry)
        {
            try
            {
                List<Product> response = isRegistry ? await ProductDataStore.GetRegistryProducts() : await ProductDataStore.GetProducts();

                if (response.Count == 0)
                {
                    return null;
                }

                var content = MapProductResult(response);

                return content;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Failed to get products data");
            }

            return null;
        }

        public Task<ProductDto> GetProductById(int id) 
        {
            return _GetProductById(id, false);
        }


        public Task<ProductDto> GetRegistryProductById(int id)
        {
            return _GetProductById(id, true);
        }

        public async Task<ProductDto> _GetProductById(int id, bool isregistry) 
        {
            try
            {
                var response = isregistry ? await ProductDataStore.GetRegistryProductById(id) : await ProductDataStore.GetProductById(id);

                if (response == null)
                {
                    return null;
                }

                return MapProduct(response);
            }
            catch (Exception e)
            {
                this.Logger.Error(e, "Failed to get products data");
            }

            return null;
        }

        public Task<IEnumerable<ProductDto>> SearchProducts(SearchCriteria searchCriteria) 
        {
            return _SearchProducts(searchCriteria, false);
        }

        public Task<IEnumerable<ProductDto>> SearchRegistryProducts(SearchCriteria searchCriteria)
        {
            return _SearchProducts(searchCriteria, false);
        }

        public async Task<IEnumerable<ProductDto>> _SearchProducts(SearchCriteria searchCriteria, bool isRegistry)
        {
            try
            {
                var response = isRegistry ? await ProductDataStore.SearchRegistryProducts(searchCriteria) : await ProductDataStore.SearchProducts(searchCriteria);

                if (response.Count == 0)
                {
                    return null;
                }

                var content = MapProductResult(response);

                return content;
            }
            catch (Exception e)
            {
                this.Logger.Error(e, "Failed to get products data");
            }

            return null;
        }

        private IEnumerable<ProductDto> MapProductResult(IEnumerable<Product> products)
        {
            return this.Mapper.Map<IEnumerable<ProductDto>>(products);
        }

        private ProductDto MapProduct(Product product)
        {
            return this.Mapper.Map<ProductDto>(product);
        }
    }
}
