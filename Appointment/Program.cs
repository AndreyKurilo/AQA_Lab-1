using System;

namespace Appointment
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Bot bot = new Bot();
            user.SetName(bot.AskForName());
            user.SetSurname(bot.AskForSurname());
            user.SetDate(bot.AskForDate());
            bot.ReplyTo(user);
        }
    }
}
