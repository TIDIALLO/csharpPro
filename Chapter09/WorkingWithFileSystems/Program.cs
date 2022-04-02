﻿using static System.Console; 
using  System.IO;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment; 

//OutputFileSystemInfo();
//WorkWithDrives();
//WorkWithDirectories();
WorkWithFiles();

static void OutputFileSystemInfo(){
    WriteLine("{0,-33} {1}", arg0: "Path.PathSeparator", arg1: PathSeparator); 
    WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar", 
        arg1: DirectorySeparatorChar);
    WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()",    
        arg1: GetCurrentDirectory());
    WriteLine("{0,-33} {1}", arg0: "Environment.CurrentDirectory",     
        arg1: CurrentDirectory);
    WriteLine("{0,-33} {1}", arg0: "Environment.SystemDirectory",     
        arg1: SystemDirectory); 
    WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()",arg1: GetTempPath());
    WriteLine("GetFolderPath(SpecialFolder");
    WriteLine("{0,-33} {1}", arg0: " .System)",   
        arg1: GetFolderPath(SpecialFolder.System)); 
    WriteLine("{0,-33} {1}", arg0: " .ApplicationData)",     
        arg1: GetFolderPath(SpecialFolder.ApplicationData));
    WriteLine("{0,-33} {1}", arg0: " .MyDocuments)",    
        arg1: GetFolderPath(SpecialFolder.MyDocuments)); 
    WriteLine("{0,-33} {1}", arg0: " .Personal)",    
         arg1: GetFolderPath(SpecialFolder.Personal)); 
     
}
//gestion des drivers
static void WorkWithDrives(){
    WriteLine("===========   gestion des drivers   ===============");
    
    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",    
       "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
    foreach (DriveInfo drive in DriveInfo.GetDrives()){
        if(drive.IsReady){
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
            drive.Name, drive.DriveType, drive.DriveFormat,
            drive.TotalSize, drive.AvailableFreeSpace);
        }     
        else
        {
             WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
        }
    }
}

static void WorkWithDirectories(){
    WriteLine("===========   gestion des repertoires   ===============");
    // define a directory path for a new folder  
    // starting in the user's folder 
    string newFolder = Combine(    
        GetFolderPath(SpecialFolder.Personal),    
        "Code", "Chapter09", "NewFolder");
    WriteLine($"Working with: {newFolder}");
    // check if it exists
    WriteLine($"Does it exist? {Exists(newFolder)}");
    // create directory   
    WriteLine("Creating it...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist? {Exists(newFolder)}");
    Write("Confirm the directory exists, and then press ENTER: ");  
    ReadLine();
     // delete directory
    WriteLine("Deleting it...");
    Delete(newFolder, recursive: true);
    WriteLine($"Does it exist? {Exists(newFolder)}"); 
}

static void WorkWithFiles(){
    WriteLine("======  ==   gestion des fichiers ======");
    // define a directory path to output files
    // starting in the user's folder
    string dir = Combine(
        GetFolderPath(SpecialFolder.Personal),
        "code", "Chapter09", "OutputFiles");
    // define file paths
    CreateDirectory(dir);
    string textFile = Combine(dir, "Dummy.txt");
    string backupFile = Combine(dir, "Dummy.bak");
    WriteLine($"Working with: {textFile}");

    // check if a file exists
    WriteLine($"Does it exist? {File.Exists(textFile)}");

     // create a new text file and write a line to it
    StreamWriter textWriter = File.CreateText(textFile);
    textWriter.WriteLine("Hello, C#!");
    textWriter.Close(); // close file and release resources
    WriteLine($"Does it exist? {File.Exists(textFile)}");

    // copy the file, and overwrite if it already exists
    File.Copy(sourceFileName: textFile,
        destFileName: backupFile, overwrite: true);
    WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
    Write("Confirm the files exist, and then press ENTER: ");
    ReadLine();

    // delete file
    File.Delete(textFile);
    WriteLine($"Does exist?,{File.Exists(textFile)}");

    // read from the text file backup
    WriteLine($"Reading contents of {backupFile}");
    StreamReader textReader =  File.OpenText(backupFile);
    WriteLine(textReader.ReadToEnd);
    textReader.Close();

    // Managing paths
    WriteLine($"Folder Name: {GetDirectoryName(textFile)}"); 
    WriteLine($"Nom du dossier: {GetDirectoryName(textFile)}");
    WriteLine($"Nom du fichier: {GetFileName(textFile)}");
    WriteLine("File Name without Extension: {0}",GetFileNameWithoutExtension(textFile)); 
    WriteLine($"Random File Name: {GetRandomFileName()}");
    WriteLine($"Temporary File Name: {GetTempFileName()}");
    WriteLine("======      utilisation de FileInfo   ======== ");
    FileInfo info = new(backupFile);
    WriteLine($"{backupFile}:");
    WriteLine($"Contains {info.Length} bytes");
    WriteLine($"Last accessed {info.LastAccessTime}");
    WriteLine($"Has readonly set to {info.IsReadOnly}");
    
    WriteLine("================================Controlling how you work with files===========");
    WriteLine("Is the backup file compressed? {0}",
        info.Attributes.HasFlag(FileAttributes.Compressed));
}