using Bogus;
using System;

namespace Task4
{
    public class UserFactory
    {
        public IUser Create(UserType userType)
        {
            IUser user = null;


            switch(userType)
            {
                case UserType.Candidate:
                    user = CreateCandidate();
                    break;
                case UserType.Employee:
                    user = CreateEmployee();
                    break;
            }

            return user;
        }

        private Candidate CreateCandidate()
        {
            var guid = Guid.NewGuid();

            var candidate = new Faker<Candidate>()
                .CustomInstantiator(fake =>
                    new Candidate(
                        guid,
                        fake.Finance.Amount(),
                        fake.Name.FirstName(),
                        fake.Name.LastName(),
                        fake.Name.JobTitle(),
                        fake.Name.JobDescriptor()));

            return candidate.Generate();
        }

        private Employee CreateEmployee()
        {
            var guid = Guid.NewGuid();

            var employee = new Faker<Employee>()
                .CustomInstantiator(fake =>
                   new Employee(
                       guid,
                       fake.Finance.Amount(),
                       fake.Name.FirstName(),
                       fake.Name.LastName(),
                       fake.Name.JobTitle(),
                       fake.Name.JobDescriptor(),
                       fake.Company.CompanyName(),
                       fake.Address.Country(),
                       fake.Address.City(),
                       fake.Address.StreetAddress()));                       

            return employee; 
        }
    }
}
