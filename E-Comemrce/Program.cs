using E_Commerce;
using Spectre.Console;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace E_Comemrce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Store<string> _store = new Store<string>();

            string dataJsonFilePath = "data.json";

            try
            {
                string allDatafromJsonType = File.ReadAllText(dataJsonFilePath);
                MyDB myDB = JsonSerializer.Deserialize<MyDB>(allDatafromJsonType)!;
                
                _store.Cards.AddRange(myDB.AllUsersFromDB);
                AnsiConsole.MarkupLine("[green]Data loaded successfully![/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error loading data: {ex.Message}[/]");
            }

           _store.Products.Add(new Product("Pistol", 299.00, "Guns", "Firearm"));
            _store.Products.Add(new Product("Rifle", 699.00, "Guns", "Firearm"));
            _store.Users.Add( new User<string>("123".Trim(), "2682424".Trim(), "Busher Abo Dan"));

            if (_store.Users.Any())
            {
                Console.WriteLine("User added successfully!");
            }
            else
            {
                Console.WriteLine("User not added. Check the logic!");
            }
            foreach (var user in _store.Users)
            {
                Console.WriteLine($"Stored user: Email = {user.Email}, Password = {user.Password}");
            }
            foreach (var CardInfo in _store.Cards)
            {
                Console.WriteLine($"CardNumber:{CardInfo.CardNumber}, CCV: {CardInfo.CCV} InternetPurchase: {CardInfo.InternetPurchase}");
            }

            bool loggingIn = true;
             
            

            while (loggingIn)
            {

                string userEmail = Utility.GetValidatedStringInput("Please Enter your Email: ").Trim();
                string password = Utility.GetValidatedStringInput("Enter your password:").Trim();

                User<string>? LoggedInUser = _store.UserLogin(userEmail, password);

                if (LoggedInUser != null)
                {
                    loggingIn = false;
                    var menuOBJ = new Menu<string>(_store);
                    Console.WriteLine($"Welcome: {LoggedInUser.Email}");
                    menuOBJ.ShowMenu(LoggedInUser);

                }
                else
                {
                    Console.WriteLine("Logging in failed.");
                }

            }
        }
    }
}
