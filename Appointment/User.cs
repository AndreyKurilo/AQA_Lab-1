using System;

namespace Appointment
{
    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Date { get; set; }


        public void PrintRegistrationTime()
        {
            var random = new Random();
            var hours = random.Next(RegistrationData.StartHour, RegistrationData.FinishHour);
            var minutes = random.Next(0, 59);
            Console.WriteLine(Name + " " + Surname + " has registration " + Date + " on " + hours + ":" + minutes);
        }
    }
}