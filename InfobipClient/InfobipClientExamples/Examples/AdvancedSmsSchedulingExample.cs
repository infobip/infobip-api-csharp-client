using Infobip.Api.Model;
using Infobip.Api.Model.Sms.Mt.Bulks;
using Infobip.Api.Model.Sms.Mt.Bulks.Status;
using Infobip.Api.Model.Sms.Mt.Send;
using Infobip.Api.Model.Sms.Mt.Send.Textual;
using Infobip.Api.Config;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class AdvancedSmsSchedulingExample : Example
    {
        private static DateTimeOffset NOW = new DateTimeOffset(DateTime.Now);

        public async override Task RunExampleAsync()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Sending scheduled fully featured textual message...");

            SMSResponse smsResponse = await SendScheduledMessageAsync();
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

            BulkResponse bulkResponse = await GetBulkAsync(bulkId);
            Console.WriteLine("Fetched scheduling date.");
            Console.WriteLine("Bulk ID: " + bulkResponse.BulkId);
            Console.WriteLine("SendAt: " + bulkResponse.SendAt);
            Console.WriteLine("-------------------------------");

            RescheduleMessageAsync(bulkId);
            Console.WriteLine("Rescheduling message.");
            Console.WriteLine("-------------------------------");

            System.Threading.Thread.Sleep(1000);

            bulkResponse = await GetBulkAsync(bulkId);
            Console.WriteLine("Fetched scheduling date after rescheduling.");
            Console.WriteLine("Bulk ID: " + bulkResponse.BulkId);
            Console.WriteLine("SendAt: " + bulkResponse.SendAt);
            Console.WriteLine("-------------------------------");

            System.Threading.Thread.Sleep(1000);

            BulkStatusResponse statusResponse = await GetBulkStatusAsync(bulkId);
            Console.WriteLine("Fetched bulk status.");
            Console.WriteLine("Bulk status: " + statusResponse.Status);
            Console.WriteLine("-------------------------------");

            if (statusResponse.Status == BulkStatus.PENDING)
            {
                Console.WriteLine("Fetched bulk is in PENDING status, attempting to cancel bulk.");
                Console.WriteLine("-------------------------------");

                CancelBulkStatusAsync(bulkId);

                statusResponse = await GetBulkStatusAsync(bulkId);
                Console.WriteLine("Fetched bulk status after cancelation.");
                Console.WriteLine("Bulk status: " + statusResponse.Status);
            }
            else
            {
                Console.WriteLine("Fetched bulk is not in PENDING status, aborting update.");
            }

            Console.WriteLine("-------------------------------");
        }

        private static async Task<SMSResponse> SendScheduledMessageAsync()
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
                SendAt = new FormattedDate(sendAt)
            };

            SMSAdvancedTextualRequest request = new SMSAdvancedTextualRequest
            {
                Messages = new List<Message>(1) { message }
            };

            return await smsClient.ExecuteAsync(request);
        }

        private static async Task<BulkResponse> GetBulkAsync(string bulkId)
        {
            GetBulksExecuteContext context = new GetBulksExecuteContext{ BulkId = bulkId };

            return await new GetBulks(BASIC_AUTH_CONFIGURATION).ExecuteAsync(context);
        }

        private static async void RescheduleMessageAsync(String bulkId)
        {
            DateTimeOffset sendAt = NOW.AddMinutes(30);
            BulkRequest rescheduleRequest = new BulkRequest{ SendAt = new FormattedDate(sendAt) };
            RescheduleBulkExecuteContext context = new RescheduleBulkExecuteContext { BulkId = bulkId };

            await new RescheduleBulk(BASIC_AUTH_CONFIGURATION).ExecuteAsync(context, rescheduleRequest);
        }

        private static async Task<BulkStatusResponse> GetBulkStatusAsync(String bulkId)
        {
            GetBulkStatusExecuteContext context = new GetBulkStatusExecuteContext { BulkId = bulkId };

            return await new GetBulkStatus(BASIC_AUTH_CONFIGURATION).ExecuteAsync(context);
        }

        private static async void CancelBulkStatusAsync(String bulkId)
        {
            UpdateStatusRequest updateStatusRequest = new UpdateStatusRequest { Status = BulkStatus.CANCELED };
            ManageBulkStatusExecuteContext context = new ManageBulkStatusExecuteContext { BulkId = bulkId };

            await new ManageBulkStatus(BASIC_AUTH_CONFIGURATION).ExecuteAsync(context, updateStatusRequest);
        }
    }
}
