using System;

namespace CurrencyExchange_ver2
{
    public static class Program
    {
        private static void Main()
        {
            var bot = new Bot();
            var rates = new CurrencyRates();
            var bank = new Bank(rates);

            rates.AddCurrency(CurrencyType.USD, double.Parse(bot.AskUsdRate()));
            rates.AddCurrency(CurrencyType.RUB, double.Parse(bot.AskRubRate()));
            rates.AddCurrency(CurrencyType.EUR, double.Parse(bot.AskEurRate()));

            var exchangeRequest = ExchangeParser.ConvertToNumbers(bot.AskExchangeSum());
            var requestedCurrencyTo = bot.AskFinalCurrency();

            var exchangeSum = ExchangeParser.GetSum(exchangeRequest);
            var currencyFrom = ExchangeParser.GetCurrencyType(exchangeRequest);
            var currencyTo = (CurrencyType) Enum.Parse(typeof(CurrencyType), requestedCurrencyTo);

            var convertedSum = bank.Convert(exchangeSum, currencyFrom, currencyTo);
            
            Console.WriteLine("Converted sum is: " + convertedSum + " " + currencyTo);
        }
    }
}