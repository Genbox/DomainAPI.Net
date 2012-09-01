using System.Collections.Generic;

namespace DomainApiNET.Objects.Info
{
    public class ContentData
    {
        public List<Keyword> Keywords { get; set; }
        public string OwnedDomains { get; set; }
        public string AdultContent { get; set; }
        public string DataUrl { get; set; }
        public Speed Speed { get; set; }
        public Language Language { get; set; }
        public string LinksInCount { get; set; }
        public SiteData SiteData { get; set; }
        public string Type { get; set; }
    }
}