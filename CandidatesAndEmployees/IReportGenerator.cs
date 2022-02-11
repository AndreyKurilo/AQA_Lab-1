using System;
using System.Collections.Generic;
using System.Text;

namespace CandidatesAndEmployees
{
    interface IReportGenerator
    {
        void Sort(IEnumerable<IUser> users);
    }
}
