# DomainAPI.NET - A full implementation of the DomainAPI.com API

### Features

* Using RestSharp (http://restsharp.org) to deserialize the DomainApi.com XML into objects
* Domain Availability
* Domain Info
* Domain Secondary Market
* Domain Suggestion
* Domain Whois
* Homepage Thumbnail
* IP Address Lookup

### Examples

Here is the simplest form of getting data from DomainApi:

```csharp
static void Main(string[] args)
{
	const string domainString = "google.com";

	DomainAPI domainApi = new DomainAPI(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

	Console.WriteLine("Checking avaliability of " + domainString);
	AvailabilityResult results = domainApi.CheckAvailability(domainString, DomainAvailabilityType.Advanced, null, new[] { TLD.com_tr, TLD.coop });

	foreach (Domain domain in results.Content.DomainList)
	{
		Console.WriteLine(domain.Name + " is " + domain.Status);
	}

	Console.WriteLine("Getting info about " + domainString);

	DomainInfoResult domainInfo = domainApi.DomainInfo(domainString);
	Console.WriteLine("Domain is in locale: " + domainInfo.Content.Info.ContentData.Language.Locale + " and has " + domainInfo.Content.Info.ContentData.LinksInCount + " links to it.");

}
```

Output:
```
Checking avaliability of google.com
google.com.tr is taken
google.coop is free

Getting info about google.com
Domain is in locale: en and has 4788643 links to it.
```

For more examples, take a look at the DomainApi.NET Client included in the proejct.