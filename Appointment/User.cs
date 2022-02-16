using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Appointment
{
    public class User
    {
        string name;
        string surname;
        string date;
        
        //public string Name { get; set; }
        public void SetName(string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    name = CheckAndCorrect(name);
                    break;
                }
            }

            this.name = name;
        }

        public void SetSurname(string surname)
        {
            for (byte i = 0; i < surname.Length; i++)
            {
                if (!Char.IsLetter(surname[i]))
                {
                    surname = CheckAndCorrect(surname);
                    break;
                }
            }

            this.surname = surname;
        }

        public void SetDate(string date)
        {
            this.date = date;
        }

        public string GetName()
        {
            return name;
        }
         public string GetSurname()
        {
            return surname;
        }

        public string GetDate()
        {
            return date;
        }

        public void RegistrationTime()
        {
            Random rnd = new Random();
            int hour = rnd.Next(9, 18);
            int min = rnd.Next(0, 59);
            Console.WriteLine(name + " " + surname + " has registration " + date + " on " + hour + ":" + min);
        }
        
        private static string CheckAndCorrect(string userInput)
        {
            Console.WriteLine("Entered: " + userInput);
            Console.WriteLine("Name/surname must have letters only - input processing...");
            Regex regex = new Regex("[^a-zA-ZА-Яа-я]");
            userInput = regex.Replace(userInput, "");
            Console.WriteLine("After processing: " + userInput);
            return userInput;
        }

    }
}
