using System.Collections.Generic;
using RestSharp.Deserializers;

namespace DomainApiNET.Objects.SecondaryMarket
{
    public class SecondaryMarketInfo
    {
        [DeserializeAs(Name = "records_min")]
        public string RecordMin { get; set; }
        public string F7 { get; set; }

        [DeserializeAs(Name = "records_max")]
        public string RecordMax { get; set; }

        [DeserializeAs(Name = "page_max")]
        public string PageMax { get; set; }
        public string Querytime { get; set; }
        public string Bn { get; set; }

        [DeserializeAs(Name = "records_returned")]
        public string RecordsReturned { get; set; }
        public string Time { get; set; }

        [DeserializeAs(Name = "page_current")]
        public string PageCurrent { get; set; }
        public string Pool { get; set; }
        public string Page { get; set; }
        public string Exactfirst { get; set; }
        public string Bh { get; set; }
        public string Left { get; set; }
        public string Bc { get; set; }
        public string Right { get; set; }
        public string Options { get; set; }
        public string Errlev { get; set; }

        [DeserializeAs(Name = "page_extreme")]
        public string PageExtreme { get; set; }

        [DeserializeAs(Name = "record_extreme")]
        public string RecordExtreme { get; set; }
        public string Extn { get; set; }
        public List<SecondaryMarketDomain> DList { get; set; }
        public string Rows { get; set; }

        [DeserializeAs(Name = "page_min")]
        public string PageMin { get; set; }
        public string Q { get; set; }
        public string Ordered { get; set; }

        [DeserializeAs(Name = "did_you_mean")]
        public string DidYouMean { get; set; }
    }
}