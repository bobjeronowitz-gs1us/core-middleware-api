using System.Collections.Generic;

namespace GS1US.Framework.API.Models
{
    public class ReferenceEntityViewModel
    {

        public string EntityName { get; set; }


        public IEnumerable<GenericPocoViewModel> Items { get; set; }
    }
}
