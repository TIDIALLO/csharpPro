using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Packt.Shared
{
    public class BusinessClassPassenger 
    {
         public override string ToString(){
            return $"Business Class"; 
         }
    }
    public class FirstClassPassenger {
        public int AirMiles { get; set;}
        public override string ToString(){
            return $"First Class with {AirMiles:N0} air miles";
        } 
    }
    public class CoachClassPassenger{
        public double CarryOnKG { get; set; }
        public override string ToString(){
            return $"Coach Class with {CarryOnKG:N2} KG carry on"; 
        }
    }
}