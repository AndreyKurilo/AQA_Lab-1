using System.Collections.Generic;

namespace CurrencyExchange_ver2
{
    public class CurrencyRates
    {
        private readonly Dictionary<CurrencyType, Currency> _currencies = new Dictionary<CurrencyType, Currency>();

        public void AddCurrency(CurrencyType currencyType, double rate)
        {
            var currency = new Currency
            {
                Type = currencyType,
                Rate = rate
            };

            _currencies.Add(currencyType, currency);
        }

        public Currency GetCurrency(CurrencyType currencyType) => _currencies[currencyType];
    }
}