using static System.Console;

// a string array is a sequence that implements IEnumerable<string>
string[] names = new[]   { "Michael", "Pam", "Jim", "Dwight",
                            "Angela", "Kevin", "Toby", "Creed" };
WriteLine("Deferred execution");
// Question: Which names end with an M?
// (written using a LINQ extension method)
var query1 = names.Where(name => name.EndsWith("m"));

// Answer returned as an array of strings containing Pam and Jim
string[] result1 = query1.ToArray();

// Answer returned as a list of strings containing Pam and Jim


var query2 = from name in names where name.EndsWith("m") select name;
List<string> result2 = query2.ToList();

// Answer returned as we enumerate over the results
foreach (string name in query1)
{
    WriteLine(name); // outputs Pam
    names[2] = "Jimmy"; // change Jim to Jimmy
    // on the second iteration Jimmy does not end with an M
}
WriteLine("Writing queries");

//var query = names.Where(new Func<string,bool>(NameLongerThanFour));
//var query = names.Where(NameLongerThanFour);

/*var query = names.Where(name => name.Length > 4)
    .OrderBy(name => name.Length)
    .ThenBy(name => name);*/
IOrderedEnumerable<string> query = names.Where(name => name.Length > 4)
    .OrderBy(name => name.Length)
    .ThenBy(name => name);
foreach (string item in query)
{
    WriteLine(item);
}
// static bool NameLongerThanFour(string name){
//     return name.Length > 4;
// }

WriteLine("Filtering by type");
List<Exception> exceptions = new()
{
    new ArgumentException(),
    new SystemException(),
    new IndexOutOfRangeException(),
    new InvalidOperationException(),
    new NullReferenceException(),
    new InvalidCastException(),
    new OverflowException(),
    new DivideByZeroException(),
    new ApplicationException()
};
IEnumerable<ArithmeticException> arithmeticExceptionsQuery = 
        exceptions.OfType<ArithmeticException>();
foreach (ArithmeticException exception in arithmeticExceptionsQuery)
{
    WriteLine(exception);
}