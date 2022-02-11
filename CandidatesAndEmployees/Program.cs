using System;

namespace CandidatesAndEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            var userFactory = new UserFactory();
            var userHolder = new UserHolder(userFactory);
            var candidateReportGenerator = new CandidateReportGenerator();

            candidateReportGenerator.Sort(userHolder.Users);
        }
    }
}
