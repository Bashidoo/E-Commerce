using E_Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comemrce
{
    public class User<T>
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User<T>? CurrentUserSession { get; set; }

        public List<Product> ProductList { get; set; } = new List<Product>();


        public User(string email, string password, string name) 
        {
            Name = name;
            Email = email;
            Password = password;
             
        }
    }
}
