using System.Collections.Generic;

namespace GS1US.Framework.API.Models.ReferenceDataEntities
{
    public class CountryDataViewModel
    {
        public IEnumerable<CountryDataItemViewModel> Items { get; set; }
    }

    public class CountryDataItemViewModel : GenericPocoViewModel 
    {
    }
}
