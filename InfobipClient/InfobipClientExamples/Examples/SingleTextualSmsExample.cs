using Infobip.Api.Model.Sms.Mt.Send;
using Infobip.Api.Model.Sms.Mt.Send.Textual;
using System;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class SingleTextualSmsExample : Example
    {
        public override async Task RunExampleAsync()
        {
            string messageId = await SendSingleTextualSmsAsync();

            System.Threading.Thread.Sleep(2000);

            await GetSmsReportAsync(messageId);
        }

        private static async Task<string> SendSingleTextualSmsAsync()
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
            SMSResponse smsResponse = await smsClient.ExecuteAsync(request);

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
