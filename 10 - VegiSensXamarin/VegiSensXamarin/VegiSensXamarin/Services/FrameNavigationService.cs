using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VegiSensXamarin.Services
{
    public class FrameNavigationService : IFrameNavigation
    {
        //Get the current frame
        private Frame currentFrame = (Frame)Window.Current.Content;

        //Contructor
        public FrameNavigationService()
        {
        }

        //Navigate to given frametype
        public void NavigateToFrame(Type frameTypeToNavigate)
        {
            currentFrame.Navigate(frameTypeToNavigate);
        }
    }
}
