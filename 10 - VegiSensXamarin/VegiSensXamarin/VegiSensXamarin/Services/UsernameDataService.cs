using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSensDomain;

namespace VegiSensXamarin.Services
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

        User IUsernameDataService.GetUserByName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
