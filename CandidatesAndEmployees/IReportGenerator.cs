using System;
using System.Collections.Generic;
using System.Text;

namespace CandidatesAndEmployees
{
    interface IReportGenerator
    {
        void GeneratesReportFor(IEnumerable<IUser> users);
    }
}
