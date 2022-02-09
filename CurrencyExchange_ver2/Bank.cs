using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange_ver2
{
    class Bank
    {
        double rateUSD, rateEUR, rateRUB;
        double operationalSum;
        string currencyType;
        string exchangeCurrencyType;
        double resultSumm;

        public Bank() {}
        public Bank(string request, CurrencyRates rates)
        {
            operationalSum = double.Parse(request.Remove(request.Length - 3));
            currencyType = request.Substring(request.Length - 3, 3);
            rateUSD = rates.getUSD();
            rateEUR = rates.getEUR();
            rateRUB = rates.getRUB();
        }

        public void SetCurrencyType(string currency)
        {
            exchangeCurrencyType = currency;
        }
        
        private void ShaherMaher(Double sum, string sourceCurrency, string finalCurrency)
        {
            Double rateOfSource, rateOfFinal;
            sourceCurrency = sourceCurrency.ToUpper();
            finalCurrency = finalCurrency.ToUpper();

            if (sourceCurrency.Equals("USD")) rateOfSource = rateUSD;
            else if (sourceCurrency.Equals("EUR")) rateOfSource = rateEUR;
            else rateOfSource = rateRUB;

            if (finalCurrency.Equals("USD")) rateOfFinal = rateUSD;
            else if (finalCurrency.Equals("EUR")) rateOfFinal = rateEUR;
            else rateOfFinal = rateRUB;

            resultSumm = Math.Round((((sum - sum*3/100) * rateOfSource)/rateOfFinal), 2);
        }

        public void ShowResult()
        {
            ShaherMaher(operationalSum, currencyType, exchangeCurrencyType);
            Console.WriteLine("Your summ is: " + resultSumm + " " + exchangeCurrencyType.ToUpper());
        }
    }
}
