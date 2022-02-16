using System;

namespace Appointment
{
   public class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            var bot = new Bot();
            user.SetName(bot.AskForName());
            user.SetSurname(bot.AskForSurname());
            user.SetDate(bot.AskForDate());
            bot.ReplyTo(user);
        }
    }
}
