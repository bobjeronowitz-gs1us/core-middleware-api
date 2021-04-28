using System;
using System.Collections.Generic;
using System.Text;

namespace GS1US.Framework.Domain.Services.Models
{
    public class MessageCenterCountDto
    {
        public string UserId { get; set; }

        public int MessageCount { get; set; }
        public int AlertCount { get; set; }
        public int LocationCount { get; set; }
        public int DownloadCount { get; set; }
    }
}
