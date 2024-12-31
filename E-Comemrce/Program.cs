using E_Commerce;
using Spectre.Console;
using System.Security.Cryptography.X509Certificates;

namespace E_Comemrce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Product product1 = new Product("Pistol", 299.00, "Guns", "Firearm");
            Store<string> _store = new Store<string>();
            _store.Users.Add( new User<string>("123".Trim(), "2682424".Trim()));

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
