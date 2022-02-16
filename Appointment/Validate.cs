using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Appointment
{
    class Validate
    {
        public static bool Input(string value)
        {
            foreach (char c in value)
            {
                if (Char.IsLetter(c))
                {
                    return true;
                }
            }
            Console.WriteLine("Name/surname has to have 1 letter at least!");
            return false;
        }

        public static bool Appointment(string value)
        {
            DateTime dt;
            if (DateTime.TryParse(value, out dt))
            {
                if (DateTime.Now.CompareTo(DateTime.Parse(value)) < 1) { return true; }
                else
                {
                    Console.WriteLine("Appointed day must be later then now!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Entered date is wrong");
                return false;
            }
        }
    }
}
