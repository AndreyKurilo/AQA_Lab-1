using System;

namespace Appointment
{
    public class Input
    {
        public string Name() => GetNameOrSurname("Enter Your name");
        
        public string Surname() => GetNameOrSurname("Enter Your surname");
        
        public string Date()
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

        private static string GetNameOrSurname(string message)
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
