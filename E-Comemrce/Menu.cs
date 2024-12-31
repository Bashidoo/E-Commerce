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
            char choice = Convert.ToChar(Console.ReadKey());

            Console.WriteLine("Menu Entered****");

            while (running)
            {
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

                        break;
                    case '6':
                        
                        break;
                    case '7':

                        break;
                    case '8':

                        break;
                    case '9':

                        break;
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
