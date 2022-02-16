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
        
        public string AskForName()
        {
            string name;
            var message = "Enter Your name";
            name = GetNameOrSurnName(message);
            return name;
        }

        public string AskForSurname()
        {
            string surname;
            var message = "Enter Your surname";
            surname = GetNameOrSurnName(message);
            return surname;
        }

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
