using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.DAL;
using VegiSens.domain;
using VegiSens.Services;

namespace VegiSens.Test.Mocks
{
    public class MockUsernameDataService : IUsernameDataService
    {

        //Properties
        IUserRepository repository = new MockUserRepository();

        //Constructor
        public MockUsernameDataService()
        {

        }

        //Methods

        public User GetUserByName(string username)
        {
            return repository.GetUserByName(username);
        }
    }
}
