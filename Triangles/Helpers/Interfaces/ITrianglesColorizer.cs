using System.Collections.Generic;
using Triangles.Models;

namespace Triangles.Helpers.Interfaces
{
    public interface ITrianglesColorizer
    {
        void SetColorLevels(List<Triangle> triangles);
    }
}