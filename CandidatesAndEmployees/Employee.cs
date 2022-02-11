using System;

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

        public Guid Id => _id;

        public decimal JobSalary => _jobSalary;

        public string Name => _name;

        public string Surname => _surname;

        public string JobTitle => _jobTittle;

        public string JobDescription => _jobDescription;

        public string CompanyName => _companyName;

        public string CompanyCountry => _companyCountry;

        public string CompanyCity => _companyCity;

        public string CompanyStreet => _companyStreet;

        public void DisplayInformation()
        {
            Console.WriteLine($"Hello, I am {Name} {Surname}, {JobTitle} in {CompanyName} ({CompanyCountry}, " +
                $"{CompanyCity}, {CompanyStreet}) and my salary is {JobSalary}");
        }

    }
}
