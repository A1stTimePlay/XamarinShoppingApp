using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamarinShoppingApp.Models
{
    public partial class Product
    {
        public int ID { get; set; }
        public string CATEGORY { get; set; }
        public string NAME_PRODUCT { get; set; }
        public double PRICE { get; set; }
        public int SALE_PERCENT { get; set; }
        public int RATING { get; set; }
        public string PRODUCT_DETAIL { get; set; }
        public string IMAGE { get; set; }

    }
    public partial class Product
    {
        public static ObservableCollection<Product> FromJson(string json) => JsonConvert.DeserializeObject<ObservableCollection<Product>>(json, Converter.Settings);
    }
}
