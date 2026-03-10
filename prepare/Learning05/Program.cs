using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square("green", 5),
            new Rectangle("purple", 10, 5),
            new Circle("Red", 1)
        };

        foreach (Shape item in shapes)
        {
            if (item is Square)
            {
                Console.WriteLine("\nThis is a Square:");
            }
            else if (item is Rectangle)
            {
                Console.WriteLine("\nThis is a Rectangle:");
            }
            else if (item is Circle)
            {
                Console.WriteLine("\nThis is a Circle:");
            }
            Console.WriteLine($"Color: {item.GetColor()}");
            Console.WriteLine($"Area: {item.GetArea()}");
        }
    }
}