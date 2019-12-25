using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShoppingApp.Models
{
    public class Order
    {
        public Order()
        {

        }

        public int Id { get; set; }
        public int Id_User { get; set; }
        public string Order_Date { get; set; }

        public int Confirmation { get; set; }
    }
}
