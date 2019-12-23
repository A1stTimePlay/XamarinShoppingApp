using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShoppingApp.Models
{
    public class User
    {
        
        public User()
        {
           
        }
        
        public int ID { get; set; }
        public String Username { get; set; }
        public String PASS_WORD { get; set; }
        public String Email   { get; set; }
    }
}