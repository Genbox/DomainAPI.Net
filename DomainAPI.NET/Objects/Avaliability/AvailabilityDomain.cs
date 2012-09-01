using RestSharp.Deserializers;

namespace DomainApiNET.Objects.Avaliability
{
    public class AvailabilityDomain
    {
        [DeserializeAs(Name = "status")]
        public string Status { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
    }
}