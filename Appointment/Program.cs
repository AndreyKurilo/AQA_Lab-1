using System;

namespace Appointment
{
   public class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            var bot = new Bot();
            user.Name = bot.AskForName();
            user.Surname = bot.AskForSurname();
            user.Date = bot.AskForDate();
            bot.ReplyTo(user);
        }
    }
}
