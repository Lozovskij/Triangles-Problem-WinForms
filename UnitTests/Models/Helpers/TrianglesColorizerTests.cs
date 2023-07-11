using FluentAssertions;
using Triangles.Models;
using Triangles.Models.Helpers;

namespace UnitTests.Models.Helpers;

public class TrianglesColorizerTests
{
    [Fact]
    public void SetColorLevels_ParentAndChild_LevelsOneAndTwo()
    {
        //Arrange
        var sut = new TrianglesColorizer();
        var parent = new Triangle(new int[] { 0, 300, 150, 0, 300, 300 });
        var child = new Triangle(new int[] { 100, 250, 150, 200, 200, 250 });
        var triangles = new List<Triangle>
        {
            parent, child
        };

        //Act
        sut.SetColorLevels(triangles);

        //Assert
        parent.ColorLevel.Should().Be(1);
        child.ColorLevel.Should().Be(2);
    }

    [Fact]
    public void SetColorLevels_TriangleNestedInIntersectedTriangles_LevelsZeroZeroOne()
    {
        //Arrange
        var sut = new TrianglesColorizer();
        var intersected1 = new Triangle(new int[] { 0, 300, 0, 0, 300, 0 });
        var intersected2 = new Triangle(new int[] { 50, 0, 50, 300, 300, 0 });
        var child = new Triangle(new int[] { 100, 0, 200, 0, 100, 100 });
        var triangles = new List<Triangle>
        {
            intersected1, intersected2, child
        };

        //Act
        sut.SetColorLevels(triangles);

        //Assert
        intersected1.ColorLevel.Should().Be(0);
        intersected2.ColorLevel.Should().Be(0);
        child.ColorLevel.Should().Be(1);
    }

    [Fact]
    public void SetColorLevels_AllNestedIntersected_AllLevelsZero()
    {
        //Arrange
        var sut = new TrianglesColorizer();
        var intersector = new Triangle(new int[] { 0, 0, 0, 300, 300, 300 });
        var nested1 = new Triangle(new int[] { 0, 300, 300, 300, 300, 0 });
        var nested2 = new Triangle(new int[] { 100, 300, 300, 300, 300, 100 });
        var nested3 = new Triangle(new int[] { 200, 300, 300, 300, 300, 200 });
        var triangles = new List<Triangle>
        {
            intersector, nested1, nested2, nested3
        };

        //Act
        sut.SetColorLevels(triangles);

        //Assert
        intersector.ColorLevel.Should().Be(0);
        nested1.ColorLevel.Should().Be(0);
        nested2.ColorLevel.Should().Be(0);
        nested3.ColorLevel.Should().Be(0);
    }

    [Fact]
    public void SetColorLevels_UnrelatedTriangles_AllLevelsOne()
    {
        //Arrange
        var sut = new TrianglesColorizer();
        var t1 = new Triangle(new int[] { 100, 0, 0, 100, 100, 100 });
        var t2 = new Triangle(new int[] { 200, 100, 200, 200, 100, 200 });
        var triangles = new List<Triangle>
        {
            t1, t2
        };

        //Act
        sut.SetColorLevels(triangles);

        //Assert
        t1.ColorLevel.Should().Be(1);
        t2.ColorLevel.Should().Be(1);
    }
}
