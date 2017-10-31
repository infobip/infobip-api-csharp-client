using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model.nc.notify;
using System;

namespace InfobipClientExamples.examples
{
    class NumberContextNotifyExample : Example
    {
        public override void RunExample()
        {
            NumberContextNotify client = new NumberContextNotify(BASIC_AUTH_CONFIGURATION);

            NumberContextRequest request = new NumberContextRequest
            {
                To = TO_LIST,
                NotifyUrl = NOTIFY_URL
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
                Console.WriteLine("Message ID: " + details.MessageId);
                Console.WriteLine("Phone number: " + details.To);
                Console.WriteLine("Message status: " + details.Status.Name);
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
