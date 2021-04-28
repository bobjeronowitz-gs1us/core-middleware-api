using GS1US.Framework.DAL.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS1US.Framework.DAL.Services.MockRepositories.Interfaces
{
    public interface IProductsDataStore
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<List<Product>> SearchProducts(SearchCriteria searchCriteria);

        Task<List<Product>> GetRegistryProducts();
        Task<Product> GetRegistryProductById(int id);
        Task<List<Product>> SearchRegistryProducts(SearchCriteria searchCriteria);
    }
}
