using System;
using System.Drawing;
using Triangles.Models;

namespace Triangles.Helpers
{
    public static class GeometryFunctions
    {
        public static double CalculateArea(Point first, Point second, Point third)
        {
            return 0.5 * Math.Abs(
                (first.X - third.X) * (second.Y - third.Y) -
                (second.X - third.X) * (first.Y - third.Y));
        }

        public static bool IsFirstTrianlgeInside(Triangle small, Triangle big)
        {
            return IsPointInsideTriangle(big, small.A) &&
                IsPointInsideTriangle(big, small.B) &&
                IsPointInsideTriangle(big, small.C);
        }

        public static bool TrianglesIntersecting(Triangle triangle1, Triangle triangle2)
        {
            var lineSegments1 = triangle1.LineSegments;
            var lineSegments2 = triangle2.LineSegments;
            return LineSegmentsIntersecting(lineSegments1[0], lineSegments2[0]) ||
                 LineSegmentsIntersecting(lineSegments1[0], lineSegments2[1]) ||
                 LineSegmentsIntersecting(lineSegments1[0], lineSegments2[2]) ||
                 LineSegmentsIntersecting(lineSegments1[1], lineSegments2[0]) ||
                 LineSegmentsIntersecting(lineSegments1[1], lineSegments2[1]) ||
                 LineSegmentsIntersecting(lineSegments1[1], lineSegments2[2]) ||
                 LineSegmentsIntersecting(lineSegments1[2], lineSegments2[0]) ||
                 LineSegmentsIntersecting(lineSegments1[2], lineSegments2[1]) ||
                 LineSegmentsIntersecting(lineSegments1[2], lineSegments2[2]);
        }

        // only checks intersection in between line segment endpoints
        private static bool LineSegmentsIntersecting(LineSegment ls1, LineSegment ls2)
        {
            // for a single line
            // A*x1 + B*y1 = C
            // A*x2 + B*y2 = C

            // setting A, B
            // A = y2 - y1
            // B = x1 - x2
            // C = A*x1 + B*y1
            var A1 = ls1.SecondPoint.Y  - ls1.FirstPoint.Y;
            var B1 = ls1.FirstPoint.X - ls1.SecondPoint.X;
            var C1 = A1 * ls1.FirstPoint.X + B1 * ls1.FirstPoint.Y;

            var A2 = ls2.SecondPoint.Y - ls2.FirstPoint.Y;
            var B2 = ls2.FirstPoint.X - ls2.SecondPoint.X;
            var C2 = A2 * ls2.FirstPoint.X + B2 * ls2.FirstPoint.Y;

            // A1 * x + B1 * y = C1
            // A2 * x + B2 * y = C2
            // (x, y) - lines intersection point
            double det = A1 * B2 - A2 * B1;
            if (det == 0)
            {
                // lines are parallel
                return false;
            }

            // (x, y) - lines intersection point
            double x = (B2 * C1 - B1 * C2) / det;
            double y = (A1 * C2 - A2 * C1) / det;

            bool isEndpoint =
                (x, y) == (ls1.FirstPoint.X, ls1.FirstPoint.Y) ||
                (x, y) == (ls1.SecondPoint.X, ls1.SecondPoint.Y) ||
                (x, y) == (ls2.FirstPoint.X, ls2.FirstPoint.Y) ||
                (x, y) == (ls2.SecondPoint.X, ls2.SecondPoint.Y);

            if (isEndpoint)
            {
                return false;
            }

            // return true if (x, y) is located on line segments
            return Math.Min(ls1.FirstPoint.X, ls1.SecondPoint.X) <= x &&
                Math.Max(ls1.FirstPoint.X, ls1.SecondPoint.X) >= x &&
                Math.Min(ls1.FirstPoint.Y, ls1.SecondPoint.Y) <= y &&
                Math.Max(ls1.FirstPoint.Y, ls1.SecondPoint.Y) >= y &&
                Math.Min(ls2.FirstPoint.X, ls2.SecondPoint.X) <= x &&
                Math.Max(ls2.FirstPoint.X, ls2.SecondPoint.X) >= x &&
                Math.Min(ls2.FirstPoint.Y, ls2.SecondPoint.Y) <= y &&
                Math.Max(ls2.FirstPoint.Y, ls2.SecondPoint.Y) >= y;
        }

        private static bool IsPointInsideTriangle(Triangle triangle, Point point)
        {
            var area1 = CalculateArea(point, triangle.A, triangle.B);
            var area2 = CalculateArea(point, triangle.B, triangle.C);
            var area3 = CalculateArea(point, triangle.C, triangle.A);
            return area1 + area2 + area3 == triangle.Area;
        }
    }
}
