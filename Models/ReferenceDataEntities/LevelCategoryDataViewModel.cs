using System.Collections.Generic;

namespace GS1US.Framework.API.Models.ReferenceDataEntities
{
    public class LevelCategoryDataViewModel
    {
        public IEnumerable<LevelCategoryItemViewModel> Items { get; set; }
    }

    public class LevelCategoryItemViewModel  : GenericPocoViewModel 
    {
    }
}
