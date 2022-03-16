using System;
using static System.Console;
using System.Linq;

namespace testCode.delegates
{
    public class Delegates
    {
        public  delegate string Reverse(string s);
        static string ReverseString(string s){
            return new string(s.Reverse().ToString());
        }
    }

    
}
