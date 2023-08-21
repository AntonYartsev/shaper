using NUnit.Framework;
using Shaper.Shapes;

namespace Tests;

public class CircleTest
{
    private Shaper.Shapes.Circle circle;
    private const double testedRadius = 6;
    
    [SetUp]
    public void Setup()
    {
        circle = new Circle(testedRadius);
    }

    [Test]
    public void AreaTest()
    {
        var expectedArea = Math.PI * testedRadius * testedRadius;
        var actualArea = circle.Area;
        Assert.AreEqual(expectedArea, actualArea);
    }
}