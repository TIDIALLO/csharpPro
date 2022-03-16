using static System.Console;
using System.Xml;
using static System.Environment;
using static  System.IO.Path;
using System.IO.Compression; // BrotliStream, GZipStream, CompressionMode


//WorkWithText();
WorkWithXml();
WorkWithCompression();
static void WorkWithText(){
        // define a file to write to
    string textFile = Combine(CurrentDirectory, "streams.txt");

    // create a text file and return a helper writer
    StreamWriter text = File.CreateText(textFile);

    // énumère les chaînes, en écrivant chacune
    // au flux sur une ligne séparée

    foreach (string item in Viper.Callsigns)
    {
        text.WriteLine(item);
    }
    text.Close(); // release resources
     // output the contents of the file
    WriteLine("{0} contains {1:N0} bytes.",
        arg0: textFile,
        arg1: new FileInfo(textFile).Length);
    WriteLine(File.ReadAllText(textFile));
}  

static void WorkWithXml(){
    FileStream? xmlFileStream = null;
    XmlWriter? xml = null;

    try
    {
        
        // define a file to write to
        string xmlFile = Combine(CurrentDirectory, "streams.xml");

        // create a file stream
        xmlFileStream = File.Create(xmlFile);

        // encapsule le flux de fichier dans un assistant d'écriture XML
        // et indente automatiquement les éléments imbriqués
        xml =  XmlWriter.Create(xmlFileStream,
            new XmlWriterSettings { Indent = true });
        
        // write the XML declaration
        xml.WriteStartDocument();

        //écrire un élément racine
        xml.WriteStartElement("callsigns");

        // énumère les chaînes écrivant chacune dans le flux
        foreach (string item in Viper.Callsigns)
        {
            xml.WriteElementString("callsign", item);
        }

        // write the close root element
        xml.WriteEndElement();
        // close helper and stream
        xml.Close();
        xmlFileStream.Close();
        
        // output all the contents of the file
        WriteLine("{0} contains {1:N0} bytes.",
            arg0: xmlFile,
            arg1: new FileInfo(xmlFile).Length);

        WriteLine(File.ReadAllText(xmlFile));

    }
    catch (Exception ex)
    {
        WriteLine($"{ex.GetType} says {ex.Message}");
    }
    finally{
        if (xml != null)
        {
            xml.Dispose();
            WriteLine("The file writer's umanaged ressource have been disposed");

            if (xmlFileStrem != null)
            {
                xmlFileStream.Dispose();
                WriteLine("The file stream's umanaged ressource have been disposed");
            } 
       }
    }
}


// compression de fichier xml
static void WorkWithCompression(){
    WriteLine("=======  compression de fichier xml  =======");
    string fileExt = "gzip";

    // compress the XML output
    string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");
    FileStream file = File.Create(filePath);
    Stream compressor = new GZipStream(file, CompressionMode.Compress);
    
    using (compressor)
    {
        using (XmlWriter xml = XmlWriter.Create(compressor)){
            xml.WriteStartDocument();
            xml.WriteStartElement("callsigns");
            foreach (string item in Viper.Callsigns)
            {
                xml.WriteElementString("callsign", item);
            }
            // the normal call to WriteEndElement is not necessary
            // because when the XmlWriter disposes, it will
            // automatically end any elements of any depth
            // l'appel normal à WriteEndElement n'est pas nécessaire
            // car lorsque le XmlWriter disposera, il
            // termine automatiquement tous les éléments de n'importe quelle profondeur
        }       
    } // also closes the underlying stream
    // output all the contents of the compressed file
    WriteLine("{0} contains {1:N0} bytes.",filePath, new FileInfo(filePath).Length);
    WriteLine($"The compressed contents:");
    WriteLine(File.ReadAllText(filePath));
    // read a compressed file
    WriteLine("Reading the compressed XML file:");
    file = File.Open(filePath, FileMode.Open);
    Stream decompressor = new GZipStream(file,CompressionMode.Decompress);
    using (decompressor)
    {
        using (XmlReader reader = XmlReader.Create(decompressor)){
            while (reader.Read()){// read the next XML node
                // check if we are on an element node named callsign
                if ((reader.NodeType == XmlNodeType.Element)
                    && (reader.Name == "callsign"))
                {
                    reader.Read(); // move to the text inside element
                    WriteLine($"{reader.Value}"); // read its value
                }
            } 
        }
    }
 
}


static class Viper
{
    // définit un tableau d'indicatifs d'appel de pilote Viper
    public static string[] Callsigns = new[]
    {
        "Husker", "Starbuck", "Apollo", "Boomer",
        "Bulldog", "Athena", "Helo", "Racetrack"
    };
}
