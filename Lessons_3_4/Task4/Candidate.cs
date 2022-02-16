using System;

namespace Task4
{
    public class Candidate : IUser, IDisplayInformation
    {
        public Candidate(Guid id, decimal jobSalary, string name, string surname, string jobTittle, string jobDescription)
        {
            Id = id;
            JobSalary = jobSalary;
            Name = name;
            Surname = surname;
            JobTitle = jobTittle;
            JobDescription = jobDescription;
        }

        public Guid Id { get; }

        public decimal JobSalary { get; }

        public string Name { get; }

        public string Surname { get; }

        public string JobTitle { get; }

        public string JobDescription { get; }


        public void DisplayInformation()
        {
            Console.WriteLine($"Hello, I am {Name} {Surname} I want to be a {JobTitle} ({JobDescription}) with a salary from { JobSalary}");
        }
    }
}
