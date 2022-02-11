using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidatesAndEmployees
{
    public class CandidateReportGenerator : IReportGenerator
    {
        public void GenerateReportFor(IEnumerable<IUser> users)
        {
            var candidates = GetCandidatesFrom(users);

            var sortedCandidatesByTitleAndSalary = new List<Candidate>();

            foreach (var groupSortedByTitle in candidates.GroupBy(x => x.JobTitle))
            {
                var sortedByTitleAndSalary = SortBySalary(groupSortedByTitle.ToList());
                sortedCandidatesByTitleAndSalary.AddRange(sortedByTitleAndSalary);
            }

            Print(sortedCandidatesByTitleAndSalary);
        }

        private void Print(List<Candidate> candidates)
        {
            Console.WriteLine(("").PadRight(123, '-'));
            Console.WriteLine("{0} {1,22 } {0,20} {2,15} {0,7} {3, 23} {0,14} {4,10} {0,3}", "|", "UserId",  "Full name", 
                "Job title", "Salary");
            Console.WriteLine(("").PadRight(123, '-'));
            foreach (var candidate in candidates)
            {
                var fullName = $"{candidate.Name} {candidate.Surname}";
                var salary = $"$ {candidate.JobSalary}";
                Console.WriteLine($"|\t{candidate.Id,18}|\t{fullName,20}|\t{candidate.JobTitle,35}|\t{salary,10}|");
            }
            Console.WriteLine(("").PadRight(123, '-'));
        }

        private List<Candidate> SortBySalary(List<Candidate> candidates)
        {
            candidates.Sort((a, b) => a.JobSalary.CompareTo(b.JobSalary));
            return candidates;
        }

        private List<Candidate> GetCandidatesFrom(IEnumerable<IUser> users)
        {
            List<Candidate> candidates = new List<Candidate>();

            foreach (IUser user in users)
                if (user is Candidate)
                    candidates.Add(user as Candidate);

            return candidates;
        }
    }
}
