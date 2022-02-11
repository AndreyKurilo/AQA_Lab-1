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

            IEnumerable<IGrouping<string, Candidate>> groupsSortedByTitle = candidates.GroupBy(x => x.JobTitle);

            var newCandidates = new List<Candidate>();

            foreach (var group in groupsSortedByTitle)
            {
                var newList = group.ToList();
                newList.Sort((a, b) => a.JobSalary.CompareTo(b.JobSalary));
                newCandidates.AddRange(newList);
            }

            foreach (var candidate in newCandidates)
                candidate.DisplayInformation();
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
