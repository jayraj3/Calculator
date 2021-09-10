using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace Calculator.Core.API
{
    public class CallAPI 

    {
        private string _key { get; set; }
        public CallAPI()
        {
            _key = GetKey();
        }



        protected HttpResponseMessage GET(string URL)
        {
            using(HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(URL);
                result.Wait();
                return result.Result;
            }
        }
        protected string GetURI()
        {
            return "http://api.exchangeratesapi.io/v1/latest?access_key=" + _key;
        }


        public string GetKey()
        {
            _key = Environment.GetEnvironmentVariable("ExchangeRateApiKey");
            // If necessary, create it.
            if (_key == null)
            {
                throw new ApplicationException("Key for api not found");
            }

            return _key;

        }

        public CurrencyData GetCurrency()
        {
            var response = GET(GetURI());
            string content = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<CurrencyData>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
