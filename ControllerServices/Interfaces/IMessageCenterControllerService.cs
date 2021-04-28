using GS1US.Framework.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GS1US.Framework.API.ControllerServices.Interfaces
{
    public interface IMessageCenterControllerService
    {
        MessageCenterCountViewModel GetMessageCenterCountsForUser(string userId);
    }
}
