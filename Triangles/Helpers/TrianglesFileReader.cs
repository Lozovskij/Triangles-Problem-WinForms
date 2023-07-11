using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Triangles.Helpers.Interfaces;
using Triangles.Models;

namespace Triangles.Helpers
{
    public class TrianglesFileReader : ITrianglesFileReader
    {
        public List<Triangle> GetTriangles(string fileName)
        {
            // TODO: write wrapper for File.ReadAllLines or use System.IO.Abstractions package

            // first value Is not a number
            // first value is out of range [1,1000]
            // line does not have 6 values
            // not all values of a line are numbers
            // not all coordinates in range [0, 1000]
            var lines = File.ReadAllLines(fileName);
            var count = int.Parse(lines[0]);
            if (count < 1 || count > 1000)
            {
                throw new Exception("first value should be in range [1, 1000]");
            }
            var res = new List<Triangle>(count);
            var coodinatesPerLine = 6;
            for (int i = 1; i <= count; i++)
            {
                var line = lines[i];
                var coordinates = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(str => int.Parse(str)).ToArray();
                if (coordinates.Length != coodinatesPerLine)
                {
                    throw new Exception(
                        $"line {i + 1} has {coordinates.Length} coordinates but it should have 6");
                }
                if (coordinates.Any(c => c < 0 || c > 1000))
                {
                    throw new Exception(
                        $"line {i + 1} should have coordinates in range [0, 1000]");
                }

                res.Add(new Triangle(coordinates));
            }
            return res;
        }
    }
}
