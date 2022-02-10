using System;
using System.Collections.Generic;
using System.Text;

namespace users
{
    public class Candidate : IUsers
    {
        private readonly int id;
        private readonly string name;
        private readonly string surname;
        private readonly string jobTittle;
        private readonly string jobDescription;
        private readonly double jobSalary;

        public int Id { get 
            {
                return id; 
            }
            set 
            { 
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
            }
        }

        public string JobTittle
        {
            get
            {
                return jobTittle;
            }
            set
            {
            }
        }

        public string JobDescription
        {
            get
            {
                return jobDescription;
            }
            set
            {
            }
        }

        public double JobSalary
        {
            get
            {
                return jobSalary;
            }
            set
            {
            }
        }

        public void Create()
        {
            string typeOfuser = "Candidate";
            UserFactory userFactory = new UserFactory(typeOfuser);
        }


        public void DisplayInformation()
        {
            System.Guid guid = System.Guid.NewGuid();
            Console.WriteLine(guid.ToString());

        }
    }
}
