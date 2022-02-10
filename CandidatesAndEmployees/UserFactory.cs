using Bogus;
using System;

namespace Users
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

            var candidates = new Faker<Candidate>()
                .CustomInstantiator(fake =>
                    new Candidate(
                        guid,
                        fake.Name.FirstName(),
                        fake.Name.LastName(),
                        fake.PickRandom(JobMockData.Titles),
                        fake.PickRandom(JobMockData.Descriptions),
                        fake.Finance.Amount()));

            return candidates.Generate();
        }

        private Employee CreateEmployee()
        {
            return null; 
        }

    }
}
