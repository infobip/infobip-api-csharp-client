using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model.nc.query;
using System;

namespace InfobipClientExamples.examples
{
    class NumberContextQueryExample : Example
    {
        public override void RunExample()
        {
            NumberContextQuery client = new NumberContextQuery(BASIC_AUTH_CONFIGURATION);

            NumberContextRequest request = new NumberContextRequest
            {
                To = TO_LIST
            };

            NumberContextResponse response = client.Execute(request);

            if (response.Results.Count < 1)
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
