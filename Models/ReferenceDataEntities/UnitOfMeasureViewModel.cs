using System.Collections.Generic;

namespace GS1US.Framework.API.Models.ReferenceDataEntities
{
    public class UnitOfMeasureViewModel
    {
        public IEnumerable<UnitOfMeasureItemViewModel> Items { get; set; }
    }

    public class UnitOfMeasureItemViewModel : GenericPocoViewModel 
    {
    }
}
