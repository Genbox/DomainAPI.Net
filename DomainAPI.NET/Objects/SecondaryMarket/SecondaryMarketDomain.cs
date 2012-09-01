using RestSharp.Deserializers;

namespace DomainApiNET.Objects.SecondaryMarket
{
    [DeserializeAs(Name = "d")]
    public class SecondaryMarketDomain
    {
        public string Id { get; set; }
        public string Price { get; set; }
        public string Dmoz { get; set; }
        public string N { get; set; }
        public string Partner { get; set; }

        [DeserializeAs(Name = "starting_price")]
        public string StartingPrice { get; set; }
        public string Tld { get; set; }
        public string Yahoo { get; set; }
    }
}