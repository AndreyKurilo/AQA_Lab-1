using System;
using System.Collections.Generic;
using System.Text;

namespace CandidatesAndEmployees
{
    public class UserHolder
    {
        private readonly List<IUser> users = new List<IUser>();
        private UserFactory _userFactory;

        public IEnumerable<IUser> Users => users;

        public UserHolder(UserFactory userFactory)
        {
            _userFactory = userFactory;

            Generate();
        }

        private byte GenenerateNumberOfUsers()
        {
            Random rnd = new Random();
            byte usersRandomAmount = (byte) rnd.Next(10, Byte.MaxValue/2);

            return usersRandomAmount;
        }

        private void Generate()
        {
            for (byte i = 0; i < GenenerateNumberOfUsers(); i++)
            {
                users.Add(_userFactory.Create(UserType.Candidate));
            }

            for (byte i = 0; i < GenenerateNumberOfUsers(); i++)
            {
                users.Add(_userFactory.Create(UserType.Employee));
            }
        }
    }
}
