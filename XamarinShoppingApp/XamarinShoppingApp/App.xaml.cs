using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinShoppingApp.Models;
using XamarinShoppingApp.Views.Bookmarks;
using XamarinShoppingApp.Views.Cart;
using XamarinShoppingApp.Views.Catalog;
using XamarinShoppingApp.Views.Forms;

namespace XamarinShoppingApp
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public static string BaseApiUrl { get; } = "http://192.168.1.236:3000/";
        public static User CurrentUser { get; set; }

        public static List<Order_Detail> CurrentCart { get; set; }
        public static Order CurrentOrder { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ProductHomePage());
            CurrentCart = new List<Order_Detail>();
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
