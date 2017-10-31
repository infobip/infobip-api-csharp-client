using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model.sms.mt.send;
using InfobipClient.infobip.api.model.sms.mt.send.textual;
using System;

namespace InfobipClientExamples.examples
{
    class SingleTextualSmsExample : Example
    {
        public override void RunExample()
        {
            string messageId = SendSingleTextualSms();

            System.Threading.Thread.Sleep(2000);

            GetSmsReport(messageId);
        }

        private static string SendSingleTextualSms()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Sending single textual message...");

            SendSingleTextualSms smsClient = new SendSingleTextualSms(BASIC_AUTH_CONFIGURATION);
            SMSTextualRequest request = new SMSTextualRequest
            {
                From = FROM,
                To = TO_LIST,
                Text = MESSAGE_TEXT
            };
            SMSResponse smsResponse = smsClient.Execute(request);

            Console.WriteLine("Sending single textual message complete.");

            SMSResponseDetails sentMessageInfo = smsResponse.Messages[0];
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Message ID: " + sentMessageInfo.MessageId);
            Console.WriteLine("Receiver: " + sentMessageInfo.To);
            Console.WriteLine("Message status: " + sentMessageInfo.Status.Name);
            Console.WriteLine("-------------------------------");

            return sentMessageInfo.MessageId;
        }
    }
}
