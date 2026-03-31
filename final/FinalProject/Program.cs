using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        //The Lists for Events and investments and the randomly generated names that they could recieve
        List<Event> Events = new List<Event>();
        List<Investment> Investments = new List<Investment>();
        List<string> InvestmentNames = new List<string>();
        List<string> BadEventNames = new List<string>();
        List<string> GoodEventNames = new List<string>(); 
        
        Random generate = new Random();
        int gameTime = 0;
        float money = 0;

        Console.WriteLine("Hello FinalProject World!");
    }
}