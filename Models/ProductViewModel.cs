using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string BrandName { get; set; }
        public string CompanyName { get; set; }
        public string PackagingLevel { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public DateTime lastUpdatedDate { get; set; }
        public DateTime createdDate { get; set; }
        public string Description { get; set; }
        public bool Shared { get; set; }
    }
}
