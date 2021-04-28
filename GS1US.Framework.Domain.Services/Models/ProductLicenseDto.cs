using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Domain.Services.Models
{
    public class ProductLicenseDto
    {
        public string BrandName { get; set; }
        public string Company { get; set; }
        public string CompanyPrefix { get; set; }
        public string CountryCode { get; set; }
    }
}
