using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4
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

            Console.WriteLine(("").PadRight(123, '-'));
            Console.WriteLine("{0} {1,22 } {0,20} {2,21} {0,16} {3, 15} {0,8} {4,10} {0,2}", "|", "UserId", "Company Name", "Full name", "Salary");
            Console.WriteLine(("").PadRight(123, '-'));
            foreach (var employee in employees)
            {
                var fullName = $"{employee.Name} {employee.Surname}";
                var salary = $"$ {employee.JobSalary}";
                Console.WriteLine($"|\t{employee.Id, 18}|\t{employee.CompanyName,35}|\t{fullName, 20}|\t{salary, 10}|");
            }
            Console.WriteLine(("").PadRight(123, '-'));

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
