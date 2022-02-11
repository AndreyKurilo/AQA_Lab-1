using System;
using System.Collections.Generic;
using System.Text;

namespace CandidatesAndEmployees
{
    public class СandidateReportGenerator: IReportGenerator
    {
        Candidate[] candidatesArray;
        public СandidateReportGenerator(List<Candidate> candidates)
        {
            candidatesArray = candidates.ToArray();
        }
        public void Sort()
        {
            List<Candidate> companyList = new List<Candidate>();


            for (int i = 0; i < candidatesArray.Length; i++)
            {
                if(String.Equals(candidatesArray[i].JobTittle, candidatesArray[i + 1].JobTittle)
                {


                }
            }
        }
    }
}
