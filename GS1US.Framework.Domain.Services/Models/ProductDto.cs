using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Domain.Services.Models
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string PackagingLevel { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime createdDate { get; set; }
        public bool Shared { get; set; }
        public ProductLicenseDto License { get; set; }
    }
}
