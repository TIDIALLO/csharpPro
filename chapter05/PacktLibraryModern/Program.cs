// See https://aka.ms/new-console-template for more information
using Packt.Shared;
using static System.Console;

object[] passengers = {
    new FirstClassPassenger { AirMiles = 1_419 },
    new FirstClassPassenger { AirMiles = 16_562 },  
    new BusinessClassPassenger(),
    new CoachClassPassenger { CarryOnKG = 25.7 }, 
    new CoachClassPassenger { CarryOnKG = 0 }, 
};
foreach (object passenger in passengers){
    decimal flightCost = passenger switch{
        /*FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
        FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
        FirstClassPassenger _                         => 2000M, */
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35000 => 1500M,
            > 15000 => 1750M,
            _       => 2000M
        },
        BusinessClassPassenger _                      => 1000M, 
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassenger _                         => 650M,
        _                                             => 800M 
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}"); 
    WriteLine("#############################################");
   /* ImmutablePerson jeff = new() {
            FirstName = "Jeff",  
            LastName = "Winger"
    };
        jeff.FirstName = "Geoff"; */

    ImmutableVehicle car = new(){
        Brand = "Mazda MX-5 RF",
        Color = "Soul Red Crystal Metallic",
        Wheels = 4
    };
    ImmutableVehicle repaintedCar = car  
        with { Color = "Polymetal Grey Metallic" }; 
    WriteLine($"Original car color was {car.Color}.");
    WriteLine($"New car color is {repaintedCar.Color}.");

    ImmutableAnimal oscar = new("Oscar", "Labrador");
    var (who, what) = oscar; // calls Deconstruct method
    WriteLine($"{who} is a {what}.");
}
