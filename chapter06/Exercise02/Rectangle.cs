using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chapter06.Exercise02
{
    public class Rectangle:Shape
    {
        public Rectangle(){}
        public Rectangle(double height, double width){
            this.height = height;
            this.width = width; 
        }
        public override double Area{
            get{
                return height * width;
            }
        }
    }
}