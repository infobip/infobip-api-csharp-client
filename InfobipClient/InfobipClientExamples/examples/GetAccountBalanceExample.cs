using Infobip.Api.Model.Account;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class GetAccountBalanceExample : Example
    {
        public override async Task RunExampleAsync()
        {
            GetAccountBalance client = new GetAccountBalance(BASIC_AUTH_CONFIGURATION);

            AccountBalance accountBalance = await client.ExecuteAsync();
            Console.WriteLine("Account balance: ");
            Console.WriteLine(JsonConvert.SerializeObject(accountBalance, new JsonSerializerSettings { Formatting = Formatting.Indented } ));
        }
    }
}
