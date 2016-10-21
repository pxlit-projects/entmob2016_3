using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensDomain;

namespace VegiSensXamarin.Services
{
    public interface IUsernameDataService
    {
        User GetUserByName(string username);
    }
}
