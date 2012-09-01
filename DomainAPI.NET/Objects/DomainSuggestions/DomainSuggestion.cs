using RestSharp.Deserializers;

namespace DomainApiNET.Objects.DomainSuggestions
{
    [DeserializeAs(Name = "d")]
    public class DomainSuggestion
    {
        public string Id { get; set; }

        /// <summary>
        /// Current Status for each EXTN
        /// p = registered (parked)
        /// w = registered (has website)
        /// x = registered (no website/has dns)
        /// h = registered (on-hold, generic)
        /// d = available (deleted, had previous owner)
        /// q = available (never registered)
        /// e = registered (on-hold, five day pendingdelete)
        /// g = registered (on-hold, 30 day graceperiod)
        /// </summary>
        [DeserializeAs(Name = "s")]
        public string Status { get; set; }

        /// <summary>
        /// The name part of the domain in this envelope.
        /// </summary>
        [DeserializeAs(Name = "n")]
        public string Name { get; set; }
    }
}