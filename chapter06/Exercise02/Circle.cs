using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chapter06.Exercise02
{
    public class Circle:Square
    {
        public Circle(){}
        public Circle(double radius) : base(width: radius * 2){}
        public double Radius{
            get{
                return height / 2;
            }
            set{
                Height = value * 2;
            }
        }
        public override double Area{
            get{
                double radius = height / 2;
                return Math.PI * radius * radius ;
            }
        }
    }
}