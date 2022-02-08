using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange_ver2
{
    class Bot
    {
        public string askUSDrate()
        {
            Console.WriteLine("Enter USD excange rate");

            return Console.ReadLine();
        }

        public string askEURrate()
        {
            Console.WriteLine("Enter EUR excange rate");

            return Console.ReadLine();
        }

        public string askRUBrate()
        {
            Console.WriteLine("Enter RUB excange rate");

            return Console.ReadLine();
        }

        public string askExchangeSum()
        {
            Console.WriteLine("Enter excange sum like this \"1000 USD\" or \"one thousand USD\"");

            return Console.ReadLine();
        }

        public string askFinalCurrency()
        {
            string answer;

            do
            {
                Console.WriteLine("Enter currency You need USD EUR RUB");
                answer = Console.ReadLine();
            }while (!Validate.CurrencyTypeCorrect(answer));

            return answer;
        }
    }
}
