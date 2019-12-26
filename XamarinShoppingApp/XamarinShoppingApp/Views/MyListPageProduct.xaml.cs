using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinShoppingApp.ViewModels.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinShoppingApp.Models;
using XamarinShoppingApp.Views;
using XamarinShoppingApp.ViewModels;
using XamarinShoppingApp.Views.Detail;

namespace XamarinShoppingApp.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyListPageProduct : ContentPage
    {
        MyListPageProductViewModel vm;
        public MyListPageProduct(string category)
        {
            InitializeComponent();
            vm = new MyListPageProductViewModel(category);
            BindingContext = vm;
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
           
            var detail = e.Item as Product;
            Console.WriteLine("Name product is :" + detail.Name_Product);
            await Application.Current.MainPage.Navigation.PushAsync(new DetailPage(detail));
        }
    }
}