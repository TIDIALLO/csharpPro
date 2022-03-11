using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Packt.Shared;
    public partial class Person
    {
        //declaration des champs
        public string name;
        public DateTime DateOfBirth;   
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();
         // constants
        public const  string Species = "Homo Sapien"; 
        // read-only fields-- lecture seul
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        // constructeurs
        public Person(){
            // définit les valeurs par défaut pour les champs
            // incluant les champs en lecture seule
            name = "Unknown";   
            Instantiated = DateTime.Now; 
        }

        //deuxiéme constructeur
        public Person(string initialName, string homePlanet) {  
            name = initialName;  
            HomePlanet = homePlanet;  
            Instantiated = DateTime.Now; 
        } 
        // methods 
        public void WriteToConsole() {  
            WriteLine($"{name} was born on a {DateOfBirth:dddd}."); 
        }
        public string GetOrigin() {  
            return $"{name} was born on {HomePlanet}."; 
        } 

        //les tuples
        public (string, int) GetFruit() {
            return ("Apples", 5);
        }
        public (string Name, int Number) GetNamedFruit(){
            return (Name: "Apples", Number: 5); 
        }
        // deconstructeurs
        public void Deconstruct(out string namee, out DateTime dob) {
            namee = name;  
            dob = DateOfBirth;
        }

        public void Deconstruct(out string namee,  out DateTime dob,
            out WondersOfTheAncientWorld fav) {
                namee = name;  
                dob = DateOfBirth;  
                fav = FavoriteAncientWonder;
        }
        public string SayHello() {  
            return $"{name} says 'Hello!'"; 
        }
        public string SayHello(string Name) {  
            return $"{name} says 'Hello {Name}!'"; 
        } 
        public string OptionalParameters( 
            string command  = "Run!",  
            double number = 0.0,  
            bool active = true) 
        {
            return string.Format( 
                format: "command is {0}, number is {1}, active is {2}", 
                arg0: command,    
                arg1: number, 
                arg2: active); 
        }
        public void PassingParameters(int x, ref int y, out int z) {
            // les paramètres de sortie (out    ) ne peuvent pas avoir de valeur par défaut
            // et doit être initialisé dans la méthode
            z = 99;
            x++;   
            y++;   
            z++; 
        }

}
    
