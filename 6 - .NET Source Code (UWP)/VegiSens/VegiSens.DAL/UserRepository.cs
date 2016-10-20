using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;

namespace VegiSens.DAL
{
    public class UserRepository : IUserRepository
    {
        //Properties
        private static ObservableCollection<User> users;

        //Constructor
        public UserRepository()
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
                    Username = "arno",
                    Password = "pxl"
                },
                new User ()
                {
                    UserId = 2,
                    Username = "niels",
                    Password = "pxl"
                }
            };
        }
    }
}
