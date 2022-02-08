using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Appointment
{
    class User
    {
        string name;
        string surname;
        string date;
        
        public void SetName(string name)
        {
            for (byte i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    Console.WriteLine("Entered: " + name);
                    Console.WriteLine("Name/surname must have letters only - input processing...");
                    Regex regex = new Regex("[^a-zA-ZА-Яа-я]");
                    name = regex.Replace(name, "");
                    Console.WriteLine("After processing: " + name);
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
                    Console.WriteLine("Entered: " + surname);
                    Console.WriteLine("Name/surname must have letters only - input processing...");
                    Regex regex = new Regex("[^a-zA-ZА-Яа-я]");
                    surname = regex.Replace(surname, "");
                    Console.WriteLine("After processing: " + surname);
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

        public void Info()
        {
            Random rnd = new Random();
            int hour = rnd.Next(9, 18);
            int min = rnd.Next(0, 59);
            Console.WriteLine(name + " " + surname + " has registration " + date + " on " + hour + ":" + min);
        }
    }
}
