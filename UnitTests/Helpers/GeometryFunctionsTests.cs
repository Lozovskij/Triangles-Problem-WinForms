using FluentAssertions;
using System.Drawing;
using Triangles.Helpers;
using Triangles.Models;

namespace UnitTests.Helpers;

public class GeometryFunctionsTests
{
    [Theory]
    [InlineData(new int[] { 0, 0, 0, 300, 200, 300 }, 30000)]
    [InlineData(new int[] { 150, 200, 250, 0, 350, 200 }, 20000)]
    public void CalculateArea_Success(int[] coordinates, double expectedArea)
    {
        //Arrange
        var a = new Point(coordinates[0], coordinates[1]);
        var b = new Point(coordinates[2], coordinates[3]);
        var c = new Point(coordinates[4], coordinates[5]);

        //Act
        var area = GeometryFunctions.CalculateArea(a, b, c);

        //Assert
        area.Should().Be(expectedArea);
    }

    [Theory]
    //triangles with same coordinates
    [InlineData(new int[] { 0, 300, 150, 0, 300, 300 }, new int[] { 0, 300, 150, 0, 300, 300 }, true)]
    //parent and child (order mixed up)
    [InlineData(new int[] { 0, 300, 150, 0, 300, 300 }, new int[] { 100, 250, 150, 200, 200, 250 }, false)]
    //child and parent
    [InlineData(new int[] { 100, 250, 150, 200, 200, 250 }, new int[] { 0, 300, 150, 0, 300, 300 }, true)]
    //unrelated triangles
    [InlineData(new int[] { 0, 300, 150, 0, 300, 300 }, new int[] { 250, 100, 300, 100, 300, 0 }, false)]
    //child and parent, but one vertex is on the line segment
    [InlineData(new int[] { 100, 250, 200, 100, 200, 250 }, new int[] { 0, 300, 150, 0, 300, 300 }, true)]
    //two vertexes are inside and one is outside
    [InlineData(new int[] { 100, 250, 200, 250, 250, 50 }, new int[] { 0, 300, 150, 0, 300, 300 }, false)]
    public void IsFirstTrianlgeInside_Success(int[] coordinates1, int[] coordinates2, bool expected)
    {
        //Arrange
        var t1 = new Triangle(coordinates1);
        var t2 = new Triangle(coordinates2);

        //Act
        var res = GeometryFunctions.IsFirstTrianlgeInside(t1, t2);

        //Assert
        res.Should().Be(expected);
    }

    [Theory]
    //triangles with same coordinates
    [InlineData(new int[] { 0, 300, 150, 0, 300, 300 }, new int[] { 0, 300, 150, 0, 300, 300 }, false)]
    //two vertexes are inside and one is outside
    [InlineData(new int[] { 0, 300, 150, 0, 300, 300 }, new int[] { 100, 250, 200, 250, 250, 50 }, true)]
    //parent and child
    [InlineData(new int[] { 0, 300, 150, 0, 300, 300 }, new int[] { 100, 250, 150, 200, 200, 250 }, false)]
    //unrelated triangles
    [InlineData(new int[] { 0, 300, 150, 0, 300, 300 }, new int[] { 250, 100, 300, 100, 300, 0 }, false)]
    //6 intersections
    [InlineData(new int[] { 0, 50, 300, 50, 150, 250 }, new int[] { 50, 200, 150, 0, 250, 200 }, true)]
    //parent and child, but one vertex is on the line segment
    [InlineData(new int[] { 0, 300, 150, 0, 300, 300 }, new int[] { 100, 250, 200, 100, 200, 250 }, false)]
    //intersection with x of intersection point being equal to x's of line segment endpoints
    [InlineData(new int[] { 0, 300, 0, 0, 300, 0 }, new int[] { 50, 0, 50, 300, 300, 0 }, true)]
    public void TrianglesIntersecting_Success(int[] coordinates1, int[] coordinates2, bool expected)
    {
        //Arrange
        var t1 = new Triangle(coordinates1);
        var t2 = new Triangle(coordinates2);

        //Act
        var res = GeometryFunctions.TrianglesIntersecting(t1, t2);

        //Assert
        res.Should().Be(expected);
    }
}
