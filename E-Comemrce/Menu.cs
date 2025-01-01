using E_Comemrce;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class Menu<T>
    {
        private Store<T> _store;
        public Menu(Store<T> store)
        {
            _store = store;
        }

        public void ShowMenu(User<T> User)
        {
            bool running = true;

            while (running)
            {
            Console.WriteLine("Menu Entered****");
            Console.WriteLine($"Hello: {User.Name}");
            Console.WriteLine("1. Add Product.");
            Console.WriteLine("2. Remove Product.");
            Console.WriteLine("3. Show Products.");
            Console.WriteLine("4. Exit Application.");
            Console.WriteLine("5. Sort Products.");
            Console.WriteLine("6. Select Product.");
            Console.WriteLine("7. Show shopping cart.");
            Console.WriteLine("8. Paying for shopping cart.");
            var choice = Convert.ToChar(Console.ReadLine());

                switch (choice)
                {
                    case '1':
                        AskForInfoToAddProductOBJ();
                        break;
                    case '2':
                        _store.RemoveProduct();
                        break;
                    case '3':
                        _store.ShowProducts();
                        break;
                    case '4':
                        
                        running = false;
                        return;
                        
                    case '5':
                        _store.SortByProducts();
                        break;
                    case '6':
                        SelectProduct();
                        break;
                    case '7':
                        ShowProductList();
                        break;
                    case '8':
                        _store.PayingForShoppingCart(User);
                        break;
                    case '9':

                        break;
                }

            }
          void SelectProduct()
          {
            int ProductID = Utility.GetValidatedNumberInput("Enter Product ID:");
            var product = _store.Products.FirstOrDefault(x => x.ProductId == ProductID);
            if (product != null)
            {
                User.ProductList.Add(product);
            }
            else
            {
                    Console.WriteLine("Invalid Product ID. Could not select Product.");
            }
          }
            void ShowProductList()
            {
                if (User.ProductList.Any())
                {
                    foreach (var product in User.ProductList)
                    {

                        int indexOfProducts = User.ProductList.IndexOf(product) + 1;


                        AnsiConsole.MarkupLine($"[blue]{indexOfProducts}. Name:{product.ProductName}, Price:{product.Price:F2} ID:{product.ProductId}.\n Category:{product.Category}\n Description:{product.Description}![/]");
                    }
                }
                else
                {
                    Console.WriteLine("No Products found, please add products to your cart.");
                }
            }
        }



        public void AskForInfoToAddProductOBJ()
        {
          
            
            string ProductName = Utility.GetValidatedStringInput("Enter Product Name:");

            double Price = Utility.GetValidatedDoubleNumberInput("Enter Product Price:");

            string Category = Utility.GetValidatedStringInput("Enter Product Category:");

            string Description = Utility.GetValidatedStringInput("Enter Product Description details:");

            try
            {
             Product newProduct = new Product(ProductName, Price, Category, Description);

                _store.AddProduct(newProduct);
            }
            catch(Exception e)
            {
                AnsiConsole.MarkupLine($"[red]Product Creation failed. {e.Message}![/]");

            }



        }

    }
}
