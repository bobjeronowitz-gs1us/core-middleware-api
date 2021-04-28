using GS1US.Framework.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GS1US.Framework.API.ControllerServices.Interfaces
{
    public interface IReferenceDataControllerService
    {
        Task<ReferenceDataViewModel> GetAllReferenceData();
        Task<ReferenceDataViewModel> GetReferenceDataByApplicationArea(string applicationArea);
    }
}
