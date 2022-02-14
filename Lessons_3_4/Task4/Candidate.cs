using System;

namespace Task4
{
    public class Candidate : IUser, IDisplayInformation
    {
        private readonly Guid _id;
        private readonly decimal _jobSalary;
        private readonly string _name;
        private readonly string _surname;
        private readonly string _jobTittle;
        private readonly string _jobDescription;

        public Candidate(Guid id, decimal jobSalary, string name, string surname, string jobTittle, string jobDescription)
        {
            _id = id;
            _jobSalary = jobSalary;
            _name = name;
            _surname = surname;
            _jobTittle = jobTittle;
            _jobDescription = jobDescription;
        }

        public Guid Id => _id;

        public decimal JobSalary => _jobSalary;

        public string Name => _name;

        public string Surname => _surname;

        public string JobTitle => _jobTittle;

        public string JobDescription => _jobDescription;


        public void DisplayInformation()
        {
            Console.WriteLine($"Hello, I am {Name} {Surname} I want to be a {JobTitle} ({JobDescription}) with a salary from { JobSalary}");
        }
    }
}
