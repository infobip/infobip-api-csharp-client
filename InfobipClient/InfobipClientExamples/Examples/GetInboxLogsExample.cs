using Infobip.Api.Model.Sms.Mo.Logs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class GetInboxLogsExample : Example
    {
        public override async Task RunExampleAsync()
        {
            GetReceivedSmsLogs client = new GetReceivedSmsLogs(BASIC_AUTH_CONFIGURATION);
            GetReceivedSmsLogsExecuteContext context = new GetReceivedSmsLogsExecuteContext()
            {
                To = null,
                Limit = 10,
                ReceivedSince = null,
                ReceivedUntil = null,
                Keyword = null
            };
            MOLogsResponse response = await client.ExecuteAsync(context);

            if (!response.Results.Any())
            {
                Console.WriteLine("No logs to display.");
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
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
