using static System.Console;

namespace Packt.Shared;

public class Person:object, IComparable<Person> 
{
    //declaation des champs
    public string? Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new();

    //méthodes
    public void WriteToConsole(){
        WriteLine($"{Name} est né en {DateOfBirth:dddd}.");
    }
    //méthode statique
    public static Person Procreate(Person p1, Person p2){
        Person baby = new(){
            Name =  $"Baby of {p1.Name} and {p2.Name}" 
        };
        p1.Children.Add(baby);
        p2.Children.Add(baby);

        return baby;
    }
    //methode d'instance
    public Person ProcreateWith(Person partner){
        return Procreate(this, partner);
    }
    //opérateur pour multiplier
    public static Person operator *(Person p1, Person p2){
        return Person.Procreate(p1,p2);
    }

    // méthode avec une fonction locale
    public static int Factorial(int number){
        if(number < 0){
            throw new ArgumentException(
                $"{nameof(number)} cannot be less than zero.");
            
        }
        return localFactorial(number);
        //fonction locale
        int localFactorial(int localNumber){
            if (localNumber < 1) return 1; 
            return localNumber * localFactorial(localNumber - 1); 
        }
    }
    // delegate field
    public event EventHandler? Shout;
    // data field
    public int AngerLevel;
    //method 
    public void Poke(){
        AngerLevel++;
        if(AngerLevel >=3 ){
            // if something is listening...
            if(Shout != null){
                // ...then call the delegate
                Shout(this, EventArgs.Empty);
            }
        }
    }
    public int CompareTo(Person? other){
        if (Name is null) return 0; 
        return Name.CompareTo(other?.Name); 
    }
    //surcharge de methode
    public override string ToString() {
        return $"{Name} is a {base.ToString()}";
    }

    public void TimeTravel(DateTime when){
        if (when <= DateOfBirth){
                throw new PersonException(
                    "If you travel back in time to a date  earlier than your own birth"
                    +" then the universe will explode!"); 
        }
        else
        {
            WriteLine($"Welcome to {when:yyyy}!");
        }
    }
}
