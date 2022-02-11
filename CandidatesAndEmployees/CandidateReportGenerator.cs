using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidatesAndEmployees
{
    public class CandidateReportGenerator : IReportGenerator
    {
        public void Sort(IEnumerable<IUser> users)
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
            foreach (var candidate in candidates)
                candidate.DisplayInformation();
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
