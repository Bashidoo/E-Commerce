using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class Utility
    {
        public int GetValidatedNumberInput(string prompt)
        {
            int number;
            while (true)
            {
                AnsiConsole.Markup($"{prompt} ");

                string? input = Console.ReadLine();
                try
                {

                    if (string.IsNullOrEmpty(input))
                    {

                        AnsiConsole.MarkupLine("[red]You have entered nothing.[/]");

                    }
                    else
                    {
                        number = Convert.ToInt32(input);
                        return number;
                    }

                }
                catch (FormatException)
                {

                    AnsiConsole.MarkupLine("[red]Invalid input. Please enter a valid number.[/]");

                }
                catch (OverflowException)
                {

                    AnsiConsole.MarkupLine("[red]Number is too large.[/]");

                }
                catch (Exception e)
                {

                    AnsiConsole.MarkupLine($"[red]Error: {e.Message}\n[/]");

                }

            }

        }

        public double GetValidatedDoubleNumberInput(string prompt)
        {
            double number;
            while (true)
            {
                AnsiConsole.Markup($"{prompt} ");

                string? input = Console.ReadLine();
                try
                {

                    if (!string.IsNullOrEmpty(input))
                    {

                        number = Convert.ToInt32(input);
                        return number;

                    }


                }
                catch (Exception ex)
                {
                    // Escape exception message to prevent markup errors
                    string escapedMessage = Markup.Escape(ex.Message);
                    AnsiConsole.MarkupLine($"[red]Error: {escapedMessage}[/]");
                }

            }

        }

        public string GetValidatedStringInput(string prompt)
        {

            string convertedString;
            while (true)
            {
                AnsiConsole.Markup($"{prompt} ");

                string? input = Console.ReadLine();
                try
                {

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        AnsiConsole.MarkupLine("[red]You have entered nothing.[/]");
                        Console.ResetColor();
                    }
                    else
                    {
                        convertedString = Convert.ToString(input);
                        return convertedString;
                    }

                }
                catch (FormatException)
                {

                    AnsiConsole.MarkupLine("[red]Please Enter a valid input.[/]");

                }
                catch (OverflowException)
                {

                    AnsiConsole.MarkupLine("[red]Number is too large.[/]");

                }
                catch (Exception e)
                {

                    AnsiConsole.MarkupLine($"[red]Error: {e.Message}\n[/]");

                }

            }

        }

    }
}
