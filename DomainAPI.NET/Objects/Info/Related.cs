using System.Collections.Generic;

namespace DomainApiNET.Objects.Info
{
    public class Related
    {
        public List<RelatedLink> RelatedLinks { get; set; }
        public string DataUrl { get; set; }
        public List<CategoryData> Categories { get; set; }
        public string Type { get; set; }
    }
}