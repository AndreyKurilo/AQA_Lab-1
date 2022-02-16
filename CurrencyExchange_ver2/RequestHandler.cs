using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;
using WordsToNumbers;

namespace CurrencyExchange_ver2
{
    class RequestHandler
    {
        public string Handler(string value)
        {            
            if (Char.IsDigit(value[0])) return value;
            return FromText(value);            
        }

        public string FromText(string value)
        {
            string currencyType = value.Substring(value.Length - 4);
            value = value.Remove(value.Length - 4);

            var converter = new SimpleReplacementStrategy();
            var numberFromString = converter.ConvertWordsToNumbers(value);

            string handledString = numberFromString + " " + currencyType;

            return handledString;
        }


    }
}
