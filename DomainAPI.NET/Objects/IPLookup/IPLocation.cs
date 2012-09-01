namespace DomainApiNET.Objects.IPLookup
{
    public class IPLocation
    {
        /// <summary>
        ///  Returns location's region.
        /// </summary>
        public string region { get; set; }

        /// <summary>
        ///	 Returns location's country code.
        /// </summary>
        public string country_short { get; set; }

        /// <summary>
        /// Returns the Internet service provider.
        /// </summary>
        public string isp { get; set; }

        /// <summary>
        /// Returns flag of the country.
        /// </summary>
        public string img { get; set; }

        /// <summary>
        /// Returns location's city.
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// Returns location's country.
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// Returns ip.
        /// </summary>
        public string ip { get; set; }
    }
}