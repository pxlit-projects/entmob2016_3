using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;
using System.Collections.ObjectModel;

namespace VegiSens.Services
{
    public interface IUsernameDataService
    {
        User GetUserByName(string username);
    }
}
