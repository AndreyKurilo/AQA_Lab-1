using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment
{
    class Bot
    {
        public Bot()
        {
            User user = new User();
        }
        public string AskForName()
        {
            string name;
            do
            {
                Console.WriteLine("Enter Your name");
                name = Console.ReadLine();
            } 
            while (!Validate.Input(name));
            return name;
        }

        public string AskForSurname()
        {
            string surname;
            do
            {
                Console.WriteLine("Enter Your surname");
                surname = Console.ReadLine();
            }
            while (!Validate.Input(surname));
            return surname;
        }

        public string AskForDate()
        {
            string date;
            do
            {
                Console.WriteLine("Enter date for appointment");
                date = Console.ReadLine();
            }
            while (!Validate.Appointment(date));
            return date;
        }

        public void ReplyTo(User user)
        {
            user.Info();
        }
    }
}
