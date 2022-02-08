using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalRegistration
{
    class Bot
    {
        private string date = null;
        string name, surname;
        char sanction = 'Y';

        public void Questioning()
        {
            while(sanction != 'N')
            {
                Console.WriteLine("Would You like to register? Y/N");
                sanction = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (sanction == 'Y' | sanction == 'y')
                {
                    Console.WriteLine("Enter Your name, please");
                    name = Console.ReadLine();
                    if (ValidateInput(name))
                    {
                        Console.WriteLine("Enter Your surname, please");
                        surname = Console.ReadLine();
                        if (ValidateInput(surname))
                        {
                            Console.WriteLine("Enter date for admittance dd/mm/yyyy");
                            Console.WriteLine("For example - February 1st 2000: 01/02/2000 ");
                            date = Console.ReadLine();
                            if (AppointedDate.ValidateInput(date)) sanction = 'N';
                        }
                    }
                }
                else sanction = 'N';
            }
        }

        public void Answering()
        {
            if (date != null)
            {
                if (AppointedDate.VerifyAppointment(date))
                {
                    Patient patient = new Patient(name, surname, date);
                    patient.showPatient();
                }
                else Console.WriteLine("Registration available only the date later then now");
            }
            else Console.WriteLine("User has stopped program executing");
        }

        private bool ValidateInput(string value)
        {
            for(byte i = 0; i < value.Length; i++)
            {
                if (!Char.IsLetter(value[i]))
                {
                    Console.WriteLine("Wrong record - name & surname must have char's symbols only");
                    return false;
                }
            }
            return true;
        }
    }
}
