using Shaper.Shapes;
using System;

namespace InteractiveConsoleApp
{
    internal abstract class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello reviewer! Lets play with shapes");
            while (true)
            {
                Console.WriteLine("Enter command (or 'exit'):");
                Console.WriteLine("1 - Circle area");
                Console.WriteLine("2 - Triangle area and rectangular check");
                
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    continue;
                
                switch (input.ToLower())
                {
                    case "1":
                    {
                        Console.WriteLine("Enter radius:");
                        var radius = Console.ReadLine();
                        if (string.IsNullOrEmpty(radius))
                            continue;
                        var circle = new Circle(Convert.ToDouble(radius));
                        Console.WriteLine($"For circle with radius {radius}:");
                        Console.WriteLine($"    Area is {Math.Round(circle.Area, 2)}");
                        continue;
                    }
                    case "2":
                    {
                        Console.WriteLine("Enter side A:");
                        var sideA = Console.ReadLine();
                        if (string.IsNullOrEmpty(sideA))
                            continue;
                    
                        Console.WriteLine("Enter side B:");
                        var sideB = Console.ReadLine();
                        if (string.IsNullOrEmpty(sideB))
                            continue;
                    
                        Console.WriteLine("Enter side C:");
                        var sideC = Console.ReadLine();
                        if (string.IsNullOrEmpty(sideC))
                            continue;

                        try
                        {
                            var triangle = new Triangle(Convert.ToDouble(sideA), Convert.ToDouble(sideB),
                                Convert.ToDouble(sideC));
                            Console.WriteLine(
                                $"For triangle (a:{sideA},b:{sideB},c:{sideC}):");
                            Console.WriteLine($"    Area is {Math.Round(triangle.Area, 2)}");
                            Console.WriteLine($"    Is rectangular: {triangle.IsRectangular()}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        continue;
                    }
                }

                if (input.ToLower() == "exit")
                    break;

                Console.WriteLine($"You entered: {input}");
            }
        }
    }
}

