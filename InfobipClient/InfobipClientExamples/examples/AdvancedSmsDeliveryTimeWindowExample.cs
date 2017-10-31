using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model;
using InfobipClient.infobip.api.model.sms.mt.send;
using InfobipClient.infobip.api.model.sms.mt.send.textual;
using System;
using System.Collections.Generic;

namespace InfobipClientExamples.examples
{
    class AdvancedSmsDeliveryTimeWindowExample : Example
    {
        public override void RunExample()
        {
            string messageId = AdvancedSms();

            System.Threading.Thread.Sleep(3000);

            GetSmsReport(messageId);
        }

        private static string AdvancedSms()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Sending fully featured textual message with delivery time window...");

            SendMultipleTextualSmsAdvanced smsClient = new SendMultipleTextualSmsAdvanced(BASIC_AUTH_CONFIGURATION);
            
            Destination destination = new Destination
            {
                To = TO
            };

            Message message = new Message
            {
                From = FROM,
                Destinations = new List<Destination>(1) { destination },
                Text = "Advanced message example",
                DeliveryTimeWindow = generateDeliveryTimeWindow()
            };

            SMSAdvancedTextualRequest request = new SMSAdvancedTextualRequest
            {
                Messages = new List<Message>(1) { message }
            };

            SMSResponse smsResponse = smsClient.Execute(request);

            Console.WriteLine("Sending fully featured textual message with delivery time window complete.");

            SMSResponseDetails sentMessageInfo = smsResponse.Messages[0];
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Message ID: " + sentMessageInfo.MessageId);
            Console.WriteLine("Receiver: " + sentMessageInfo.To);
            Console.WriteLine("Message status: " + sentMessageInfo.Status.Name);
            Console.WriteLine("-------------------------------");

            return sentMessageInfo.MessageId;
        }

        private static DeliveryTimeWindow generateDeliveryTimeWindow()
        {
            DeliveryTime deliveryTimeFrom = new DeliveryTime
            {
                Hour = 3,
                Minute = 30
            };

            DeliveryTime deliveryTimeTo = new DeliveryTime
            {
                Hour = 23,
                Minute = 45
            };

            List<DeliveryDay> deliveryDays = new List<DeliveryDay>
            {
                DeliveryDay.MONDAY,
                DeliveryDay.TUESDAY,
                DeliveryDay.WEDNESDAY,
                DeliveryDay.THURSDAY,
                DeliveryDay.FRIDAY,
                DeliveryDay.SATURDAY,
                DeliveryDay.SUNDAY
            };

            DeliveryTimeWindow deliveryTimeWindow = new DeliveryTimeWindow
            {
                From = deliveryTimeFrom,
                To = deliveryTimeTo,
                Days = deliveryDays
            };
            return deliveryTimeWindow;
        }
    }
}
