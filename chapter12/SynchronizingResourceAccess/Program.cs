using System.Diagnostics; // Stopwatch
using static System.Console;

WriteLine("Please wait for the tasks to complete.");
Stopwatch watch = Stopwatch.StartNew();

Task a = Task.Factory.StartNew(MethodA);
Task b = Task.Factory.StartNew(MethodB);
Task.WaitAll(new Task[] { a, b });

WriteLine();
WriteLine($"Results: {SharedObjects.Message}.");
WriteLine($"{watch.ElapsedMilliseconds:N0} elapsed milliseconds.");

WriteLine($"{SharedObjects.Counter} string modifications.");

static void MethodA()
{
    /*lock (SharedObjects.Conch){
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(SharedObjects.Random.Next(2000));
            SharedObjects.Message += "A";
            Write(".");
        }   
    }*/
    try{
        if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(SharedObjects.Random.Next(2000));
                SharedObjects.Message += "A";
                Interlocked.Increment(ref SharedObjects.Counter);
                Write(".");
            }  
        }
        else{
            WriteLine("Method A timed out when entering a monitor on conch.");
        }
    }
    finally
    {
        WriteLine("Method A timed out when entering a monitor on conch.");
    }
}

static void MethodB(){
    // lock (SharedObjects.Conch){
    //     for (int i = 0; i < 5; i++)
    //     {
    //         Thread.Sleep(SharedObjects.Random.Next(2000));
    //         SharedObjects.Message += "B";
    //         Write(".");
    //     }   
    // }
    try{
        if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(SharedObjects.Random.Next(2000));
                SharedObjects.Message += "B";
                Interlocked.Increment(ref SharedObjects.Counter);
                Write(".");
            }  
        }
        else{
            WriteLine("Method B timed out when entering a monitor on conch.");
        }
    }
    finally
    {
        WriteLine("Method B timed out when entering a monitor on conch.");
    }
}
static class SharedObjects{
    public static int Counter; // another shared resource
    public static  object Conch = new();
    public static Random Random = new();
    public static string? Message;
}

