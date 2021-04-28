using GS1US.Framework.API.Models;
using GS1US.Framework.DAL.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.ControllerServices.Interfaces
{
    public interface IProductControllerService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync();
        Task<ProductViewModel> GetProductById(int id);
        Task<IEnumerable<ProductViewModel>> SearchProductsAsync(SearchCriteria searchCriteria);
        Task<IEnumerable<ProductViewModel>> GetRegistryProductsAsync();
        Task<ProductViewModel> GetRegistryProductById(int id);
        Task<IEnumerable<ProductViewModel>> SearchRegistryProductsAsync(SearchCriteria searchCriteria);
        Task<IEnumerable<TestProductViewModel>> GetTestProductsAsync();
    }
}
