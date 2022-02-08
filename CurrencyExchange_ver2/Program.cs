using System;

namespace CurrencyExchange_ver2
{
    class Program
    {
        static void Main(string[] args)
        {
            string userRequest;
            Bot bot = new Bot();
            Rates rates = new Rates();
            RequestHandler request = new RequestHandler();
            rates.SetUSDrate(bot.askUSDrate());
            rates.SetEURrate(bot.askEURrate());
            rates.SetRUBrate(bot.askRUBrate());
            userRequest = request.Handler(bot.askExchangeSum());
            Bank bank = new Bank(userRequest, rates);
            bank.SetCurrencyType(bot.askFinalCurrency());
            bank.ShowResult();
        }
    }
}
