using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensXamarin.Constants;
using Xamarin.Forms;

namespace VegiSensXamarin.Services
{
    public class FrameNavigationService : IFrameNavigation
    {
        //Get the current frame

        //Contructor
        public FrameNavigationService()
        {
        }
        
            public void NavigateTo(string pageKey)
            {
                if (pageKey == "Detail")
                {
                    App.Current.MainPage = new GroentenDetail();
                }
            }

    }
}
