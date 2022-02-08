using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;

namespace CurrencyExchange_ver2
{
    class RequestHandler
    {
        public string Handler(string value)
        {            
            if (Char.IsDigit(value[0])) return value;
            //value = value.Replace(" ", "");
            return FromText(value);            
        }

        public string FromText(string value)
        {
            string currencyType = value.Substring(value.Length - 4);
            Console.WriteLine("Currency type: " + currencyType);
            value = value.Remove(value.Length - 4);
            string handledString = WordsToNumbers.ConvertToNumbers(value) + currencyType;

            return handledString;
        }
    }
}
