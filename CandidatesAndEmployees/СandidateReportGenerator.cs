using System;
using System.Collections.Generic;
using System.Text;

namespace CandidatesAndEmployees
{
    public class СandidateReportGenerator: IReportGenerator
    {
        public void Sort(IEnumerable<IUser> users)
        {
            foreach(var user in users)
            {
                if(user is Candidate)
                { 
                }
            }

            //for (int i = 0; i < candidatesArray.Length; i++)
            //{
            //    if(String.Equals(candidatesArray[i].JobTittle, candidatesArray[i + 1].JobTittle))
            //    {


            //    }
            //}
        }
    }
}
