using System;
using WordsToNumbers;

namespace CurrencyExchange_ver2
{
    public static class ExchangeParser
    {
        public static string ConvertToNumbers(string value) =>
            char.IsDigit(value[0]) ? value : FromTextToNumbers(value);

        public static double GetSum(string request)
        {
            var operationalSum = double.Parse(request.Remove(request.Length - 3));
            return operationalSum;
        }

        public static CurrencyType GetCurrencyType(string request)
        {
            var currencyTypeString = request.Substring(request.Length - 3, 3);
            var currencyType = (CurrencyType) Enum.Parse(typeof(CurrencyType), currencyTypeString);
            return currencyType;
        }

        private static string FromTextToNumbers(string value)
        {
            var currencyType = value.Substring(value.Length - 4);
            value = value.Remove(value.Length - 4);

            var converter = new SimpleReplacementStrategy();
            var numberFromString = converter.ConvertWordsToNumbers(value);

            var handledString = numberFromString + " " + currencyType;

            return handledString;
        }
    }
}