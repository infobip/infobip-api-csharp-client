using Infobip.Api.Model.Conversion;
using System;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class LogEndTagExample : Example
    {
        public override async Task RunExampleAsync()
        {
            LogEndTag client = new LogEndTag(BASIC_AUTH_CONFIGURATION);

            string messageId = "MESSAGE-ID";

            EndTagResponse response = await client.ExecuteAsync(messageId);
            
            Console.WriteLine("ProcessKey: " + response.ProcessKey);
        }
    }
}
