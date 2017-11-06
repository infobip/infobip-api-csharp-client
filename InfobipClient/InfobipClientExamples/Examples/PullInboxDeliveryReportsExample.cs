using Infobip.Api.Model.Sms.Mo.Logs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class PullInboxDeliveryReportsExample : Example
    {
        public override async Task RunExampleAsync()
        {
            GetReceivedSmsLogs client = new GetReceivedSmsLogs(BASIC_AUTH_CONFIGURATION);

            GetReceivedSmsLogsExecuteContext context = new GetReceivedSmsLogsExecuteContext
            {
                To = null,
                ReceivedSince = null,
                ReceivedUntil = null,
                Limit = 10,
                Keyword = null
            };

            MOLogsResponse response = await client.ExecuteAsync(context);

            if (!response.Results.Any())
            {
                Console.WriteLine("No reports to display.");
                return;
            }

            foreach (MOLog log in response.Results)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Message ID: " + log.MessageId);
                Console.WriteLine("Received at: " + log.ReceivedAt);
                Console.WriteLine("Sender: " + log.From);
                Console.WriteLine("Receiver: " + log.To);
                Console.WriteLine("Message text: " + log.Text);
                Console.WriteLine("Keyword: " + log.Keyword);
                Console.WriteLine("Clean text: " + log.CleanText);
                Console.WriteLine("Sms count: " + log.SmsCount);
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
