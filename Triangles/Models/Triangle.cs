using System.Drawing;
using System;
using Triangles.Models.Helpers;

namespace Triangles.Models
{
    public class Triangle
    {
        public Triangle(int[] coordinates)
        {
            if (coordinates.Length != 6)
            {
                throw new ArgumentException();
            }
            A = new Point(coordinates[0], coordinates[1]);
            B = new Point(coordinates[2], coordinates[3]);
            C = new Point(coordinates[4], coordinates[5]);
            Area = GeometryFunctions.CalculateArea(A, B, C);
            ColorLevel = -1; // unset
            LineSegments = new LineSegment[3]
            {
                new LineSegment { FirstPoint = A, SecondPoint = B },
                new LineSegment { FirstPoint = B, SecondPoint = C },
                new LineSegment { FirstPoint = C, SecondPoint = A },
            };
        }

        public Point A { get; }

        public Point B { get; }

        public Point C { get; }

        public double Area { get; }

        //1 - lightest, 2 is darker and so on
        //0 - no color
        //-1 - unset
        public int ColorLevel { get; set; }

        public Triangle Parent { get; set; }

        public bool IsIntersected { get; set; }

        public LineSegment[] LineSegments { get; set; }
    }
}
