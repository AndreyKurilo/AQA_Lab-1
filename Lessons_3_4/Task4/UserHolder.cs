﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class UserHolder
    {
        private const int MinUsersCount = 10;
        private const int MaxUsersCount = 20;
        private readonly List<IUser> users = new List<IUser>();
        private readonly UserFactory _userFactory;

        public IEnumerable<IUser> Users => users;

        public UserHolder(UserFactory userFactory)
        {
            _userFactory = userFactory;

            Generate();
        }

        private void Generate()
        {
            for (byte i = 0; i < Randomizer.GetRandomNumberBetween(MinUsersCount, MaxUsersCount); i++)
            {
                users.Add(_userFactory.Create(UserType.Candidate));
            }

            for (byte i = 0; i < Randomizer.GetRandomNumberBetween(MinUsersCount, MaxUsersCount); i++)
            {
                users.Add(_userFactory.Create(UserType.Employee));
            }
        }
    }
}
