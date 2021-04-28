using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.DAL.Services.Entities
{
    public class ReferenceTable
    {
        public string TableName { get; set; }
        
        public IEnumerable<string> ApplicationArea {get; set;}

        public IEnumerable<GenericEntity> Items { get; set; }
    }
}
