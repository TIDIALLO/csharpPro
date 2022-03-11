using System;
using Packt.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class ImmutablePerson 
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
    }
    public record ImmutableVehicle {
        public int Wheels { get; init; }
        public string? Color { get; init; }
        public string? Brand { get; init; }
    }
    // génère automatiquement les propriétés, le constructeur et le déconstructeur
    // façon plus simple de définir un enregistrement
    public record ImmutableAnimal(string Name, string Species);
}