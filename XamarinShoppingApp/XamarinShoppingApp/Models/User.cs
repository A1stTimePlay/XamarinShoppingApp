using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinShoppingApp.Models
{
    public class User
    {
        User(int id, String username, String password, String email)
        {
            this.ID = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
        public int ID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
    }
}
