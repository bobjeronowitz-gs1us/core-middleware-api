using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.DAL.Services.Entities
{
    public class GenericEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int? NumericCode { get; set; }

        public int SortOrder { get; set; }
        public bool? ShowInUI {get; set;}
        public bool IsActive { get; set; }
        
    }
}
