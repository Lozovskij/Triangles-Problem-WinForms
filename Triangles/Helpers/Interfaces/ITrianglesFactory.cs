using System.Collections.Generic;
using Triangles.Models;

namespace Triangles.Helpers.Interfaces
{
    public interface ITrianglesFactory
    {
        List<Triangle> CreateTriangles(string fileName);
    }
}