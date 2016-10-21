using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensDomain;

namespace VegiSens.DAL
{
    public interface IUserRepository
    {
        User GetUserByName(string username);
    }
}
