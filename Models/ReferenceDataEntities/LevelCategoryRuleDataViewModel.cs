using System.Collections.Generic;

namespace GS1US.Framework.API.Models.ReferenceDataEntities
{
    public class LevelCategoryRuleDataViewModel
    {
        public IEnumerable<LevelCategoryRuleItemViewModel> Items { get; set; }
    }

    public class LevelCategoryRuleItemViewModel : GenericPocoViewModel 
    {
    }
}
