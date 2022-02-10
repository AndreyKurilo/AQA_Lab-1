using System;
using System.Collections.Generic;
using System.Text;

namespace Users
{
    public class Candidate : IUser
    {
        private readonly Guid _id;
        private readonly string _name;
        private readonly string _surname;
        private readonly string _jobTittle;
        private readonly string _jobDescription;
        private readonly double _jobSalary;

        public Candidate(Guid id, string name, string surname, string jobTittle, string jobDescription,
            double jobSalary)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _jobTittle = jobTittle;
            _jobDescription = jobDescription;
            _jobSalary = jobSalary;
        }



        public void DisplayInformation()
        {
            System.Guid guid = System.Guid.NewGuid();
            Console.WriteLine(guid.ToString());

        }
    }
}
