// See https://aka.ms/new-console-template for more information
using static System.Console;
using System.Linq;

namespace test.com;

public class Delegates
{
        //public  delegate string Reverse(string s);
        static string ReverseString(string s){
            return new string(s.Reverse().ToString());
        }

    static void Main(string[] args)
    {
        //Reverse rev = ReverseString;
        // utilistation du type delegate Func<>
        Func<string, string> rev = ReverseString;
        WriteLine(rev("a string"));
        WriteLine("== ==  == delegation anonyme == == === == == ==");
        List<int> list  = new List<int>();
        for (int i = 0; i < 100; i++)
        {
            list.Add(i);
            List<int> result = list.FindAll(
            delegate (int no)
            {
              return (no % 2 == 0);
            }
            );
            foreach (var item in result)
            {
                WriteLine(item);
            }
        }
        WriteLine("###  même exemple mais e utilisant les expression lambdas");
        for (int i = 0; i < 100; i++)
        {
            list.Add(i);
            List<int> result = list.FindAll(i => i % 2 == 0);
            foreach (var item in result)
            {
                WriteLine(item);
            }
        }

    }
}

    

