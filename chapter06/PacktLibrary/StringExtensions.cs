using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Packt.Shared
{
    public static class StringExtensions
    {
         
        public static bool IsValidEmail(this string input) {
            // utilise une expression régulière simple pour vérifier
        // que la chaîne d'entrée est un email valide
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+"); 
        } 
          
    }
}