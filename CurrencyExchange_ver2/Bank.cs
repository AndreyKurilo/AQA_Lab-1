using System;

namespace CurrencyExchange_ver2
{
    public class Bank
    {
        private const int CommissionPercent = 3;
        private double _resultSum;
        private readonly CurrencyRates _rates;

        public Bank(CurrencyRates rates)
        {
            _rates = rates;
        }

        public double Convert(double sum, CurrencyType currencyFrom, CurrencyType currencyTo)
        {
            var exchange = Exchange(
                sum,
                _rates.GetCurrency(currencyFrom).Rate,
                _rates.GetCurrency(currencyTo).Rate);

            _resultSum = Math.Round(exchange, 2);

            return _resultSum;
        }

        private double Exchange(double sum, double rateOfSource, double rateOfFinal) =>
            AfterBankCommission(sum) * rateOfSource / rateOfFinal;

        private double AfterBankCommission(double sum) => sum - sum * CommissionPercent / 100;
    }
}