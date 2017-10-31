using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model;
using InfobipClient.infobip.api.model.sms.mt.send;
using InfobipClient.infobip.api.model.sms.mt.send.textual;
using System;
using System.Collections.Generic;

namespace InfobipClientExamples.examples
{
    class AdvancedSmsLanguageExample : Example
    {
        public override void RunExample()
        {
            string messageId = AdvancedSms();

            System.Threading.Thread.Sleep(2000);

            GetSmsReport(messageId);
        }

        private static string AdvancedSms()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Sending fully featured textual message with language...");

            SendMultipleTextualSmsAdvanced smsClient = new SendMultipleTextualSmsAdvanced(BASIC_AUTH_CONFIGURATION);

            Destination destination = new Destination
            {
                To = TO
            };

            Language language = new Language
            {
                LanguageCode = "TR",
                SingleShift = true,
                LockingShift = true
            };

            Message message = new Message
            {
                From = FROM,
                Destinations = new List<Destination>(1) { destination },
                Text = "Artık Ulusal Dil Tanımlayıcısı ile Türkçe karakterli smslerinizi rahatlıkla iletebilirsiniz.",
                Language = language,
                Transliteration = "TURKISH"
            };

            SMSAdvancedTextualRequest request = new SMSAdvancedTextualRequest
            {
                Messages = new List<Message>(1) { message }
            };

            SMSResponse smsResponse = smsClient.Execute(request);

            Console.WriteLine("Sending fully featured textual message with language complete.");

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
