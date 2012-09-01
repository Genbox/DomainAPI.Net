using System.Collections.Generic;

namespace DomainApiNET.Objects.Profile
{
    public class domainProfile
    {
        public history history { get; set; }
        public List<name_servers> name_serversList { get; set; }
        public registrant registrant { get; set; }
        public server server { get; set; }
        public seo seo { get; set; }
        public registration registration { get; set; }
    }
}