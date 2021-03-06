using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinShoppingApp.Views.Forms;
using XamarinShoppingApp.Views.Catalog;

namespace XamarinShoppingApp
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        {
             InitializeComponent();
            MainPage = new NavigationPage(new SimpleLoginPage());
            
            
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
