using GS1US.Framework.Domain.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Domain.Services.Interfaces
{
    public interface IValuesDomainService
    {   
        IEnumerable<ValueStringDto> GetValues();
        
    }
}
