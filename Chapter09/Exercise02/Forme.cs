using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Packt.Shared;
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    public abstract class Shape
    {
        public string? Colour { get; set; }
        public abstract double Area { get; }
    }
