using Infobip.Api.Model.Sms.Mt.Send.Preview;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class SmsPreviewExample : Example
    {
        public override async Task RunExampleAsync()
        {
            PreviewSms previewClient = new PreviewSms(BASIC_AUTH_CONFIGURATION);

            PreviewRequest request = new PreviewRequest()
            {
                Text = "Artık Ulusal Dil Tanımlayıcısı ile Türkçe karakterli smslerinizi rahatlıkla iletebilirsiniz.",
                LanguageCode = "TR",
                Transliteration = "TURKISH"
            };

            PreviewResponse response = await previewClient.ExecuteAsync(request);

            Console.WriteLine("Original text: ");
            Console.WriteLine("\t" + response.OriginalText);
            Console.WriteLine("Previews:");
            foreach (Preview preview in response.Previews)
            {
                Console.WriteLine("\t------------------------------------------------");
                Console.WriteLine("\tText preview: " + preview.TextPreview);
                Console.WriteLine("\tNumber of messages: " + preview.MessageCount);
                Console.WriteLine("\tCharacters remaining: " + preview.CharactersRemaining);
                Console.WriteLine("\tConfiguration: " + JsonConvert.SerializeObject(preview.Configuration));
            }
            Console.WriteLine("\t------------------------------------------------");
        }
    }
}
