using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public partial class Person 
    {
        //une propriété définie à l'aide de la syntaxe C# 1 - 5
        public string Origin{
            get{
                 return $"{name} was born on {HomePlanet}"; 
            }
        }
        // deux propriétés définies à l'aide de la syntaxe du corps de l'expression lambda C# 6+
        public string Greeting => $"{name} says 'Hello!'";
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

        //getteurs et setteurs
        public string FavoriteIceCream { get; set; } // auto-syntax 
        private string favoritePrimaryColor;

        public string FavoritePrimaryColor {
            get{
                 return favoritePrimaryColor; 
            }
            set{
                switch (value.ToLower()){    
                    case "red":      
                    case "green":      
                    case "blue":
                        favoritePrimaryColor = value;
                        break;
                    default:
                         throw new System.ArgumentException(
                              $"{value} is not a primary color. " +   
                              "Choose from: red, green, blue.");
                         
                }
            }
        }


        //indexers 
        public Person this[int index]{
            get  {    
                return Children[index]; // pass on to the List<T> indexer  
            }
            set  {    
                 Children[index] = value; 
            }  
            
        }

    }
}