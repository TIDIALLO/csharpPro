// See https://aka.ms/new-console-template for more information
using System;
using Packt;
using static System.Console;


WriteLine("In Main"); 
Alpha();
static void Alpha(){
    WriteLine("In Alpha");
    Beta(); 
}
static void Beta(){
    WriteLine("In Beta");
    Calculator.Gamma(); 
}