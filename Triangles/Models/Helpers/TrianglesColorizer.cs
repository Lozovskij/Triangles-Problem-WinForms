using System.Collections.Generic;
using System.Linq;
using Triangles.Models;
using Triangles.Models.Helpers.Interfaces;

namespace Triangles.Models.Helpers
{
    public class TrianglesColorizer : ITrianglesColorizer
    {
        public void SetColorLevels(List<Triangle> triangles)
        {
            // define parent for each triangle
            triangles = triangles.OrderBy(t => t.Area).ToList();
            for (int i = 0; i < triangles.Count - 1; i++)
            {
                for (int j = i + 1; j < triangles.Count; j++)
                {
                    if (GeometryFunctions.IsFirstTrianlgeInside(triangles[i], triangles[j]))
                    {
                        triangles[i].Parent = triangles[j];
                        j = triangles.Count;
                        continue;
                    }
                }
            }

            // define intersection flag for each triangle
            for (int i = 0; i < triangles.Count - 1; i++)
            {
                for (int j = i + 1; j < triangles.Count; j++)
                {

                    if (triangles[i].IsIntersected && triangles[j].IsIntersected)
                    {
                        continue;
                    }
                    if (GeometryFunctions.TrianglesIntersecting(triangles[i], triangles[j]))
                    {
                        triangles[i].IsIntersected = true;
                        triangles[j].IsIntersected = true;
                    }
                }
            }

            // calculate color level based on parent
            for (int i = 0; i < triangles.Count; i++)
            {
                SetColorLevelRecursively(triangles[i]);
            }
        }

        private void SetColorLevelRecursively(Triangle triangle)
        {
            var parent = triangle.Parent;
            if (parent == null)
            {
                triangle.ColorLevel = triangle.IsIntersected ? 0 : 1;
                return;
            }

            var unset = -1;
            if (parent.ColorLevel == unset)
            {
                SetColorLevelRecursively(parent);
            }

            triangle.ColorLevel = triangle.IsIntersected
                ? parent.ColorLevel
                : parent.ColorLevel + 1;

            return;
        }
    }
}
