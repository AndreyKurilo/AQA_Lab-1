using System;

namespace Appointment
{
    public static class Validate
    {
        public static bool Input(string value)
        {
            var isValid = true;
            
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                {
                    isValid = false;
                }
            }
            
            if (value.Length < 1) isValid = false;
            
            Console.WriteLine("Name/surname has to have 1 letter at least!");
            return isValid;
        }

        public static bool Appointment(string value)
        {
            if (DateTime.TryParse(value, out DateTime dateTime))
            {
                if (DateTime.Now.CompareTo(dateTime) < 1)
                {
                    return true;
                }

                Console.WriteLine("Appointed day must be later then now!");
                return false;
            }

            Console.WriteLine("Entered date is wrong");
            return false;
        }
    }
}
