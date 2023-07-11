using System.Collections.Generic;
using Triangles.Models;
using Triangles.Models.Helpers.Interfaces;

namespace Triangles.Models.Helpers
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
