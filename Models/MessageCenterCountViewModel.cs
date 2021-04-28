namespace GS1US.Framework.API.Models
{
    public class MessageCenterCountViewModel
    {
        public string UserId { get; set; }

        public int MessageCount { get; set; }
        public int AlertCount { get; set; }
        public int LocationCount { get; set; }
        public int DownloadCount { get; set; }
    }
}
