using System.Collections.Generic;

namespace GS1US.Framework.Domain.Services.Models
{
    public class ReferenceTableDto
    {
        public string TableName { get; set; }
        
        public IEnumerable<string> ApplicationArea {get; set;}

        public IEnumerable<GenericPocoDto> Items { get; set; }
    }
}
