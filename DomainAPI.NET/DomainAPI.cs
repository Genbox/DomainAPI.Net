using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using DomainApiNET.Enums;
using DomainApiNET.Misc;
using DomainApiNET.Objects.Avaliability;
using DomainApiNET.Objects.DomainSuggestions;
using DomainApiNET.Objects.Errors;
using DomainApiNET.Objects.HomepageThumbnail;
using DomainApiNET.Objects.IPLookup;
using DomainApiNET.Objects.Info;
using DomainApiNET.Objects.SecondaryMarket;
using DomainApiNET.Objects.Whois;
using RestSharp;
using RestSharp.Deserializers;
using Region = DomainApiNET.Enums.Region;

namespace DomainApiNET
{
    public class DomainAPI
    {
        private static RestClient _client = new RestClient();
        private string _username;
        private string _password;

        public DomainAPI(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Username must not be filled out.", "username");

            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Password must not be filled out.", "password");

            _username = username;
            _password = password;

            _client.BaseUrl = "http://api.domainapi.com/v1/";
        }

        /// <summary>
        /// Checks the availability of the domain provided.
        /// </summary>
        /// <param name="domain">The domain</param>
        /// <param name="type">Choose the type of the availability request: region or advanced.
        /// Region, allow you to search the availability of a domain on a list of regions.
        /// Advanced allow you to choose a list of TLD.</param>
        /// <param name="regions">List of regions wanted, if you choose the type 'region'.</param>
        /// <param name="tlds">List of tlds wanted, if you choose the type 'advanced'.</param>
        /// <returns></returns>
        public List<AvailabilityDomain> CheckAvailability(string domain, DomainAvailabilityType type = DomainAvailabilityType.None, Region[] regions = null, TLD[] tlds = null)
        {
            if (type == DomainAvailabilityType.Advanced && (tlds == null || tlds.Length <= 0))
                throw new ArgumentException("You must include at least one TLD when using DomainAvailabilityType.Advanced", "tlds");

            if (type == DomainAvailabilityType.Region && (regions == null || regions.Length <= 0))
                throw new ArgumentException("You must include at least one region when using DomainAvailabilityType.Region", "regions");

            RestRequest request = CreateRequest("availability", domain);

            //Not required
            if (type != DomainAvailabilityType.None)
                request.AddParameter("type", type.ToString().ToLower());

            if (regions != null)
            {
                foreach (Region region in regions)
                {
                    request.AddParameter("regions", region.GetStringValue());
                }
            }

            if (tlds != null)
            {
                foreach (TLD tld in tlds)
                {
                    request.AddParameter("tlds", tld.GetStringValue().ToLower());
                }
            }

            AvailabilityResult availabilityResult = GetResults<AvailabilityResult>(request);
            if (availabilityResult != null && availabilityResult.Content != null && availabilityResult.Content.DomainList != null)
                return availabilityResult.Content.DomainList;

            return null;
        }

        /// <summary>
        /// Rapidly retrieve data related to the hosted web page of a specific domain.
        /// Such information include traffic, historical traffic data, traffic ranking including country specific ranking, displayed name, average load time, related sub-domain, linked websites… and more information essential when analyzing a domain name in term of its past or current usage and potential.
        /// As for now the main source of data for this API is Alexa.
        /// </summary>
        /// <param name="domain"></param>
        public DomainInfo DomainInfo(string domain)
        {
            RestRequest request = CreateRequest("info", domain);
            DomainInfoResult domainInfoResult = GetResults<DomainInfoResult>(request);

            if (domainInfoResult != null && domainInfoResult.Content != null && domainInfoResult.Content.Info != null)
                return domainInfoResult.Content.Info;

            return null;
        }

        /// <summary>
        /// Secondary Market allows you to quickly lookup whether domain names are listed on the major aftermarkets and provides you with all the necessary information.
        /// This API does retrieve semantic alternatives, it is a fast lookup on pattern match towards NameMedia / Afternic / Buydomains and Sedo databases.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public SecondaryMarketInfo SecondaryMarket(string domain)
        {
            RestRequest request = CreateRequest("marketplace", domain);
            SecondaryMarketResults secondaryMarketResults = GetResults<SecondaryMarketResults>(request);

            if (secondaryMarketResults != null && secondaryMarketResults.Content != null && secondaryMarketResults.Content.Info != null)
                return secondaryMarketResults.Content.Info;

            return null;
        }

        /// <summary>
        /// Domain Suggestion API is a name spinning API that gives you available gTLDs for a given name.
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="rows"> </param>
        /// <param name="hyphenFilter">This will exclude domains with hyphens or allow them.</param>
        /// <param name="allowNumbers">This will exclude domains with numbers or allow them.</param>
        /// <returns></returns>
        public DomainSuggestionInfo DomainSuggestions(string domain, int? rows = 20, Hyphen hyphenFilter = Hyphen.Unknown, YesNo allowNumbers = YesNo.Unknown)
        {
            if (rows != null && (rows < 20 || rows > 100))
                throw new ArgumentException("Rows must be between 20 and 100", "rows");

            RestRequest request = CreateRequest("search_engine", domain);

            if (rows != null)
                request.AddParameter("rows", rows);

            if (hyphenFilter != Hyphen.Unknown)
                request.AddParameter("bc", hyphenFilter.GetStringValue());

            if (allowNumbers != YesNo.Unknown)
                request.AddParameter("bn", allowNumbers.GetStringValue());

            DomainSuggestionsResults domainSuggestionsResults = GetResults<DomainSuggestionsResults>(request);

            if (domainSuggestionsResults != null && domainSuggestionsResults.Content != null && domainSuggestionsResults.Content.Info != null)
                return domainSuggestionsResults.Content.Info;

            return null;
        }

        /// <summary>
        /// With the domainAPI IP Location service, find out the geographic location of a specific IP address. Whether searching for a domain or an IP, domainAPI IP Location will provide you with the related geographic location and Network allocation in no time.
        /// </summary>
        /// <param name="ip">The IP to lookup</param>
        /// <returns>Information about the IP</returns>
        public IPLocation IPLookup(string ip)
        {
            RestRequest request = CreateRequest("ip_location", ip);

            IPLookupResults ipLookupResults = GetResults<IPLookupResults>(request);
            if (ipLookupResults != null && ipLookupResults.Content != null && ipLookupResults.Content.IPLocation != null)
                return ipLookupResults.Content.IPLocation;

            return null;
        }

        /// <summary>
        /// Using whois query and response protocol, whois provides contact details linked to a given registered domain name.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public string DomainWhois(string domain)
        {
            RestRequest request = CreateRequest("whois", domain);

            DomainWhoisRepsonse response = GetResults<DomainWhoisRepsonse>(request);
            if (response != null && response.Content != null && !string.IsNullOrEmpty(response.Content.whois))
                return response.Content.whois;

            return null;
        }

        /// <summary>
        /// Create a thumbnail of the website.
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public Bitmap HomepageThumbnail(string domain, ThumbnailSize size = ThumbnailSize.Unknown)
        {
            RestRequest request = CreateRequest("thumbnail", domain);

            if (size != ThumbnailSize.Unknown)
                request.AddParameter("return", size.ToString().ToLower());

            HomepageThumbnailResponse response = GetResults<HomepageThumbnailResponse>(request);
            if (response != null && response.Content != null && !string.IsNullOrEmpty(response.Content.Thumbnail))
            {
                string data = response.Content.Thumbnail.Split(',').Last();
                byte[] rawData = Convert.FromBase64String(data);
                MemoryStream stream = new MemoryStream(rawData);
                return new Bitmap(stream);
            }

            return null;
        }

        private RestRequest CreateRequest(string method, string domain)
        {
            if (string.IsNullOrEmpty(domain))
                throw new ArgumentException("Domain or IP must not be empty", "domain");

            return new RestRequest(method + "/xml/" + domain, Method.GET);
        }

        private T GetResults<T>(RestRequest request)
        {
            request.AddHeader("Authorization", "Basic " + ToBase64(_username + ":" + _password));

            RestResponse response = (RestResponse)_client.Execute(request);
            IDeserializer deserializer = new XmlAttributeDeserializer();

            //First try to deserialize it as an error
            ErrorResponse errorResponse = deserializer.Deserialize<ErrorResponse>(response);
            if (errorResponse != null && errorResponse.Error != null)
                errorResponse = null;

            return deserializer.Deserialize<T>(response);
        }

        private string ToBase64(string data)
        {
            byte[] rawData = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(rawData);
        }
    }
}