using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VegiSensXamarin.Services
{
    public class NavigationService : INavigationService
    {
        private const String DATAIL_VIEW = "Detail";
        private const String MENU_VIEW = "Menu";

        public void NavigateTo(string pageKey)
        {
            switch (pageKey)
            {
                case DATAIL_VIEW:
                    App.Current.MainPage = new GroentenDetail();
                    break;
                case MENU_VIEW:
                    App.Current.MainPage = new GroentenMenu();
                    break;
            }
        }
    }
   } 
