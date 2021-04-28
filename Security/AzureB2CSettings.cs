using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.Security
{
    public class AzureB2CSettings
    {   
        public string ClientId { get; set; }
        public string Policy { get; set; }
        public string Tenant { get; set; }
        public string TenantUri { get; set; }
        public string AuthorityUri { get; set; }
    }
}
