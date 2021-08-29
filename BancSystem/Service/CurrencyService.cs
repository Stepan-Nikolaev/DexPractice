using BancSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BancSystem.Service
{
    public class CurrencyService
    {
        private readonly string _key = "4318395858bc3f10517f6df60168a109";

        public async Task<CurrencyResponce> GetCurrencyRate()
        {
            HttpResponseMessage responceMessage;
            CurrencyResponce currencyResponce;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_key);
                responceMessage = await client.GetAsync("http://api.currencylayer.com/live?access_key=4318395858bc3f10517f6df60168a109");

                responceMessage.EnsureSuccessStatusCode();

                string serializedMessage = await responceMessage.Content.ReadAsStringAsync();
                currencyResponce = JsonConvert.DeserializeObject<CurrencyResponce>(serializedMessage);
            }

            return currencyResponce;
        }
    }
}
