using GS1US.Framework.DAL.Services.Entities;
using GS1US.Framework.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GS1US.Framework.Domain.Services.Interfaces
{
    public interface IProductDomainService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int id);
        Task<IEnumerable<ProductDto>> SearchProducts(SearchCriteria searchCriteria);
        Task<IEnumerable<ProductDto>> GetRegistryProducts();
        Task<ProductDto> GetRegistryProductById(int id);
        Task<IEnumerable<ProductDto>> SearchRegistryProducts(SearchCriteria searchCriteria);

    }
}
