using Infobip.Api.Model.Sms.Mt.Reports;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class PullSentDeliveryReportsExample : Example
    {
        public override async Task RunExampleAsync()
        {
            GetSentSmsDeliveryReports client = new GetSentSmsDeliveryReports(BASIC_AUTH_CONFIGURATION);

            GetSentSmsDeliveryReportsExecuteContext context = new GetSentSmsDeliveryReportsExecuteContext
            {
                BulkId = null,
                MessageId = null,
                Limit = 10
            };

            SMSReportResponse response = await client.ExecuteAsync(context);

            if (!response.Results.Any())
            {
                Console.WriteLine("No reports to display.");
                return;
            }

            foreach (SMSReport log in response.Results)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Message ID: " + log.MessageId);
                Console.WriteLine("Sent at: " + log.SentAt);
                Console.WriteLine("Receiver: " + log.To);
                Console.WriteLine("Status: " + log.Status.Name);
                Console.WriteLine("Price: " + log.Price.PricePerMessage + " " + log.Price.Currency);
            }
            Console.WriteLine("-------------------------------");
        }
    }
}
