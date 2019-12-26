﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShoppingApp.Models
{
    public class Order_Detail
    {
        public Order_Detail() { }
        public Order_Detail(int id_order, Product productDetail, int quantity)
        {
            Id_Order = id_order;
            ProductDetail = productDetail;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public int Id_Order { get; set; }
        public int Quantity { get; set; }

        public List<object> Quantities { get; set; } = new List<object> { 1, 2, 3, 4, 5 };

        public Product ProductDetail { get; set; }
    }
}
