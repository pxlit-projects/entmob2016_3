using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VegiSensXamarin.Services
{
    public interface IFrameNavigation
    {
        void NavigateTo(string pageKey);
    }
}
