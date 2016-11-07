using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VegiSens.DAL;
using VegiSensXamarin.Locator;
using VegiSensXamarin.Services;
using VegiSensXamarin.ViewModel;
using Xamarin.Forms;
using XLabs.Forms.Services;

namespace VegiSensXamarin
{
    public partial class App : Application
    {
        private GroentenMenu groentenMenu;

        public App()
        {
            try
            {
                InitializeComponent();

                groentenMenu = new GroentenMenu();

                MainPage = new NavigationPage(groentenMenu);

            }
            catch (Exception ex)
            {
                object messages = ex.InnerException;
            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
