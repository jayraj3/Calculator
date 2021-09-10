using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Core.API;
namespace Calculator.Core.Calculators
{
    class CurrencyConverter : IRestCall
    {

        private CurrencyData CurrentRate;
        public string UpdateCurrencyRate()
        {
            CallAPI ApiCall = new CallAPI();
            CurrentRate = ApiCall.GetCurrency();
            return UnixTimeToDateTime(CurrentRate.timestamp);
        }

        private string UnixTimeToDateTime(long unixtime)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            return "Updated "+ dtDateTime.ToString();
        }
        public string ConvertCurrency(string fromCurrency, string toCurrency, double value)
        {
            if (fromCurrency == toCurrency)
            {
                return value.ToString();
            }

            if (fromCurrency == "EUR")
            {
                double ConversionValue = value * CurrentRate.rates.GetCurrencyRate(toCurrency);
                return ConversionValue.ToString();
            }
            else if(toCurrency == "EUR")
            {
                double ConversionValue = value / CurrentRate.rates.GetCurrencyRate(fromCurrency);
                return ConversionValue.ToString();
            }
            else
            {
                double EuroValue = value / CurrentRate.rates.GetCurrencyRate(fromCurrency);
                double ConversionValue = EuroValue * CurrentRate.rates.GetCurrencyRate(toCurrency);
                return ConversionValue.ToString();

            }
            
        }

    }
}
