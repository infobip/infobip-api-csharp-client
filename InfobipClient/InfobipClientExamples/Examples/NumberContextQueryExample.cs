using Infobip.Api.Model.Nc.Query;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class NumberContextQueryExample : Example
    {
        public override async Task RunExampleAsync()
        {
            NumberContextQuery client = new NumberContextQuery(BASIC_AUTH_CONFIGURATION);

            NumberContextRequest request = new NumberContextRequest
            {
                To = TO_LIST
            };

            NumberContextResponse response = await client.ExecuteAsync(request);

            if (!response.Results.Any())
            {
                Console.WriteLine("No details to display.");
                return;
            }

            foreach (NumberContextResponseDetails details in response.Results)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Phone number: " + details.To);
                Console.WriteLine("MccMnc: " + details.MccMnc);
                Console.WriteLine("Original country prefix: " + details.OriginalNetwork.CountryPrefix);
                Console.WriteLine("Original network prefix: " + details.OriginalNetwork.NetworkPrefix);
                Console.WriteLine("Serving MSC: " + details.ServingMSC);
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
