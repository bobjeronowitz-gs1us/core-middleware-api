using GS1US.Framework.API.ControllerServices.Interfaces;
using GS1US.Framework.API.Models;
using GS1US.Framework.Common.Logging;
using GS1US.Framework.Domain.Services.Interfaces;
using GS1US.Framework.Domain.Services.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GS1US.Framework.API.ControllerServices
{
    public class ValuesControllerService : IValuesControllerService
    {
        private IGS1USAppInsightsLogger Logger { get; }
        private IValuesDomainService ValuesDomainService { get; }

        public ValuesControllerService(IValuesDomainService valuesDomainService, 
                                        IGS1USAppInsightsLogger logger)
        {
            ValuesDomainService = valuesDomainService;
            Logger = logger;
        }

        List<string> IValuesControllerService.GetValues()
        {
            try
            {
                var response = ValuesDomainService.GetValues();
                

                if (response.Count() == 0)
                {
                    return null;
                }

                return MapValueStrings(response);
            }
            catch (HttpRequestException e)
            {
                Logger.Error(e, "Failed to get values data");
            }

            return null;
        }

        private List<string> MapValueStrings(IEnumerable<ValueStringDto> values) 
        {
            return values.Select(x => x.Name).ToList();
        }
    }
}
