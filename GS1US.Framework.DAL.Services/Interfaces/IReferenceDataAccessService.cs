using System.Threading.Tasks;

namespace GS1US.Framework.DAL.Services.Interfaces
{
    public interface IReferenceDataAccessService
    {
        Task<string> GetAllReferenceData();
        Task<string> GetReferenceDataByVertical(string verticalCategory);
    }
}
