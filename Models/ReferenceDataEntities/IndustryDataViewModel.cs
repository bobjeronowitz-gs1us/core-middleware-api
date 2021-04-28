using System.Collections.Generic;

namespace GS1US.Framework.API.Models.ReferenceDataEntities
{
    public class IndustryDataViewModel
    {
        public IEnumerable<IndustryDataItemViewModel> Items { get; set; }
    }

    public class IndustryDataItemViewModel : GenericPocoViewModel 
    {
    }
}
