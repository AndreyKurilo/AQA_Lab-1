using System;
using System.Collections.Generic;
using System.Text;

namespace CandidatesAndEmployees
{
    public class Candidate : IUser
    {
        private readonly Guid _id;
        private readonly decimal _jobSalary;
        private readonly string _name;
        private readonly string _surname;
        private readonly string _jobTittle;
        private readonly string _jobDescription;

        public Candidate(Guid id, decimal jobSalary, params string[] candidateArguments)
        {
            _id = id;
            _jobSalary = jobSalary;
            _name = candidateArguments[0];
            _surname = candidateArguments[1];
            _jobTittle = candidateArguments[2];
            _jobDescription = candidateArguments[3];
        }

        public Guid Id => _id;

        public decimal JobSalary => _jobSalary;

        public string Name => _name;

        public string Surname => _surname;

        public string JobTittle => _jobTittle;

        public string JobDescription => _jobDescription;


        public void DisplayInformation()
        {
            Console.WriteLine($"Hello, I am {Name} {Surname} I want to be a {JobTittle} ({JobDescription}) with a salary from {JobSalary}");
        }
    }
}
