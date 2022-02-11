using Bogus;
using System;

namespace CandidatesAndEmployees
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
            Guid guid = Guid.NewGuid();

            var candidate = new Faker<Candidate>()
                .CustomInstantiator(fake =>
                    new Candidate(
                        guid,
                        fake.Name.FirstName(),
                        fake.Name.LastName(),
                        fake.PickRandom(JobMockData.Titles),
                        fake.PickRandom(JobMockData.Descriptions),
                        fake.Finance.Amount()));

            return candidate.Generate();
        }

        private Employee CreateEmployee()
        {
            Guid guid = Guid.NewGuid();

            var employee = new Faker<Employee>()
                .CustomInstantiator(fake =>
                   new Employee(
                       guid,
                       fake.Name.FirstName(),
                       fake.Name.LastName(),
                       fake.Name.JobTitle(),
                       fake.Name.JobDescriptor(),
                       fake.Finance.Amount(),
                       fake.Company.CompanyName(),
                       fake.Address.Country(),
                       fake.Address.City(),
                       fake.Address.StreetAddress()));                       

            return null; 
        }

    }
}
