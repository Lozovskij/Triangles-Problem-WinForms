using AutoFixture;
using FluentAssertions;
using Moq;
using Triangles.Models;
using Triangles.Models.Helpers.Interfaces;
using Triangles.Presenters;
using Triangles.Views;

namespace UnitTests.Presenters;

public class TrianglesPresenterTests
{
    [Fact]
    public void Import_TrianglesWithIntersection_ShadesCountTextIsError()
    {
        //Arrange
        var f = new Fixture();
        var triangles = new List<Triangle>() {
            new Triangle(new int[] { 100, 250, 200, 250, 250, 50 }),
            new Triangle(new int[] { 0, 300, 150, 0, 300, 300 }) };
        triangles[0].IsIntersected = true;
        triangles[1].IsIntersected = true;
        var viewMock = new Mock<ITrianglesView>();
        var factoryMock = new Mock<ITrianglesFactory>();
        factoryMock.Setup(m => m.CreateTriangles(It.IsAny<string>())).Returns(triangles);
        var presenter = new TrianglesPresenter(viewMock.Object, factoryMock.Object);

        //Act
        presenter.Import(f.Create<object>(), f.Create<string>());

        //Assert
        viewMock.VerifySet(m => m.ShadesCountText = "Error");
    }

    [Fact]
    public void Import_TrianglesWithoutIntersection_ShadesCountTextIsNumber()
    {
        //Arrange
        var f = new Fixture();
        var triangles = new List<Triangle>() {
            new Triangle(new int[] { 100, 250, 200, 250, 250, 50 }),
            new Triangle(new int[] { 0, 300, 150, 0, 300, 300 }) };
        triangles[0].ColorLevel = 1;
        triangles[1].ColorLevel = 1;
        var factoryMock = new Mock<ITrianglesFactory>();
        var viewMock = new DummyView();
        factoryMock.Setup(m => m.CreateTriangles(It.IsAny<string>())).Returns(triangles);
        var presenter = new TrianglesPresenter(viewMock, factoryMock.Object);

        //Act
        presenter.Import(f.Create<object>(), f.Create<string>());

        //Assert
        Action act = () => int.Parse(viewMock.ShadesCountText);
        act.Should().NotThrow();
    }

    [Fact]
    public void Import_OneTriangle_ShadesCountIsTwo()
    {
        //Arrange
        var f = new Fixture();
        var triangles = new List<Triangle>() {
            new Triangle(new int[] { 100, 250, 200, 250, 250, 50 })};
        triangles[0].ColorLevel = 1;
        var factoryMock = new Mock<ITrianglesFactory>();
        var viewMock = new DummyView();
        factoryMock.Setup(m => m.CreateTriangles(It.IsAny<string>())).Returns(triangles);
        var presenter = new TrianglesPresenter(viewMock, factoryMock.Object);

        //Act
        presenter.Import(f.Create<object>(), f.Create<string>());

        //Assert
        viewMock.ShadesCountText.Should().Be("2");
    }

    private class DummyView : ITrianglesView
    {
        public List<Triangle> Triangles { get; set; }
        public string ShadesCountText { get; set; }
        public string ErrorMessage { get; set; }
        public event EventHandler<string> Import;
        public void Show() { }
    }
}