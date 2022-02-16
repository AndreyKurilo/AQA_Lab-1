using System;

namespace CurrencyExchange_ver2
{
    public class Bank
    {
        private const int CommissionPercent = 3;
        private readonly double _rateUsd;
        private readonly double _rateEur;
        private readonly double _rateRub;
        private readonly double _operationalSum;
        private readonly string _currencyType;
        private string _exchangeCurrencyType;
        private double _resultSum;

        public Bank(string request, CurrencyRates rates)
        {
            _operationalSum = double.Parse(request.Remove(request.Length - 3));
            _currencyType = request.Substring(request.Length - 3, 3);
            _rateUsd = rates.getUSD();
            _rateEur = rates.getEUR();
            _rateRub = rates.getRUB();
        }

        public void SetCurrencyType(string currency)
        {
            _exchangeCurrencyType = currency;
        }

        private void Convert(double sum, string sourceCurrency, string finalCurrency)
        {
            double rateOfSource;
            double rateOfFinal;
            sourceCurrency = sourceCurrency.ToUpper();
            finalCurrency = finalCurrency.ToUpper();

            if (sourceCurrency.Equals("USD")) rateOfSource = _rateUsd;
            else if (sourceCurrency.Equals("EUR")) rateOfSource = _rateEur;
            else rateOfSource = _rateRub;

            if (finalCurrency.Equals("USD")) rateOfFinal = _rateUsd;
            else if (finalCurrency.Equals("EUR")) rateOfFinal = _rateEur;
            else rateOfFinal = _rateRub;

            var exchange = Exchange(sum, rateOfSource, rateOfFinal);
            _resultSum = Math.Round(exchange, 2);
        }

        private double Exchange(double sum, double rateOfSource, double rateOfFinal) =>
            AfterBankCommission(sum) * rateOfSource / rateOfFinal;

        private double AfterBankCommission(double sum) => sum - sum * CommissionPercent / 100;

        public void ShowResult()
        {
            Convert(_operationalSum, _currencyType, _exchangeCurrencyType);
            Console.WriteLine("Your sum is: " + _resultSum + " " + _exchangeCurrencyType.ToUpper());
        }
    }
}