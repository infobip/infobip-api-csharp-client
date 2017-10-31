using InfobipClient.infobip.api.client;
using InfobipClient.infobip.api.model.account;
using Newtonsoft.Json;
using System;

namespace InfobipClientExamples.examples
{
    class GetAccountBalanceExample : Example
    {
        public override void RunExample()
        {
            GetAccountBalance client = new GetAccountBalance(BASIC_AUTH_CONFIGURATION);

            AccountBalance accountBalance = client.Execute();

            Console.WriteLine("Account balance: ");
            Console.WriteLine(JsonConvert.SerializeObject(accountBalance, new JsonSerializerSettings{ Formatting = Formatting.Indented }));
        }
    }
}
