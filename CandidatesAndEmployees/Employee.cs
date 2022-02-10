using System;
using System.Collections.Generic;
using System.Text;

namespace Users
{
    class Employee : IUser
    {
        private readonly int _id;
        private readonly string _name;
        private readonly string _surname;
        private readonly string _jobTittle;
        private readonly string _jobDescription;
        private readonly double _jobSalary;
        private readonly string _companyName;
        private readonly string _companyCountry;
        private readonly string _companyCity;
        private readonly string _companyStreet;

        public Employee(int id, string name, string surname, string jobTittle, string jobDescription,
            double jobSalary, string companyName, string companyCountry, string companyCity, string companyStreet)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _jobTittle = jobTittle;
            _jobDescription = jobDescription;
            _jobSalary = jobSalary;
            _companyName = companyName;
            _companyCountry = companyCountry;
            _companyCity = companyCity;
            _companyStreet = companyStreet;
        }

        public int Id => _id;

        public string Name { get; }

        public string Surname { get; }

        public string JobTittle { get; }

        public string JobDescription { get; }

        public double JobSalary { get; }

        public string CompanyName { get; }

        public string CompanyCountry { get; }

        public string CompanyCity { get; }

        public string CompanyStreet { get; }
        

        public void DisplayInformation()
        {
            System.Guid guid = System.Guid.NewGuid();
            Console.WriteLine(guid.ToString());

        }

    }
}
