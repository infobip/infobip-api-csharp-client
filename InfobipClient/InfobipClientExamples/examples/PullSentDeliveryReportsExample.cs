using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model.sms.mt.reports;
using System;

namespace InfobipClientExamples.examples
{
    class PullSentDeliveryReportsExample : Example
    {
        public override void RunExample()
        {
            GetSentSmsDeliveryReports client = new GetSentSmsDeliveryReports(BASIC_AUTH_CONFIGURATION);

            GetSentSmsDeliveryReportsExecuteContext context = new GetSentSmsDeliveryReportsExecuteContext
            {
                BulkId = null,
                MessageId = null,
                Limit = 10
            };

            SMSReportResponse response = client.Execute(context);

            if (response.Results.Count < 1)
            {
                Console.WriteLine("No logs to display.");
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
