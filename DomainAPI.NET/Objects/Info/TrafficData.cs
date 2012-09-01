using System.Collections.Generic;

namespace DomainApiNET.Objects.Info
{
    public class TrafficData
    {
        public List<Country> RankByCountry { get; set; }
        public int Rank { get; set; }
        public List<UsageStatistic> UsageStatistics { get; set; }
        public string DataUrl { get; set; }
        public List<ContributingSubdomain> ContributingSubdomains { get; set; }
        public string Type { get; set; }
    }
}