using Infobip.Api.Model.Sms.Mt.Logs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class GetSentLogsExample : Example
    {
        public override async Task RunExampleAsync()
        {
            GetSentSmsLogs client = new GetSentSmsLogs(BASIC_AUTH_CONFIGURATION);
            GetSentSmsLogsExecuteContext context = new GetSentSmsLogsExecuteContext()
            {
                From = null,
                To = null,
                BulkId = null,
                MessageId = null,
                GeneralStatus = null,
                SentSince = null,
                SentUntil = null,
                Limit = 10,
                Mcc = null,
                Mnc = null
            };
            SMSLogsResponse response = await client.ExecuteAsync(context);

            if (!response.Results.Any())
            {
                Console.WriteLine("No logs to display.");
                return;
            }

            foreach (SMSLog log in response.Results)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Message ID: " + log.MessageId);
                Console.WriteLine("Sent at: " + log.SentAt);
                Console.WriteLine("Sender: " + log.From);
                Console.WriteLine("Receiver: " + log.To);
                Console.WriteLine("Message text: " + log.Text);
                Console.WriteLine("Status: " + log.Status.Name);
                Console.WriteLine("Price: " + log.Price.PricePerMessage + " " + log.Price.Currency);
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
