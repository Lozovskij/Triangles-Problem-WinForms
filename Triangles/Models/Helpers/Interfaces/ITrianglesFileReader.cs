using System.Collections.Generic;
using Triangles.Models;

namespace Triangles.Models.Helpers.Interfaces
{
    public interface ITrianglesFileReader
    {
        List<Triangle> GetTriangles(string fileName);
    }
}