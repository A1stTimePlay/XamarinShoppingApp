using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinShoppingApp.Models;
using XamarinShoppingApp.Views.Bookmarks;

namespace XamarinShoppingApp.ViewModels.Cart
{
    class testVM
    {
        public testVM()
        {
            AddToCartCommand = new Command(AddToCart);
            ShowCartCommand = new Command(ShowCart);
        }
        public Command AddToCartCommand { get; } 
        public Command ShowCartCommand { get; }

        void AddToCart()
        {
            Product testProduct = new Product("category", "name", 100, 10, 5, "description", "image");
            Order_Detail test = new Order_Detail(1,1,testProduct,1);
            //Console.WriteLine(test.ProductDetail.Name_Product);
            App.CurrentCart.Add(test);

        }
        async void ShowCart()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CartPage());
        }
    }
}
