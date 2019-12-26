using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamarinShoppingApp.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(string category, string name_Product, float price, int sale_Percent, int rating, string product_Detail, string image)
        {
            Category = category;
            Name_Product = name_Product;
            Price = price;
            Sale_Percent = sale_Percent;
            Rating = rating;
            Product_Detail = product_Detail;
            Image = image;
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Name_Product { get; set; }
        public float Price { get; set; }
        public int Sale_Percent { get; set; }
        public int Rating { get; set; }
        public string Product_Detail { get; set; }
        public string Image { get; set; }
        public double DiscountPrice
        {
            get
            {
                return Price - (Price* Sale_Percent/100);
            }

        }

        public static ObservableCollection<Product> FromJson(string json) => JsonConvert.DeserializeObject<ObservableCollection<Product>>(json, Converter.Settings);
    }
}
