using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model.conversion;
using System;

namespace InfobipClientExamples.examples
{
    class LogEndTagExample : Example
    {
        public override void RunExample()
        {
            LogEndTag client = new LogEndTag(BASIC_AUTH_CONFIGURATION);

            string messageId = "MESSAGE-ID";

            EndTagResponse response = client.Execute(messageId);
            
            Console.WriteLine("ProcessKey: " + response.ProcessKey);
        }
    }
}
