using System.Collections.Generic;
using Triangles.Helpers.Interfaces;
using Triangles.Models;

namespace Triangles.Helpers
{
    public class TrianglesFactory : ITrianglesFactory
    {
        private readonly ITrianglesColorizer _colorizer;
        private readonly ITrianglesFileReader _fileReader;

        public TrianglesFactory(ITrianglesColorizer colorizer, ITrianglesFileReader fileReader)
        {
            _colorizer = colorizer;
            _fileReader = fileReader;
        }

        public List<Triangle> CreateTriangles(string fileName)
        {
            var triangles = _fileReader.GetTriangles(fileName);
            _colorizer.SetColorLevels(triangles);
            return triangles;
        }
    }
}
