using System.Threading.Tasks;

namespace GS1US.Framework.Domain.Services.Interfaces
{
    public interface IReferenceDataDomainService
    {
        Task<string> GetAllReferenceData();
        Task<string> GetReferenceDataByVerticalArea(string verticalArea);

    }
}
