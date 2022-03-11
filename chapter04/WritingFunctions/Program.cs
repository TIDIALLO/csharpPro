// See https://aka.ms/new-console-template for more information


/*namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
            TimesTable(5);
        }
        static void TimesTable(byte number){
            WriteLine($"Ceci est la table du nombre {number}");
            for (int row = 0; row <= 12; row++)
            {
                WriteLine($"{row} x {number} = {row * number}");
            }
            WriteLine();
        }
    }
}*/
using System;
using static System.Console;
//methode qui cqlcul la tale de multipliction d'un nombre
static void TimesTable(byte number){
    WriteLine($"Ceci est la table du nombre {number}");
    for (int row = 0; row <= 12; row++)
    {
        WriteLine($"{row} x {number} = {row * number}");
    }
    WriteLine();
}
WriteLine("Méthode pour calculer le TVA et retourner ");
TimesTable(55);  
//Méthode pour calculer le TVA et retourner 
static decimal CalculateTax(decimal amount,string twoLetterRegionCode){
    decimal rate = 0.0M;
    switch (twoLetterRegionCode)
    {
        case "CH":  // swisse
            rate = 0.08M;
            break;
         case "DK":  // Danmark
         case "NO":  // swisse
            rate = 0.25M;
            break;
         case "GB":  // Grande Bretangne
         case "Fr":  // France
            rate = 0.08M;
            break;
         case "OR": // Oregon    
         case "AK": // Alaska    
         case "MT": // Montana
            rate = 0.0M;
            break;
         case "ND": // North Dakota    
         case "WI": // Wisconsin    
         case "ME": // Maine
         case "VA": // Montana
            rate = 0.0M;
            break;
        case "CA": // Montana
            rate = 0.0M;
            break;
        default : // Montana
            rate = 0.6M;
            break;
    }
    return amount*rate;
}
WriteLine("Méthode pour calculer le TVA et retourner ");
decimal taxToPay = CalculateTax(amount:140, twoLetterRegionCode:"Fr");
WriteLine($"Tu dois payer {taxToPay} comme tax");

//fonction pour convertir des nombre cardinaux en ordinaux
/// <summary>
/// 
/// </summary>
/// <param name="Le nombre est une valeur cardinale, par ex. 1, 2, 3, etc."></param>
/// <returns>Nombre sous forme de valeur ordinale, par ex. 1er, 2e, 3e, etc.</returns>
static string CardinalToOrdinal(int number){
    switch (number)
    {
         case 11: // special cases for 11th to 13th    
         case 12:    
         case 13: 
            return $"{number}th";
        default:
        int lastDigist = number * 10;

        string suffix = lastDigist switch 
        {
            1 => "st",
            2 => "nd",
            3 => "rd",
            _ => "th"
        };
        return $"{number}{suffix}";
    }
}
/*static void RunCardinalToOrdinal(){
    for (int number = 1; number <= 40; number++)
    {
        Write($"{CardinalToOrdinal(number)} ");
        
    }  
    WriteLine();
}*/
//RunCardinalToOrdinal();
WriteLine("==================================================================");
static int Factorial(int number){
    if (number < 1){
       return 0;
    }
    if (number == 1)
    {
        return 1;
    }
    else{
        checked
        {
            return Factorial(number - 1) * number;
        }
    }
}
/*WriteLine("CALCULE FACTORIEL");
static void RunFactorial(){
    for (int i = 0; i < 20; i++)
    {
        try
        {
            WriteLine($"{i}! = {Factorial(i):N0}");
        }
        catch (System.OverflowException)
        {
              WriteLine($"{i}! est trop grand pour un entier de 32 bits."); 
        }
    }
}
RunFactorial();
*/
//suite de fibonacci
/*static int FibImperative(int term){
    if (term ==1)
    {
        return 0;
    }
    else if (term == 2)
    {
        return 1;
    }
    else
    {
        return FibImperative(term-1) + FibImperative(trem -2);
    }
}
static void RunFibImperative(){
    for (int i = 1; i <= 30; i++)
    {
        WriteLine("Le {0} term de la suite de fibonacci est {1:N0}",
            arg0:CardinalToOrdinal(i),
            arg1:FibImperative(term: i));
    }
}*/
WriteLine("==========   suite fibbonaci   ============");
//WriteLine(RunFibImperative());
static int FibFunctional(int term) =>
    term switch{
        1 => 0,
        2 => 1,
        _ => FibFunctional(term - 1) + FibFunctional(term -2)
    };


static void RunFibFunctional(){
    for (int i = 1; i < 30; i++)
    {
        WriteLine("Le {0} term de la suite de fibonacci est {1:N0}",
            arg0:CardinalToOrdinal(i),
            arg1:FibFunctional(term: i));
    }
}
RunFibFunctional();
