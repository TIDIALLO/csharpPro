﻿using static System.Console;

WriteLine("I can run everywhere!");
if (OperatingSystem.IsMacOS()){
    WriteLine("I am macOS."); 
}
else if (OperatingSystem.IsWindowsVersionAtLeast(major: 10)) {
    WriteLine("I am Windows 10 or 11."); 
}
else
{
    WriteLine("I am some other mysterious OS."); 
}
WriteLine("Press ENTER to stop me."); 
ReadLine(); 