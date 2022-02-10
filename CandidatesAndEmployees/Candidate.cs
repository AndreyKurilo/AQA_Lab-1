using System;
using System.Collections.Generic;
using System.Text;

namespace users
{
    public class Candidate : IUsers
    {
        private readonly int _id;
        private readonly string _name;
        private readonly string _surname;
        private readonly string _jobTittle;
        private readonly string _jobDescription;
        private readonly double _jobSalary;

        public Candidate(int id, string name, string surname, string jobTittle, string jobDescription,
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
