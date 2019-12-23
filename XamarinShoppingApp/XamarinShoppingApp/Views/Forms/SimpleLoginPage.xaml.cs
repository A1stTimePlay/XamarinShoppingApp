using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinShoppingApp.ViewModels.Login;

namespace XamarinShoppingApp.Views.Login
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