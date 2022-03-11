using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chapter06.Exercise02
{
    public abstract class Shape
    {
        //declaration des champs
        protected double height;
        protected double width;
        // Area doit être implémenté par des classes dérivées
        //en tant que propriété en lecture seule
        public abstract  double Area{get;}

        //propriétés
        public virtual double Height{
            get{return height; }
            set{height = value;}
        }
        public virtual double Width{
            get{return width; }
            set{width = value;}
        }


    }
}