using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CandidatesAndEmployees
{
    public class EmployeeReportGenerator: IReportGenerator
    {
        public void GenerateReportFor(IEnumerable<IUser> users)
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

            Console.WriteLine(("").PadRight(83, '-'));
            Console.WriteLine("{0} {1,25} {0,16} {2, 15} {0,8} {3,10} {0,2}", "|", "Company Name", "Full name", "Salary");
            Console.WriteLine(("").PadRight(83, '-'));
            foreach (var employee in employees)
            {
                Console.WriteLine($"|\t{employee.CompanyName,35}|\t{employee.Name, 20}|\t${employee.JobSalary, 10}|");
            }
            Console.WriteLine(("").PadRight(83, '-'));

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
