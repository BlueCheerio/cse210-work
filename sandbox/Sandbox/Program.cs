using System;
using System.Diagnostics.Contracts;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        string weight = "kg/lb";
        string temp = "farenheit/celsius";
        string distance = "meter/foot";
        bool dcont = true;
        while (dcont)
        {
            Console.WriteLine("Welcome to the unit converter, please select a conversion (write the exact answer):");
            Console.WriteLine(weight);
            Console.WriteLine(temp);
            Console.WriteLine(distance);
            string answer = Console.ReadLine();
            if (answer != weight || answer != temp || answer != distance)
            {
                Console.WriteLine("Please input the exact answer!");
            }
            else
            {
                dcont = false;
            }
        }
        

    }
}