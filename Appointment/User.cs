using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Appointment
{
    public class User
    {
        private string _name;
        private string _surname;
        string date;

        public string Name
        {
            get => _name;
            set => _name = CorrectUserString(value);
        }

        public string Surname
        {
            get => _surname;
            set => _surname = CorrectUserString(value);
        }
        
        private string CorrectUserString(string inputString)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (!Char.IsLetter(inputString[i]))
                {
                    CheckAndCorrect(inputString);
                    break;
                }
            }

            return inputString;
        }

        
        public string Date { get; set; }


        public void RegistrationTime()
        {
            Random rnd = new Random();
            int hour = rnd.Next(9, 18);
            int min = rnd.Next(0, 59);
            Console.WriteLine(_name + " " + _surname + " has registration " + date + " on " + hour + ":" + min);
        }

        private void CheckAndCorrect(string userInput)
        {
            Console.WriteLine("Entered: " + userInput);
            Console.WriteLine("Name/surname must have letters only - input processing...");
            Regex regex = new Regex("[^a-zA-ZА-Яа-я]");
            userInput = regex.Replace(userInput, "");
            Console.WriteLine("After processing: " + userInput);
        }
    }
}