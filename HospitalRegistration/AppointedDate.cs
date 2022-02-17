using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalRegistration
{
    class AppointedDate
    {
        int day, month, year;
        enum DayInMonth {January = 31, February = 28, March = 31, April = 30, May = 31, June = 30, July = 31, 
            August = 31, September = 30, October = 31, November = 30, December = 31}

        public static bool ValidateInput(string value)
        {
            int day, month, year;

            if (value.Length != 10)
            {
                Console.WriteLine($"Entered date {0} has wrong format - needed - dd/mm/yyyy", value);
                return false;
            }

            for (byte i = 6; i < 10; i++)
            {
                if (!Char.IsDigit(value[i]))
                {
                    Console.WriteLine("Year has include only digits");
                    return false;
                }
            }

            year = int.Parse(value.Substring(6));

            for (byte i = 3; i < 5; i++)
            {
                if (!Char.IsDigit(value[i]))
                {
                    Console.WriteLine("Month has include digits only. If it's single add 0: 1 - 01");
                    return false;
                }
            }

            if (value[3] == 0) month = int.Parse(value.Substring(4, 1));
            else month = int.Parse(value.Substring(3, 2));

            if (month < 1 || month > 12)
            {
                Console.WriteLine("Mont's number must be from 01 to 12 ");
                return false;
            }

            for(byte i = 0; i < 2; i++)
            {
                if (!Char.IsDigit(value[i]))
                {
                    Console.WriteLine("Day has include digits only. If it's single add 0: 1 - 01");
                    return false;
                }
            }

            if (value[0] == 0) day = int.Parse(value.Substring(1, 1));
            else day = int.Parse(value.Substring(0, 2));

            switch (month)
            {
                case 1:
                    if (day < 1 || day > (int) DayInMonth.January) return false;
                    break;
                case 2:
                    if (year%4 != 0)
                    {
                        if (day < 1 || day > (int)DayInMonth.February) return false;
                    }
                    if (day < 1 || day > (int)DayInMonth.February + 1) return false;
                    break;
                case 3:
                    if (day < 1 || day > (int)DayInMonth.March) return false;
                    break;
                case 4:
                    if (day < 1 || day > (int)DayInMonth.April) return false;
                    break;
                case 5:
                    if (day < 1 || day > (int)DayInMonth.May) return false;
                    break;
                case 6:
                    if (day < 1 || day > (int)DayInMonth.June) return false;
                    break;
                case 7:
                    if (day < 1 || day > (int)DayInMonth.July) return false;
                    break;
                case 8:
                    if (day < 1 || day > (int)DayInMonth.August) return false;
                    break;
                case 9:
                    if (day < 1 || day > (int)DayInMonth.September) return false;
                    break;
                case 10:
                    if (day < 1 || day > (int)DayInMonth.October) return false;
                    break;
                case 11:
                    if (day < 1 || day > (int)DayInMonth.November) return false;
                    break;
                case 12:
                    if (day < 1 || day > (int)DayInMonth.December) return false;
                    break;
            }
            return true;
        }

        public static bool VerifyAppointment(string value)
        {
            int day = int.Parse(value.Substring(0, 2));
            int months = int.Parse(value.Substring(3, 2));
            int year = int.Parse(value.Substring(6));

            if ((year - DateTime.Now.Year) < 0)
            {
                return false;
            } else if ((year - DateTime.Now.Year) == 0 & (months - DateTime.Now.Month) < 0)
                return false;
            else if ((year - DateTime.Now.Year) == 0 & (months - DateTime.Now.Month) == 0 & (day - DateTime.Now.Day) < 1)
                return false;
            return true;
        }
    }
}
