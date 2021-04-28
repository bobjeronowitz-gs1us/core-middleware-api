using GS1US.Framework.DAL.Services.Interfaces;
using GS1US.Framework.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace GS1US.Framework.Domain.Services.Implementations
{
    public class ReferenceDataDomainService : IReferenceDataDomainService
    {   
        private IReferenceDataAccessService ReferenceDataDALService { get; }

        public ReferenceDataDomainService(IReferenceDataAccessService referenceDataDALService)
        {
            this.ReferenceDataDALService = referenceDataDALService;
        }

        public async Task<string> GetAllReferenceData()
        {
            return await GetReferenceData("ALL");
        }

        public async Task<string> GetReferenceDataByVerticalArea(string verticalArea)
        { 
            return await GetReferenceData(verticalArea);
        }

        private async Task<string> GetReferenceData(string verticalArea)
        {
            string response;
            if (verticalArea == "ALL")
                response = await this.ReferenceDataDALService.GetAllReferenceData();
            else
                response = await this.ReferenceDataDALService.GetReferenceDataByVertical(verticalArea);

            if (response == null)
                return null;

            return response;
        }

    }
}
