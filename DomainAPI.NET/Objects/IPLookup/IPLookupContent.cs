using RestSharp.Deserializers;

namespace DomainApiNET.Objects.IPLookup
{
    public class IPLookupContent
    {
        [DeserializeAs(Name = "ipLocation")]
        public IPLocation IPLocation { get; set; }
    }
}