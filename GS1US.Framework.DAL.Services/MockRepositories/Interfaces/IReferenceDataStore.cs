using GS1US.Framework.DAL.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.DAL.Services.MockRepositories.Interfaces
{
    public interface IReferenceDataStore
    {
        IEnumerable<ReferenceTable> GetAllRefenceData();
        IEnumerable<ReferenceTable> GetRefenceData(string applicationArea);
    }
}
