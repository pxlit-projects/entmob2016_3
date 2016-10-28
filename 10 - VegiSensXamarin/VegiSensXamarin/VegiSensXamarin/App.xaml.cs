using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VegiSensXamarin.Locator;
using VegiSensXamarin.Services;
using Xamarin.Forms;
using XLabs.Forms.Services;

namespace VegiSensXamarin
{
    public partial class App : Application
    {
        private ViewModelLocator locator;

        public App()
        {
            InitializeComponent();
            locator = new ViewModelLocator();


            var groentenMenu = new GroentenMenu();

            
            MainPage = new NavigationPage(groentenMenu);
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
