using static System.Console;
using System.Text.RegularExpressions;

WriteLine("L'expression régulière par défaut vérifie au moins un chiffre");

do
{
    WriteLine("Enter a regular expression (or press ENTER to use the default): ^[a-z]+");
    string? regExp   = ReadLine();
    if (string.IsNullOrWhiteSpace(regExp))
    {
        regExp = @"^\d+$";
    }
    WriteLine("Entrer un text");
    string? input = ReadLine();

    Regex r = new(regExp);

    WriteLine($"{input} matches {regExp}: {r.IsMatch(input)}");
    
    WriteLine("Press ESC to end or any key to try again.");
} while (ReadKey().Key != ConsoleKey.Escape);


