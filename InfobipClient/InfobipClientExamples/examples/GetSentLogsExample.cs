using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model.sms.mt.logs;
using System;

namespace InfobipClientExamples.examples
{
    class GetSentLogsExample : Example
    {
        public override void RunExample()
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
            SMSLogsResponse response = client.Execute(context);

            if (response.Results.Count < 1)
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
