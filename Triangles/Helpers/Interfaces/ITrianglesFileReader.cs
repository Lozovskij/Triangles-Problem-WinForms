using System.Collections.Generic;
using Triangles.Models;

namespace Triangles.Helpers.Interfaces
{
    public interface ITrianglesFileReader
    {
        List<Triangle> GetTriangles(string fileName);
    }
}