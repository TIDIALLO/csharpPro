// See https://aka.ms/new-console-template for more information
using Packt.Shared;
using PacktLibrary;
using static System.Console;

Person bob = new(); // C# 9.0 or later 
WriteLine(bob.ToString()); 

bob.name = "Bob Smith";
bob.DateOfBirth  = new DateTime(1965, 12, 22);
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList =   WondersOfTheAncientWorld.HangingGardensOfBabylon  
            | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

bob.Children.Add(new Person{name = "Alfred"}); // C# 3.0 and later 
bob.Children.Add(new() { name = "Zoe" }); // C# 9.0 and later
WriteLine(  $"{bob.name} has {bob.Children.Count} children:");
for (int childIndex  = 0; childIndex  < bob.Children.Count; childIndex ++)
{
    WriteLine($" {bob.Children[childIndex].name}")  ;
}

WriteLine(format:"{0} est né le {1:dddd, d MMMM yyyy} , Son entier est {2}",
    arg0:bob.name,
    arg1:bob.DateOfBirth,
    arg2:bob.FavoriteAncientWonder
);
WriteLine($"{bob.name}'s bucket list is {bob.BucketList}");
WriteLine($"{bob.name} is a {Person.Species}");
WriteLine($"{bob.name} was born on {bob.HomePlanet}"); 
//WriteLine(System.Int32.MaxValue);


Person alice = new(){
    name = "Alice Jones",  
    DateOfBirth = new(1998, 3, 7) 
};
WriteLine(format: "{0} est née le {1:dd MMM yy}",  
        arg0: alice.name,  
        arg1: alice.DateOfBirth); 
WriteLine("===========   utilisaton des champs static = = = = =");
BankAccount.InterestRate = 0.012M; // store a shared value
BankAccount  jonesAccount = new(); // C# 9.0 and later 
jonesAccount.AccountName = "Mrs. Jones"; 
jonesAccount.Balance = 2400;

WriteLine(format: "{0} earned {1:C} interest.",  
    arg0: jonesAccount.AccountName,  
    arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new(); 
gerrierAccount.AccountName = "Ms. Gerrier"; 
gerrierAccount.Balance = 98;

WriteLine(format: "{0} earned {1:C} interest.",  
    arg0: gerrierAccount.AccountName,  
    arg1: gerrierAccount.Balance * BankAccount.InterestRate);

WriteLine("===========   utilisaton de constructeurs = = = = = = = == = = =");
Person blankPerson  = new();
WriteLine(format:  "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",  
    arg0: blankPerson.name,  
    arg1: blankPerson.HomePlanet,  
    arg2: blankPerson.Instantiated);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");
WriteLine(format:  "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",  
    arg0: gunny.name,  
    arg1: gunny.HomePlanet,  
    arg2: gunny.Instantiated);

WriteLine("===========   utilisaton des méthodes = = = = = = = == = = =");
bob.WriteToConsole(); 
WriteLine(bob.GetOrigin());

WriteLine("===========   utilisaton des tuples = = = = = = = == = = =");
(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are."); 
var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}."); 

var thing1 = ("Neville", 4); 
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (bob.name, bob.Children.Count);
WriteLine($"{thing2.name} has {thing2.Count} children."); 

(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

// Deconstruction de Person
WriteLine("= ===========    Deconstruction de Person ========== === == = =");

var (name1, dob1) = bob; 
WriteLine($"Deconstructed: {name1}, {dob1}");
var (name2, dob2, fav2) = bob; 
WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");
WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily")); 
WriteLine(bob.OptionalParameters());
WriteLine(bob.OptionalParameters("Jump!", 98.5)); 
WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!")); 
WriteLine(bob.OptionalParameters("Poke!", active: false));

WriteLine(" ===  ====   ===  ===  controle de paramétres");
int a = 10; 
int b = 20; 
int c = 30;
WriteLine($"Before: a = {a}, b = {b}, c = {c}"); 
bob.PassingParameters(a, ref b, out c); 
WriteLine($"After: a = {a}, b = {b}, c = {c}");

int d = 10; 
int e = 20;
WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
// simplified C# 7.0 or later syntax for the out parameter
bob.PassingParameters(d, ref e, out int f); 
WriteLine($"After: d = {d}, e = {e}, f = {f}");
WriteLine("###################################");
Person sam = new(){
     name = "Sam",  
     DateOfBirth = new(1972, 1, 27) 
};
WriteLine(sam.Origin); 
WriteLine(sam.Greeting); 
WriteLine(sam.Age); 
WriteLine("###################################");
WriteLine("###################################");
sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
sam.FavoritePrimaryColor = "Red";
WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

sam.Children.Add(new() { name = "Charlie" }); 
sam.Children.Add(new() { name = "Ella" });

WriteLine($"Sam's first child is {sam.Children[0].name}"); 
WriteLine($"Sam's second child is {sam.Children[1].name}");
WriteLine($"Sam's first child is {sam[0].name}"); 
WriteLine($"Sam's second child is {sam[1].name}");
