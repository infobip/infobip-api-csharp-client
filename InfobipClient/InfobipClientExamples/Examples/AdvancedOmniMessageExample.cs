using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infobip.Api.Model.Omni;
using Infobip.Api.Model.Omni.Send;


namespace Infobip.Api.Client.Examples
{
    class AdvancedOmniMessageExample : Example
    {
        public override async Task RunExampleAsync()
        {
            string bulkId = await AdvancedOmniAsync();

            System.Threading.Thread.Sleep(2000);

            await GetOmniReportAsync(bulkId);
        }

        private static async Task<string> AdvancedOmniAsync()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Sending Advance OMNI message...");

            SendAdvancedOmniMessage omniClient = new SendAdvancedOmniMessage(BASIC_AUTH_CONFIGURATION);

            Destination destination = new Destination
            {
                To = new To
                {
                    PhoneNumber = TO
                }
            };

            SmsData smsData = new SmsData
            {
                Text = "Artık Ulusal Dil Tanımlayıcısı ile Türkçe karakterli smslerinizi rahatlıkla iletebilirsiniz.",
                Language = new Language { LanguageCode = "TR" },
                Transliteration = "TURKISH"
            };

            ViberData viberData = new ViberData
            {
                Text = "Luke, I'm your father!"
            };

            OmniAdvancedRequest request = new OmniAdvancedRequest
            {
                Destinations = new List<Destination>(1) { destination },
                ScenarioKey = "6EDEA8BF17983A97C42BCA702F0A673D", // Your-Scenario-Key
                Sms = smsData,
                Viber = viberData 
            };

            OmniResponse omniResponse = await omniClient.ExecuteAsync(request);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Bulk ID: " + omniResponse.BulkId);
            Console.WriteLine("-------------------------------");
            foreach (OmniResponseDetails sentMessageInfo in omniResponse.Messages)
            {
                Console.WriteLine("Message ID: " + sentMessageInfo.MessageId);
                Console.WriteLine("Message status: " + sentMessageInfo.Status.Name);
                Console.WriteLine("-------------------------------");
            }

            return omniResponse.BulkId;
        }
    }
}
