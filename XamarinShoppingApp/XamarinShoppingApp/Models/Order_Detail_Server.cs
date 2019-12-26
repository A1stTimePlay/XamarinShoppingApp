using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShoppingApp.Models
{
    class Order_Detail_Server
    {
        public Order_Detail_Server() { }
        public Order_Detail_Server(Order_Detail order_Detail)
        {
            Id_Order = order_Detail.Id_Order;
            Id_Product = order_Detail.ProductDetail.Id;
            Quantity = order_Detail.Quantity;
        }
        public int Id_Order { get; set; }
        public int Id_Product { get; set; }
        public int Quantity { get; set; }
    }
}
