using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinShoppingApp.Models;
using XamarinShoppingApp.ViewModels.Forms;
using XamarinShoppingApp.Views.Forms;


namespace XamarinShoppingApp.ViewModels
{
    public class MyListPageProductViewModel
    {

        public ObservableCollection<Product> ProductList { get; set; } = new ObservableCollection<Product>();

        public MyListPageProductViewModel(string category)
        {

            using (HttpClient Client = new HttpClient())
            {
                var jsonString = Client.GetStringAsync("http://192.168.137.72:3000/Products/" + category).Result;
                ProductList = Product.FromJson(jsonString);
                Console.WriteLine(ProductList);
            }
        }
    }
}
/*
public async Task ListProductClick(object obj)
{
    var httpClient = new HttpClient();
    ProductList = new ObservableCollection<Product>();
    ObservableCollection<Product> list = new ObservableCollection<Product>();
    string respone = await httpClient.GetStringAsync("http://192.168.137.237:3000/Products/" + txt);
    list = JsonConvert.DeserializeObject<ObservableCollection<Product>>(respone);
    foreach (var ele in list)
    {
        ProductList.Add(ele);
    }
    Console.WriteLine(ProductList);
}*/



/*
public ObservableCollection<Product> ProductList
{
    get
    {
        return products;
    }
    set
    {
        Set(ref products, value);
        RaisePropertyChanged(nameof(ProductList));
    }
}

private void Set(ref ObservableCollection<Product> products, ObservableCollection<Product> value)
{
    throw new NotImplementedException();
}

public async Task<ObservableCollection<Product>> GetProducts()
{
    string txt = "Ví da";
    if (ProductList == null)
    {
        HttpClient Client = new HttpClient();
        HttpResponseMessage responseMessage = await Client.GetAsync("http://192.168.137.183:3000/Products/"+txt);

        if (responseMessage.IsSuccessStatusCode)
        {
            var Jsonresponse = await Client.GetStringAsync("http://192.168.137.183:3000/Products/"+txt);
            var ProductModel = JsonConvert.DeserializeObject<ObservableCollection<Product>>(Jsonresponse);
            return ProductModel;
        }
    }
    return ProductList;
}
private async Task InitaializeDataAsync()
{
    ProductList = await GetProducts();
}
public event PropertyChangedEventHandler PropertyChanged;
protected void RaisePropertyChanged(string propertyName)
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
private string _IMAGE;
public string IMAGE
{
    get
    {
        return _IMAGE;
    }
    set
    {

        _IMAGE = value;
        RaisePropertyChanged(nameof(IMAGE));
    }
}
private string _NAME_PRODUCT;
public string NAME_PRODUCT
{
    get
    {
        return _NAME_PRODUCT;
    }
    set
    {

        _NAME_PRODUCT = value;
        RaisePropertyChanged(nameof(NAME_PRODUCT));
    }
}

private double _PRICE;
public double PRICE
{
    get
    {
        return _PRICE;
    }
    set
    {

        _PRICE = value;
        RaisePropertyChanged(nameof(PRICE));
    }
}

private int _RATING;
public int RATING
{
    get
    {
        return _RATING;
    }
    set
    {

        _RATING = value;
        RaisePropertyChanged(nameof(RATING));
    }
}



}
}*/
