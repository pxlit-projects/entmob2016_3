using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSens.domain;

namespace VegiSens.Test.Mocks
{
    public class MockUserRepository : IUserRepository
    {
        //Properties
        private static ObservableCollection<User> users;

        //Constructor
        public MockUserRepository()
        {
        }

        //Methods
        public User GetUserByName(string username)
        {
            if (users == null)
            {
                loadUsers();
            }

            return users.Where(u => u.Username == username).FirstOrDefault();
        }

        //Load all data
        private void loadUsers()
        {
            users = new ObservableCollection<User>()
            {
                new User ()
                {
                    UserId = 1,
                    Username = "Arno Bruynseels",
                    Password = "arnopxl"
                },
                new User ()
                {
                    UserId = 2,
                    Username = "Niels Carmans",
                    Password = "nielspxl"
                }
            };
        }
    }
}
