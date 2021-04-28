using System.Collections.Generic;

namespace GS1US.Framework.API.Models.ReferenceDataEntities
{
    public class GDDUnitOfMeasureViewModel
    {
        public IEnumerable<GDDUnitOfMeasureItemViewModel> Items { get; set; }
    }

    public class GDDUnitOfMeasureItemViewModel : GenericPocoViewModel 
    {
    }
}
