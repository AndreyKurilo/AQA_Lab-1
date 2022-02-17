using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange_ver2
{
    class Validate
    {
        public static bool RequestBodyCorrect(string value)
        {
            value = value.Remove(value.Length - 4);
            for(byte i = 0; i < value.Length; i++)
            {
                if (!(Char.IsDigit(value[i]).Equals(Char.IsDigit(value[i + 1]))
                    || !(Char.IsLetter(value[i]).Equals(Char.IsLetter(value[i + 1]))))) return false;
            }
            return true;
        }

        public static bool CurrencyTypeCorrect(string value)
        {
            if (value.Length > 3) value = value.Substring(value.Length - 4, 3);
            value = value.ToUpper();
            if (value.Equals("USD") || value.Equals("EUR") || value.Equals("RUB")) return true;
            else
            {
                Console.WriteLine("Undefined currency type");
                return false;
            }
        }
    }
}
