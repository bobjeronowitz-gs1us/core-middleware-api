using System.Collections.Generic;

namespace GS1US.Framework.API.Models.ReferenceDataEntities
{
    public class LanguageDataViewModel
    {
        public IEnumerable<LanguageDataItemViewModel> Items { get; set; }
    }

    public class LanguageDataItemViewModel : GenericPocoViewModel 
    {
    }
}
