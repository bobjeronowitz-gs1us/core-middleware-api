using AutoMapper;
using GS1US.Framework.DAL.Services.MockRepositories.Interfaces;
using GS1US.Framework.DAL.Services.Entities;
using GS1US.Framework.Domain.Services.Interfaces;
using GS1US.Framework.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GS1US.Framework.Common.Logging;

namespace GS1US.Framework.Domain.Services.Implementations
{
    public class ValuesDomainService : IValuesDomainService
    {
        private IGS1USAppInsightsLogger Logger { get; }
        private IMapper Mapper { get; }
        private IValuesDataStore ValuesDataStore { get; }

        public ValuesDomainService(IValuesDataStore valuesDataStore, 
                                    IMapper mapper, IGS1USAppInsightsLogger logger)
        {
            this.ValuesDataStore = valuesDataStore;
            this.Mapper = mapper;
            this.Logger = logger;
        }

        public IEnumerable<ValueStringDto> GetValues()
        {
            try
            {
                var response = this.ValuesDataStore.GetValues();

                if (response.Count == 0)
                {
                    return null;
                }

                var content = MapValuesResult(response);

                return content;
            }
            catch (Exception e)
            {
                this.Logger.Error(e, "Failed to get values data");
            }

            return null;
        }

        private IEnumerable<ValueStringDto> MapValuesResult(IEnumerable<ValuesString> values)
        {
            return this.Mapper.Map<IEnumerable<ValueStringDto>>(values);
        }
    }
}
