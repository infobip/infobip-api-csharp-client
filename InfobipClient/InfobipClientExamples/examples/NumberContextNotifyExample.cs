using Infobip.Api.Model.Nc.Notify;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class NumberContextNotifyExample : Example
    {
        public override async Task RunExampleAsync()
        {
            NumberContextNotify client = new NumberContextNotify(BASIC_AUTH_CONFIGURATION);

            NumberContextRequest request = new NumberContextRequest
            {
                To = TO_LIST,
                NotifyUrl = NOTIFY_URL
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
                Console.WriteLine("Message ID: " + details.MessageId);
                Console.WriteLine("Phone number: " + details.To);
                Console.WriteLine("Message status: " + details.Status.Name);
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
