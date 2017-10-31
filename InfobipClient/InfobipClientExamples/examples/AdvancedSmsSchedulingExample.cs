using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model;
using InfobipClient.infobip.api.model.sms.mt.bulks;
using InfobipClient.infobip.api.model.sms.mt.bulks.status;
using InfobipClient.infobip.api.model.sms.mt.send;
using InfobipClient.infobip.api.model.sms.mt.send.textual;
using System;
using System.Collections.Generic;

namespace InfobipClientExamples.examples
{
    class AdvancedSmsSchedulingExample : Example
    {
        private static DateTimeOffset NOW = new DateTimeOffset(DateTime.Now);

        public override void RunExample()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Sending scheduled fully featured textual message...");

            SMSResponse smsResponse = SendScheduledMessage();
            String bulkId = smsResponse.BulkId;
            SMSResponseDetails sentMessageInfo = smsResponse.Messages[0];

            Console.WriteLine("Sending scheduled fully featured textual message complete.");

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Scheduled SMS");
            Console.WriteLine("Message ID: " + sentMessageInfo.MessageId);
            Console.WriteLine("Bulk ID: " + bulkId);
            Console.WriteLine("Receiver: " + sentMessageInfo.To);
            Console.WriteLine("Message status: " + sentMessageInfo.Status.Name);
            Console.WriteLine("-------------------------------");

            System.Threading.Thread.Sleep(1000);

            BulkResponse bulkResponse = GetBulk(bulkId);
            Console.WriteLine("Fetched scheduling date.");
            Console.WriteLine("Bulk ID: " + bulkResponse.BulkId);
            Console.WriteLine("SendAt: " + bulkResponse.SendAt);
            Console.WriteLine("-------------------------------");

            RescheduleMessage(bulkId);
            Console.WriteLine("Rescheduling message.");
            Console.WriteLine("-------------------------------");

            bulkResponse = GetBulk(bulkId);
            Console.WriteLine("Fetched scheduling date after rescheduling.");
            Console.WriteLine("Bulk ID: " + bulkResponse.BulkId);
            Console.WriteLine("SendAt: " + bulkResponse.SendAt);
            Console.WriteLine("-------------------------------");

            BulkStatusResponse statusResponse = GetBulkStatus(bulkId);
            Console.WriteLine("Fetched bulk status.");
            Console.WriteLine("Bulk status: " + statusResponse.Status);
            Console.WriteLine("-------------------------------");

            if (statusResponse.Status == BulkStatus.PENDING)
            {
                Console.WriteLine("Fetched bulk is in PENDING status, attempting to cancel bulk.");
                Console.WriteLine("-------------------------------");

                CancelBulkStatus(bulkId);

                statusResponse = GetBulkStatus(bulkId);
                Console.WriteLine("Fetched bulk status after cancelation.");
                Console.WriteLine("Bulk status: " + statusResponse.Status);
            }
            else
            {
                Console.WriteLine("Fetched bulk is not in PENDING status, aborting update.");
            }

            Console.WriteLine("-------------------------------");
        }

        private static SMSResponse SendScheduledMessage()
        {
            SendMultipleTextualSmsAdvanced smsClient = new SendMultipleTextualSmsAdvanced(BASIC_AUTH_CONFIGURATION);

            Destination destination = new Destination
            {
                To = TO
            };
            
            DateTimeOffset sendAt = NOW.AddMinutes(10);

            Message message = new Message
            {
                From = FROM,
                Destinations = new List<Destination>(1) { destination },
                Text = "Advanced scheduled message example",
                SendAt = sendAt
            };

            SMSAdvancedTextualRequest request = new SMSAdvancedTextualRequest
            {
                Messages = new List<Message>(1) { message }
            };

            return smsClient.Execute(request);
        }

        private static BulkResponse GetBulk(string bulkId)
        {
            GetBulksExecuteContext context = new GetBulksExecuteContext{ BulkId = bulkId };

            return new GetBulks(BASIC_AUTH_CONFIGURATION).Execute(context);
        }

        private static void RescheduleMessage(String bulkId)
        {
            DateTimeOffset sendAt = NOW.AddMinutes(30);
            BulkRequest rescheduleRequest = new BulkRequest{ SendAt = sendAt };
            RescheduleBulkExecuteContext context = new RescheduleBulkExecuteContext { BulkId = bulkId };

            new RescheduleBulk(BASIC_AUTH_CONFIGURATION).Execute(context, rescheduleRequest);
        }

        private static BulkStatusResponse GetBulkStatus(String bulkId)
        {
            GetBulkStatusExecuteContext context = new GetBulkStatusExecuteContext { BulkId = bulkId };

            return new GetBulkStatus(BASIC_AUTH_CONFIGURATION).Execute(context);
        }

        private static void CancelBulkStatus(String bulkId)
        {
            UpdateStatusRequest updateStatusRequest = new UpdateStatusRequest { Status = BulkStatus.CANCELED };
            ManageBulkStatusExecuteContext context = new ManageBulkStatusExecuteContext { BulkId = bulkId };

            new ManageBulkStatus(BASIC_AUTH_CONFIGURATION).Execute(context, updateStatusRequest);
        }
    }
}
