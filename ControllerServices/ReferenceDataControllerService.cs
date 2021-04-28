using AutoMapper;
using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.API.Models;
using GS1US.Framework.API.Models.ReferenceDataEntities;
using GS1US.Framework.Common.Caching;
using GS1US.Framework.Common.DataSerializer;
using GS1US.Framework.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS1US.Framework.API.ControllerServices
{
    public class ReferenceDataControllerService : IReferenceDataControllerService
    {
        private const string REFDATA_CACHE_KEY = "REF_DATA_";

        private IAppCacheService AppCacheService { get; }
        private IReferenceDataDomainService ReferenceDomainService { get; }
        private IDataSerializer DataSerializer { get; }
        private IMapper Mapper { get; }

        public ReferenceDataControllerService(IReferenceDataDomainService referenceDomainService,
                                        IAppCacheService appCacheService,
                                         IMapper mapper,
                                         IDataSerializer dataSerializer)
        {
            this.AppCacheService = appCacheService;
            ReferenceDomainService = referenceDomainService;
            this.Mapper = mapper;
            this.DataSerializer = dataSerializer;
        }

        public async Task<ReferenceDataViewModel> GetAllReferenceData()
        {   
            return await GetReferenceData("ALL");
        }

        public async Task<ReferenceDataViewModel> GetReferenceDataByApplicationArea(string applicationArea)
        {
            return await GetReferenceData(applicationArea);
        }

        private async Task<ReferenceDataViewModel> GetReferenceData(string applicationArea)
        {
            // cache for use
            var cacheKey = $"{REFDATA_CACHE_KEY}{applicationArea}";
            var refData = this.AppCacheService.GetCachedRecord<ReferenceEntityCollection>(cacheKey);
            if (null != refData)
                return ConvertToDictionaryObject(refData);

            string response;
            if (applicationArea == "ALL")
                response = await ReferenceDomainService.GetAllReferenceData();
            else 
                response = await ReferenceDomainService.GetReferenceDataByVerticalArea(applicationArea);

            if (response == null)
                return null;
            
            var refTables = this.DataSerializer.ConvertToJsonObject<ReferenceEntityCollection>(response);

            // cache the return data - currently not timestamped
            if (null != refTables)
                this.AppCacheService.CacheRecord<ReferenceEntityCollection>(cacheKey, refTables);

            return ConvertToDictionaryObject(refTables);
        }

        private ReferenceDataViewModel ConvertToDictionaryObject(ReferenceEntityCollection entityCollection) 
        {
            var dictionaryObject = new ReferenceDataViewModel();
            foreach (var refTable in entityCollection.Entities) 
            {
                switch (refTable.EntityName) 
                {
                    case "CountryData":
                        dictionaryObject.CountryData = new CountryDataViewModel() { Items = MapItems<CountryDataItemViewModel>(refTable.Items) };
                        break;
                    case "GDDUnitOfMeasure":
                        dictionaryObject.GDDUnitOfMeasure = new GDDUnitOfMeasureViewModel() { Items = MapItems<GDDUnitOfMeasureItemViewModel>(refTable.Items) };
                        break;
                    case "UnitOfMeasure":
                        dictionaryObject.UnitOfMeasure = new UnitOfMeasureViewModel() { Items = MapItems<UnitOfMeasureItemViewModel>(refTable.Items) };
                        break;
                    case "Industry":
                        dictionaryObject.Industry = new IndustryDataViewModel() { Items = MapItems<IndustryDataItemViewModel>(refTable.Items) };
                        break;
                    case "Language":
                        dictionaryObject.Language = new LanguageDataViewModel() { Items = MapItems<LanguageDataItemViewModel>(refTable.Items) };
                        break;
                    case "LevelCategory":
                        dictionaryObject.LevelCategory = new LevelCategoryDataViewModel() { Items = MapItems<LevelCategoryItemViewModel>(refTable.Items) };
                        break;
                    case "LevelCategoryIndustry":
                        dictionaryObject.LevelCategoryIndustry = new LevelCategoryIndustryDataViewModel() { Items = MapItems<LevelCategoryIndustryItemViewModel>(refTable.Items) };
                        break;
                    case "LevelCategoryRule":
                        dictionaryObject.LevelCategoryRule = new LevelCategoryRuleDataViewModel() { Items = MapItems<LevelCategoryRuleItemViewModel>(refTable.Items) };
                        break;
                }
            }

            return dictionaryObject;
        }

        private IEnumerable<T> MapItems<T>(IEnumerable<GenericPocoViewModel> genericListItems)
        {
            return this.Mapper.Map<IEnumerable<T>>(genericListItems);
        }

    }
}
