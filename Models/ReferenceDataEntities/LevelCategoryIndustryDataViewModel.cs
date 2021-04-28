using System.Collections.Generic;

namespace GS1US.Framework.API.Models.ReferenceDataEntities
{
    public class LevelCategoryIndustryDataViewModel
    {
        public IEnumerable<LevelCategoryIndustryItemViewModel> Items { get; set; }
    }

    public class LevelCategoryIndustryItemViewModel : GenericPocoViewModel 
    {
    }
}
