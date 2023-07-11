using FluentAssertions;
using Triangles.Models;

namespace UnitTests.Models;

public class TriangleTests
{
    [Fact]
    public void Triangle_Create_ColorLevelIsMinusOne()
    {
        //Arrange
        var coodrinates = new int[] { 0, 0, 0, 300, 200, 300 };

        //Act
        var t = new Triangle(coodrinates);

        //Assert
        t.ColorLevel.Should().Be(-1);
    }
}
