using System;

namespace  Packt.Shared 
{
    public class StringExtensions
    {
        public static bool IsValidXmlTag(this string input) {
            return Regex.IsMatch(input,        
                @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }
        public static bool IsValidPassword(this string input){
            // minimum de huit caractères valides
            return Regex.IsMatch(input, "^[a-zA-Z0-9_-]{8,}$"); 
        }

        public static bool IsValidHex(this string input){
            // trois ou six caractères numériques hexadécimaux valides
             return Regex.IsMatch(input, "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
        }
    }
}
