using System;
using System.Collections.Generic;
using System.Text;

namespace users
{
    class UserFactory
    {
        public UserFactory(string typeOfClent)
        {

            System.Guid guid = System.Guid.NewGuid();
            Console.WriteLine(guid.ToString());


            Candidate candidate = new Candidate(int id, string name, string surname, string jobTitle,
                string jobDescription, double jobSalary);

            Employee employee = new Employee(int id, string name, string surname, string jobTittle,
                string jobDescription, double jobSalary, string companyName, string companyCountry,
                string companyCity, string companyStreet);

        }

    }
}
