using System;
using System.Collections.Generic;
using System.Text;

namespace CandidatesAndEmployees
{
    class Employee : IUser
    {
        private readonly Guid _id;
        private readonly decimal _jobSalary;
        private readonly string _name;
        private readonly string _surname;
        private readonly string _jobTittle;
        private readonly string _jobDescription;
        private readonly string _companyName;
        private readonly string _companyCountry;
        private readonly string _companyCity;
        private readonly string _companyStreet;

        public Employee(Guid id, decimal jobSalary, params string[] emlpoyeeArguments)
        {
            _id = id;
            _jobSalary = jobSalary;
            _name = emlpoyeeArguments[0];
            _surname = emlpoyeeArguments[1];
            _jobTittle = emlpoyeeArguments[2];
            _jobDescription = emlpoyeeArguments[3];            
            _companyName = emlpoyeeArguments[4];
            _companyCountry = emlpoyeeArguments[5];
            _companyCity = emlpoyeeArguments[6];
            _companyStreet = emlpoyeeArguments[7];
        }

        public Guid Id { get; }

        public decimal JobSalary { get; }

        public string Name { get; }

        public string Surname { get; }

        public string JobTittle { get; }

        public string JobDescription { get; }

        public string CompanyName { get; }

        public string CompanyCountry { get; }

        public string CompanyCity { get; }

        public string CompanyStreet { get; }
        

        public void DisplayInformation()
        {
            Console.WriteLine($"Hello, I am {Name} {Surname}, {JobTittle} in {CompanyName} ({CompanyCountry}, " +
                $"{CompanyCity}, {CompanyStreet}) and my salary is {JobSalary}");
        }

    }
}
