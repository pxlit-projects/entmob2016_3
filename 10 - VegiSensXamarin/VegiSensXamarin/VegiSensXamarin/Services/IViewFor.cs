using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegiSensXamarin.Services
{
    public interface IViewFor
    {
        object ViewModel { get; set; }
    }

    public interface IViewFor<T> : IViewFor where T : BaseViewModel
    {
        T ViewModel { get; set; }
    }
}
