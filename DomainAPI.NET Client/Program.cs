using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using DomainApiNET;
using DomainApiNET.Enums;
using DomainApiNET.Objects.Avaliability;
using DomainApiNET.Objects.DomainSuggestions;
using DomainApiNET.Objects.IPLookup;
using DomainApiNET.Objects.Info;
using DomainApiNET.Objects.SecondaryMarket;

namespace DomainApiNETClient
{
    class Program
    {
        static void Main(string[] args)
        {
            const string domainString = "google.com";
            const string ipString = "173.194.32.40";
            DomainAPI domainApi = new DomainAPI(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

            Console.WriteLine("Checking avaliability of " + domainString);
            List<AvailabilityDomain> results = domainApi.CheckAvailability(domainString, DomainAvailabilityType.Advanced, null, new[] { TLD.com_tr, TLD.coop });

            foreach (var domain in results)
            {
                Console.WriteLine(domain.Name + " is " + domain.Status);
            }

            Console.WriteLine();
            Console.WriteLine("Getting info about " + domainString);
            DomainInfo domainInfo = domainApi.DomainInfo(domainString);
            Console.WriteLine("Domain is in locale: " + domainInfo.ContentData.Language.Locale + " and has " + domainInfo.ContentData.LinksInCount + " links to it.");

            Console.WriteLine();
            Console.WriteLine("Getting secondary market info about " + domainString);
            SecondaryMarketInfo secondaryMarketResults = domainApi.SecondaryMarket(domainString);

            if (secondaryMarketResults != null)
            {
                foreach (var domain in secondaryMarketResults.DList)
                {
                    Console.WriteLine(domain.N);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Getting suggestions from " + domainString);
            DomainSuggestionInfo domainSuggestionsResults = domainApi.DomainSuggestions(domainString, 20);

            if (domainSuggestionsResults != null)
            {
                foreach (var domain in domainSuggestionsResults.DList)
                {
                    Console.WriteLine(domain.Name);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Getting info about " + ipString);
            IPLocation ipLookupResults = domainApi.IPLookup(ipString);
            Console.WriteLine("Located in " + ipLookupResults.city);

            Console.WriteLine();
            Console.WriteLine("Getting whois of " + domainString);
            string whois = domainApi.DomainWhois(domainString);
            Console.WriteLine("Whois: " + whois.Substring(0, 70) + " ...");

            Console.WriteLine();
            Console.WriteLine("Getting thumbnail of " + domainString);
            Bitmap data = domainApi.HomepageThumbnail(domainString);
            data.Save("lol.png", ImageFormat.Png);
            Console.WriteLine("Got an image of " + data.Size);

            Console.WriteLine("Press a key to continue.");
            Console.ReadLine();
        }
    }
}