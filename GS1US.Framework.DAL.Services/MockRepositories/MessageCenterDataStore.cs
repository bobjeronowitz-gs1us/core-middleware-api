using GS1US.Framework.DAL.Services.MockRepositories.Interfaces;
using GS1US.Framework.DAL.Services.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.DAL.Services.MockRepositories
{
    public class MessageCenterDataStore : IMessageCenterDataStore
    {   
        public int GetMessageCountForUser()
        {
            return GetRandomNumber();
        }

        public int GetAlertCountForUser()
        {
            return GetRandomNumber();
        }

        public int GetLocationCountForUser()
        {
            return GetRandomNumber();
        }

        public int GetDownloadCountForUser()
        {
            return GetRandomNumber();
        }

        private int GetRandomNumber() 
        {
            Random r = new Random();
            var rand = r.Next(0, 12);
            // return 0 most often
            return rand % 2 == 0 ? 0 : rand;
        }
    }
}
