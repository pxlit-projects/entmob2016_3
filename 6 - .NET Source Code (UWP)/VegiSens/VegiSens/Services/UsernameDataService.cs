using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;
using VegiSens.DAL;
using System.Collections.ObjectModel;

namespace VegiSens.Services
{
    public class UsernameDataService : IUsernameDataService
    {

        //Properties
        IUserRepository repository;

        //Constructor
        public UsernameDataService(IUserRepository repository)
        {
            this.repository = repository;
        }

        //Methods

        public User GetUserByName(string username)
        {
            return repository.GetUserByName(username);
        }
    }
}
