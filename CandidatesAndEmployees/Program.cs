using System;

namespace CandidatesAndEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            var userFactory = new UserFactory();
            var userHolder = new UserHolder(userFactory);

            foreach (IUser user in userHolder.Users)
            {
                user.DisplayInformation();
            }
        }
    }
}
