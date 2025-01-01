using E_Comemrce;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class Store<T>
    {
        
        public List<Product> Products { get; set; } = new List<Product>();
        public List <User<T>> Users { get; set; } = new List<User<T>>();
        public List<CardInfo> Cards { get; set; } = new List<CardInfo>();


        public User<T>? UserLogin(string email, string password)
        {
            Console.WriteLine($"Attempting to log in with Email: '{email}', Password: '{password}'");

            // Search for a matching user
            var user = Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user != null)
            {
                Console.WriteLine("[green]Login successful![/]");
                return user;
            }

            Console.WriteLine("[red]Invalid email or password.[/]");
            return null;
        }
      
        public void SearchProduct()
        {


            string? productPrompt = Utility.GetValidatedStringInput("[green]Enter ProductName To seacrh.[/]");
           var filteredProducts = Products.Select(x => x.ProductName == productPrompt).ToList();
            foreach (var product in filteredProducts)
            {
                AnsiConsole.Markup(product.ToString());
            }


        }

        public void SortByProducts()
        {
            AnsiConsole.MarkupLine($"[blue]How would you like to sort your items? (1.Price,2.Name,3.Category) [/]");

            char? choice = Convert.ToChar(Console.ReadKey());

            var filteredProducts = Products.AsQueryable();
            switch (choice)
            {
                case '1':
                    filteredProducts.OrderBy(x => x.Price);
                break;
                case '2':
                    filteredProducts.OrderBy(x => x.ProductName);
                    break;
                case '3':
                    filteredProducts.OrderBy(x => x.Category);
                break;                    
            }
      

            if (filteredProducts.Any())
            {
                string? input = Utility.GetValidatedStringInput("[green]Search Results: ↓. Press 1 to reverse order ↑ or 2 blank to continue[/]");
                if (input == "1")
                {
                    filteredProducts.Reverse();
                    foreach (var product in filteredProducts)
                    {
                        AnsiConsole.Markup(product.ToString());
                    }

                }
                else if (input == "2")
                {
                    foreach (var product in filteredProducts)
                    {
                        AnsiConsole.Markup(product.ToString());
                    }
                }
                else
                {
                    AnsiConsole.Markup("Please write valid input.");
                    return;
                }

            }
            else
            {
                AnsiConsole.MarkupLine($"[red]No products found, please add products.[/]");

            }

        }
        public void AddProduct(Product product)
        {

            var occupiedProduct = Products.FirstOrDefault(x => x.ProductName == product.ProductName && x.ProductId == product.ProductId);
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

        public void RemoveProduct()
        {
            int ProductID = Utility.GetValidatedNumberInput("Please Enter Product");

            var ProductToRemove = Products.FirstOrDefault(x => x.ProductId == ProductID);

            if (ProductToRemove != null)
            {
                Products.Remove(ProductToRemove);
                AnsiConsole.MarkupLine($"[Green]Product removed![/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]Product ID is already taken![/]");
            }

          
        }



        public void ShowProducts()
        {

            if (Products.Any())
            {
                // var productinList = Products.ForEach()
                foreach (var product in Products)
                {
                    int indexOfProducts = Products.IndexOf(product) + 1;
                    
                    
                    AnsiConsole.MarkupLine($"[blue]{indexOfProducts}. Name:{product.ProductName}, Price:{product.Price:F2} ID:{product.ProductId}.\n Category:{product.Category}\n Description:{product.Description}![/]");
                    
                }

               /* for (int i = 0; i < Products.Count; i++)
                {
                    var product = Products[i];
                    AnsiConsole.MarkupLine($"[blue]{i}. Name:{product.ProductName}, Price:{product.Price:F2} ID:{product.ProductId}.\n Category:{product.Category}\n Description:{product.Description}![/]");
                }*/

            }
            else
            {
                AnsiConsole.MarkupLine($"[red]No product found, please add products![/]");

            }
            Console.WriteLine("-----------------");
        }
    }
}
