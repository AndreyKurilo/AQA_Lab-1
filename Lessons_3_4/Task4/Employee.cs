using System;

namespace Task4
{
    class Employee : IUser, IDisplayInformation
    {
        public Employee(Guid id, decimal jobSalary, string name, string surname, string jobTittle, string jobDescription,
            string companyName, string companyCountry, string companyCity, string companyStreet)
        {
            Id = id;
            JobSalary = jobSalary;
            Name = name;
            Surname = surname;
            JobTitle = jobTittle;
            JobDescription = jobDescription;
            CompanyName = companyName;
            CompanyCountry = companyCountry;
            CompanyCity = companyCity;
            CompanyStreet = companyStreet;
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
