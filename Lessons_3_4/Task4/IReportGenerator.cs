using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    interface IReportGenerator
    {
        void GenerateReportFor(IEnumerable<IUser> users);
    }
}
