using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prism.Unity;
using UNLMaps.ViewModels;
using UNLMaps.Views;
using Xamarin.Forms;

namespace UNLMaps
{
    public class App : PrismApplication
    {
        public App()
        {
            // The root page of your application
        }

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            // NavigationPage.SetHasNavigationBar(this, false);
            //  MainPage = new NavigationPage(new MainPage());

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

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("NavigationPage/MapsPage", animated: true);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MapsPage, MapsPageViewModel>();
            Container.RegisterTypeForNavigation<CreatePinPage, CreatePinPageViewModel>();
        }
    }
}
