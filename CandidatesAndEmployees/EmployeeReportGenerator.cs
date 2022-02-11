using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidatesAndEmployees
{
    public class EmployeeReportGenerator: IReportGenerator
    {
        public void GeneratesReportFor(IEnumerable<IUser> users)
        {
            var employees = GetEmployeesFrom(users);

            var sortedEmployeesByCompanyAndSalary = new List<Employee>();

            foreach (var groupSortedByCompany in employees.GroupBy(x => x.CompanyName))
            {
                var sortedByTitleAndSalary = SortBySalary(groupSortedByCompany.ToList());
                sortedEmployeesByCompanyAndSalary.AddRange(sortedByTitleAndSalary);
            }

            Print(sortedEmployeesByCompanyAndSalary);

        }
        private void Print(List<Employee> employees)
        {
            foreach (var employee in employees)
                employee.DisplayInformation();
        }

        private List<Employee> SortBySalary(List<Employee> employees)
        {
            employees.Sort((a, b) => b.JobSalary.CompareTo(a.JobSalary));
            return employees;
        }

        private List<Employee> GetEmployeesFrom(IEnumerable<IUser> users)
        {
            List<Employee> employees = new List<Employee>();

            foreach (IUser user in users)
                if (user is Employee)
                    employees.Add(user as Employee);

            return employees;
        }

    }
}
