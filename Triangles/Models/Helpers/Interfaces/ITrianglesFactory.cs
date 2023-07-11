using System.Collections.Generic;
using Triangles.Models;

namespace Triangles.Models.Helpers.Interfaces
{
    public interface ITrianglesFactory
    {
        List<Triangle> CreateTriangles(string fileName);
    }
}