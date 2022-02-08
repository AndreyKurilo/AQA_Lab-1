using System;

namespace HospitalRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            bot.Questioning();
            bot.Answering();
        }
    }
}
