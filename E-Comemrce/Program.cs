using E_Commerce;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace E_Comemrce
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Store<string> _store = new Store<string>();
            List<Product> productsList = new List<Product>();
            using (var realDatabase = new AppDbContext())
            {
                realDatabase.Database.EnsureCreated();
                var dbProducts = realDatabase.Products.ToList();

                foreach (var product in dbProducts)
                {
                    productsList.Add(product);

                   
                }

                foreach (var product in productsList)
                {
                    Console.WriteLine($"Product in Store: {product.ProductId} - {product.ProductName} - {product.Price:C}");
                    _store.Products.Add(product);
                }
            }

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

           _store.Products.Add(new Product("Pistol", 299, "Guns", "Firearm"));
            _store.Products.Add(new Product("Rifle", 699, "Guns", "Firearm"));
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
    



public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } // Products table

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-6O16HQII\SQLEXPRESS;Database=busherMonday;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductId)
                .ValueGeneratedOnAdd(); // Prevent EF from overriding your random ProductId

            // Seed initial data
            modelBuilder.Entity<Product>().HasData(
                new Product("Wireless Mouse", 25, "Electronics", "Ergonomic wireless mouse"),
                new Product("Gaming Keyboard", 59, "Electronics", "RGB mechanical gaming keyboard")
            );
        }
    }


}
