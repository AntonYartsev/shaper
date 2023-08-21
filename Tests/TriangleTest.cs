using NUnit.Framework;
using Shaper;
using Shaper.Shapes;

namespace Tests;

public class TriangleTest
{
    private Triangle acuteTriangle;
    private Triangle rectangularTriangle;
    private List<double> acuteSides = new() { 3, 4, 6 };
    private List<double> rectangularSides = new() { 10, 24, 26 };
    private List<double> invalidSides = new() { 12, 21, 54 };
    
    [SetUp]
    public void Setup()
    {
        acuteTriangle = new Triangle(acuteSides[0], acuteSides[1], acuteSides[2]);
        rectangularTriangle = new Triangle(rectangularSides[0], rectangularSides[1], rectangularSides[2]);
    }
    
    [Test]
    public void RectangularTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(rectangularTriangle.IsRectangular(), Is.True);
            Assert.That(acuteTriangle.IsRectangular(), Is.False);
        });
    }
    
    [Test]
    public void RectangularAltTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(rectangularTriangle.IsRectangularAlt(), Is.True);
            Assert.That(acuteTriangle.IsRectangularAlt(), Is.False);
        });
    }
    
    [Test]
    public void InvalidTriangleTest()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(invalidSides[0], invalidSides[1], invalidSides[2]));
    }

    [Test]
    public void AcuteTriangleAreaTest()
    {
        var p = (acuteSides[0] + acuteSides[1] + acuteSides[2]) / 2;
        var expectedArea = Math.Sqrt(p * (p - acuteSides[0]) * (p - acuteSides[1]) * (p - acuteSides[2]));
        var actualArea = acuteTriangle.Area;
        Assert.That(actualArea, Is.EqualTo(expectedArea));
    }
    
    [Test]
    public void RectangularTriangleAreaTest()
    {
        var p = (rectangularSides[0] + rectangularSides[1] + rectangularSides[2]) / 2;
        var expectedArea = Math.Sqrt(p * (p - rectangularSides[0]) * (p - rectangularSides[1]) * (p - rectangularSides[2]));
        var actualArea = rectangularTriangle.Area;
        Assert.That(actualArea, Is.EqualTo(expectedArea));
    }

    [Test][Description("Just for development test")]
    public void AreaWithoutType()
    {
        // get area for shape without type
        var shapes = new List<IShape>
        {
            new Circle(5),
            new Triangle(3, 4, 5)
        };
        
        foreach (var shape in shapes)
        {
            var area = shape.Area;
            TestContext.Out.WriteLine($"{shape.GetType()} area: {area}");
        }
        Assert.Pass();
    }
}