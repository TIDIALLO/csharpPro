using static System.Console;

//int thisCannotBeNull  = 4; 
//thisCannotBeNull = null; // compile error!
int? thisCouldBeNull = null;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

thisCouldBeNull = 7;
WriteLine(thisCouldBeNull); 
WriteLine(thisCouldBeNull.GetValueOrDefault());

class Adress
{
    public string? Building; 
    public string Street =  string.Empty;   
    public string City =  string.Empty;   
    public string Region =  string.Empty; 
}
Address address = new();
address.Building = null; 
address.Street = null;
address.City = "London"; 
address.Region = null;