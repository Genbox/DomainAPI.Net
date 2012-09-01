using System.Collections.Generic;
using RestSharp.Deserializers;

namespace DomainApiNET.Objects.DomainSuggestions
{
    public class DomainSuggestionInfo
    {
        /// <summary>
        /// Start Number
        /// </summary>
        [DeserializeAs(Name = "records_min")]
        public string RecordMin { get; set; }

        /// <summary>
        ///  Ending Number
        /// </summary>
        [DeserializeAs(Name = "records_max")]
        public string RecordMax { get; set; }

        /// <summary>
        /// Highest Page Possible
        /// </summary>
        [DeserializeAs(Name = "page_extreme")]
        public string PageExtreme { get; set; }

        /// <summary>
        /// Highest Possible Record Number
        /// </summary>
        [DeserializeAs(Name = "record_extreme")]
        public string RecordExtreme { get; set; }
        
        /// <summary>
        ///  Maximum Page Number
        /// </summary>
        [DeserializeAs(Name = "page_max")]
        public string PageMax { get; set; }

        /// <summary>
        /// Returns extensions that got accepted in the EXT variable
        /// </summary>
        public string Extn { get; set; }
        public List<DomainSuggestion> DList { get; set; }

        /// <summary>
        /// Records in the display
        /// </summary>
        [DeserializeAs(Name = "records_returned")]
        public string RecordsReturned { get; set; }
        public string Phase1 { get; set; }
        
        /// <summary>
        ///  Minimum Page Number
        /// </summary>
        [DeserializeAs(Name = "page_min")]
        public string PageMin { get; set; }

        /// <summary>
        /// This value is the index back into the session of the current search
        /// </summary>
        public string Time { get; set; }
        public string Phase2 { get; set; }

        /// <summary>
        /// Current Page Number
        /// </summary>
        [DeserializeAs(Name = "page_current")]
        public string PageCurrent { get; set; }
        public string Options { get; set; }
    }
}