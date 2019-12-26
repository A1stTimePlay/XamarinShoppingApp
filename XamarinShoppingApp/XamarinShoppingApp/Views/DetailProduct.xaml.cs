using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinShoppingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailProduct : ContentPage
    {
        public DetailProduct(string name, string detail, string image, double price, int rating)
        {
            InitializeComponent();
            LabelName.Text = name;
            Detail.Text = detail;
            PRICE1.Text = price.ToString();
            IMAGE1.Source = image;
        }
    }
}