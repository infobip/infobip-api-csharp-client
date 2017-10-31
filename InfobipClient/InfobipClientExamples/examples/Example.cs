using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.config;
using InfobipClient.infobip.api.model.sms.mt.reports;
using System;
using System.Collections.Generic;

namespace InfobipClientExamples.examples
{
    abstract class Example
    {
        protected static readonly string BASE_URL = "https://api.infobip.com/";
        protected static readonly string USERNAME = "USERNAME";
        protected static readonly string PASSWORD = "PASSWORD";

        protected static readonly BasicAuthConfiguration BASIC_AUTH_CONFIGURATION = new BasicAuthConfiguration(BASE_URL, USERNAME, PASSWORD);

        protected static readonly string FROM = "InfoSMS";
        protected static readonly string TO = "PHONE";
        protected static readonly List<string> TO_LIST = new List<string>(1) { "PHONE" };
        protected static readonly string MESSAGE_TEXT = "This is an example message sent via C# example lib.";

        protected static readonly string NOTIFY_URL = "https://notify.me";

        public abstract void RunExample();

        protected static void GetSmsReport(string messageId)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Fetching report...");

            GetSentSmsDeliveryReports reportsClient = new GetSentSmsDeliveryReports(BASIC_AUTH_CONFIGURATION);
            GetSentSmsDeliveryReportsExecuteContext context = new GetSentSmsDeliveryReportsExecuteContext
            {
                MessageId = messageId
            };
            SMSReportResponse response = reportsClient.Execute(context);

            if (response.Results.Count < 1)
            {
                Console.WriteLine("No report to fetch.");
                return;
            }

            Console.WriteLine("Fetching report complete.");

            SMSReport report = response.Results[0];
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Message ID: " + report.MessageId);
            Console.WriteLine("Sent at: " + report.SentAt.ToLocalTime());
            Console.WriteLine("Receiver: " + report.To);
            Console.WriteLine("Status: " + report.Status.Name);
            Console.WriteLine("Price: " + report.Price.PricePerMessage + " " + report.Price.Currency);
            Console.WriteLine("-------------------------------");
        }
    }
}
