using GS1US.Framework.API.Models.ReferenceDataEntities;
using System.Collections.Generic;

namespace GS1US.Framework.API.Models
{
    public class ReferenceDataViewModel
    {
        public CountryDataViewModel CountryData { get; set; }
        public UnitOfMeasureViewModel UnitOfMeasure { get; set; }
        public GDDUnitOfMeasureViewModel GDDUnitOfMeasure { get; set; }
        public IndustryDataViewModel Industry { get; set; }
        public LanguageDataViewModel Language { get; set; }
        public LevelCategoryDataViewModel LevelCategory { get; set; }
        public LevelCategoryIndustryDataViewModel LevelCategoryIndustry { get; set; }
        public LevelCategoryRuleDataViewModel LevelCategoryRule { get; set; }
    }
}
