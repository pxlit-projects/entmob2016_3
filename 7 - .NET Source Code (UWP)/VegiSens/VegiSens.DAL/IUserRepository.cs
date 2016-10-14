using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSens.domain;
using System.Collections.ObjectModel;

namespace VegiSens.DAL
{
    public interface IUserRepository
    {
        User GetUserByName(string username);
    }
}
