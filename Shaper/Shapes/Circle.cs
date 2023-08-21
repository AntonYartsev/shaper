namespace Shaper.Shapes;

public class Circle : IShape
{
    public double Radius { get; init; }
    
    public Circle(double radius) => Radius = radius;
    
    public double Area => Math.PI * Radius * Radius;
}