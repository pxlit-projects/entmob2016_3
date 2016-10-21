﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiSensXamarin.Constants;
using Windows.UI.Xaml;
using Xamarin.Forms;

namespace VegiSensXamarin.Services
{
    public class FrameNavigationService : INavigationService
    {
        private ContentPage GetPage(string pageName, object objectToPass = null)
        {
            switch (pageName)
            {
                case PageUrls.MenuView: return new GroentenMenu();
                case PageUrls.DetailView: return new GroentenDetail();
            }
            return null;
        }

        public INavigation Navigation { get; set; }

        public IReadOnlyList<Page> ModalStack
        {
            get
            {
                return Navigation.ModalStack;
            }
        }

        public IReadOnlyList<Page> NavigationStack
        {
            get
            {
                return Navigation.NavigationStack;
            }
        }

        public void InsertPageBefore(string pageName, string beforeName)
        {
            Navigation.InsertPageBefore(GetPage(pageName), GetPage(beforeName));
        }

        public Task<Page> PopAsync()
        {
            return Navigation.PopAsync();
        }

        public Task<Page> PopAsync(bool animated)
        {
            return Navigation.PopAsync(animated);
        }

        public Task<Page> PopModalAsync()
        {
            return Navigation.PopModalAsync();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return Navigation.PopModalAsync(animated);
        }

        public Task PopToRootAsync()
        {
            return Navigation.PopToRootAsync();
        }

        public Task PopToRootAsync(bool animated)
        {
            return Navigation.PopToRootAsync(animated);
        }

        public Task PushAsync(string pageName)
        {
            return Navigation.PushAsync(GetPage(pageName));
        }

        public Task PushAsync(string pageName, object objectToPass)
        {
            ContentPage page = GetPage(pageName);
            //page.ViewModel.PassedDataContext = objectToPass;
            return Navigation.PushAsync(page);
        }

        public Task PushAsync(string pageName, bool animated)
        {
            return Navigation.PushAsync(GetPage(pageName), animated);
        }

        public Task PushModalAsync(string pageName, object objectToPass)
        {
            ContentPage page = GetPage(pageName, objectToPass);
            //page.ViewModel.PassedDataContext = objectToPass;
            return Navigation.PushModalAsync(page);
        }

        public Task PushModalAsync(string pageName, bool animated)
        {
            return Navigation.PushModalAsync(GetPage(pageName), animated);
        }

        public void RemovePage(string pageName)
        {
            Navigation.RemovePage(GetPage(pageName));
        }

        public void PushAsync(object burgerDetailView)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(string pageName)
        {
            return Navigation.PushModalAsync(GetPage(pageName));
        }
    }
}
