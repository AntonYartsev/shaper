namespace Shaper.Shapes;

public class Triangle : AbstractTriangle
{
    public Triangle(double sideA, double sideB, double sideC) : base(sideA, sideB, sideC)
    {
    }
    
    public override double Area
    {
        get
        {
            // perimeter first
            var p = (sideA + sideB + sideC) / 2;
            // and area by Herons formula
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }
    }
}

// abstract triangle class for triangle-specific logic
public abstract class AbstractTriangle : IShape
{
    public double sideA { get;  }
    public double sideB { get;  }
    public double sideC { get;  }
    
    protected AbstractTriangle(double sideA, double sideB, double sideC)
    {
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
        
        if (!IsValid())
            throw new ArgumentException("Invalid triangle sides");
    }

    public bool IsValid()
    {
        return sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA;
    }
    
    public bool IsRectangular()
    {
        // by the Pythagoras theorem
        var sides = new[] { sideA, sideB, sideC }.OrderBy(x => x).ToArray();
        return Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < 1e-10;
    }
    
    public bool IsRectangularAlt()
    {
        // by the reverse Pythagoras theorem
        var sides = new[] { sideA, sideB, sideC }.OrderBy(x => x).ToArray();
        var hypotenuse = sides[2] * sides[2];
        var otherSides = sides[1] * sides[1] + sides[0] * sides[0];
        return hypotenuse == otherSides;
    }

    public abstract double Area { get;}
}