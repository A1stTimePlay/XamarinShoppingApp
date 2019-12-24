using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace XamarinShoppingApp.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleLoginPage : ContentPage
    {
        //LoginPageViewModel login;
        public SimpleLoginPage()
        {
            InitializeComponent();
            //login = new LoginPageViewModel(this);
        }
    }
}