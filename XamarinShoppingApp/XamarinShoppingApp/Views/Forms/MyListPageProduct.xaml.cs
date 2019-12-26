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

namespace XamarinShoppingApp.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyListPageProduct : ContentPage
    {
        MyListPageProductViewModel vm;
        //string category = "Ví da";
        public MyListPageProduct(string category)
        {
            InitializeComponent();
            vm = new MyListPageProductViewModel(category);
            BindingContext = vm;
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
           
            var detail = e.Item as Product;
            // await NavigationPage=new NavigationPage(new view(detail.NAME_PRODUCT,detail.PRODUCT_DETAIL));
            Console.WriteLine("Name product is :" + detail.NAME_PRODUCT);
            await Application.Current.MainPage.Navigation.PushAsync(new DetailProduct(detail.NAME_PRODUCT, detail.PRODUCT_DETAIL, detail.IMAGE, detail.PRICE, detail.RATING));
            Console.WriteLine("Đã tới đây");
        }
    }
}