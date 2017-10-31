using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model.sms.mo.logs;
using System;

namespace InfobipClientExamples.examples
{
    class GetInboxLogsExample : Example
    {
        public override void RunExample()
        {
            GetReceivedSmsLogs client = new GetReceivedSmsLogs(BASIC_AUTH_CONFIGURATION);
            GetReceivedSmsLogsExecuteContext context = new GetReceivedSmsLogsExecuteContext()
            {
                To = null,
                ReceivedSince = null,
                ReceivedUntil = null,
                Limit = 10,
                Keyword = null
            };
            MOLogsResponse response = client.Execute(context);

            if (response.Results.Count < 1)
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
