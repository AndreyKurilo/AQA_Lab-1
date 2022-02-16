using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment
{
    public class Bot
    {
        public Bot()
        {
            var user = new User();
        }
        
        public string AskForName() => GetNameOrSurnName("Enter Your name");
        
        public string AskForSurname() => GetNameOrSurnName("Enter Your surname");
        
        public string AskForDate()
        {
            string date;
            do
            {
                Console.WriteLine("Enter date for appointment");
                Console.WriteLine("in such format: dd/mm/yyyy");
                date = Console.ReadLine();
            }
            while (!Validate.Appointment(date));
            return date;
        }

        public void ReplyTo(User user)
        {
            user.RegistrationTime();
        }
        
        private static string GetNameOrSurnName(string message)
        {
            string name;
            do
            {
                Console.WriteLine(message);
                name = Console.ReadLine();
            } while (!Validate.Input(name));

            return name;
        }

    }
}
