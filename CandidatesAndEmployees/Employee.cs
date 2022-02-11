using System;
using System.Collections.Generic;
using System.Text;

namespace CandidatesAndEmployees
{
    class Employee : IUser, IDisplayInformation
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

        public Employee(Guid id, decimal jobSalary, string name, string surname, string jobTittle, string jobDescription,
            string companyName, string companyCountry, string companyCity, string companyStreet)
        {
            _id = id;
            _jobSalary = jobSalary;
            _name = name;
            _surname = surname;
            _jobTittle = jobTittle;
            _jobDescription = jobDescription;
            _companyName = companyName;
            _companyCountry = companyCountry;
            _companyCity = companyCity;
            _companyStreet = companyStreet;
        }

        public Guid Id { get; }

        public decimal JobSalary { get; }

        public string Name { get; }

        public string Surname { get; }

        public string JobTitle { get; }

        public string JobDescription { get; }

        public string CompanyName { get; }

        public string CompanyCountry { get; }

        public string CompanyCity { get; }

        public string CompanyStreet { get; }
        

        public void DisplayInformation()
        {
            Console.WriteLine($"Hello, I am {Name} {Surname}, {JobTitle} in {CompanyName} ({CompanyCountry}, " +
                $"{CompanyCity}, {CompanyStreet}) and my salary is {JobSalary}");
        }

    }
}
