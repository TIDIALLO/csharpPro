// See https://aka.ms/new-console-template for more information
using static System.Console;
using System.Diagnostics;
using  Microsoft.Extensions.Configuration;
//écrire dans un fichier texte dans le dossier du projet
Trace.Listeners.Add(new TextWriterTraceListener(
    File.CreateText(Path.Combine(Environment.GetFolderPath(    
        Environment.SpecialFolder.DesktopDirectory), "log.txt"))));
// textwriter est mis en mémoire tampon, donc cette option appelle
//Flush() sur tous les écouteurs après l'écriture
Trace.AutoFlush = true;

WriteLine("Le débogage dit, je regarde!");
WriteLine("La Trace dit, je regarde!");

ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appseting.json",
        optional: true, reloadOnChange:true);
    IConfigurationRoot configuration = builder.Build(); 
    TraceSwitch ts = new(  displayName: "PacktSwitch",  
    description: "This switch is set via a JSON config."); 

    configuration.GetSection("PacktSwitch").Bind(ts);
    Trace.WriteLineIf(ts.TraceError, "Trace error"); 
    Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
    Trace.WriteLineIf(ts.TraceInfo, "Trace information"); 
    Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose"); 


