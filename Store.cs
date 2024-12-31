using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class Store<T>
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List <User<T>> Users { get; set; } = new List<User<T>>();


        public User<T>? UserLogin (string email, string password)
        {
            bool running = true;

            while (running)
            {
                var user = Users.FirstOrDefault(x => x.Email == email && x.Password == password);

                if (user != null)
                {
                    if (user.Password == password && user.Email == email)
                    {
                        user = user.CurrentUserSession;
                        running = false;
                        return user;
                    }
                    else
                    {
                        AnsiConsole.MarkupLine($"[red]Incorrect details, please try another password or username.[/]");
                        return null;
                    }
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]User not found Please try again.[/]");

                    return null;
                }
            }
        }
        public void AddProduct(Product product)
        {

            var occupiedProduct = Products. FirstOrDefault(x => x.ProductName == product.ProductName);
            if (occupiedProduct != null)
            {

                AnsiConsole.MarkupLine($"[red]Product ID is already taken![/]");
                return;
            }

            else
            {
                Products.Add(product);
            }
        }

        public void RemoveProduct(Product product)
        {
           

            Products.Remove(product);


        }



    }
}
