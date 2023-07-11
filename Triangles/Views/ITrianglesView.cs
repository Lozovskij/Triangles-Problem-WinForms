using System;
using System.Collections.Generic;
using Triangles.Models;

namespace Triangles.Views
{
    public interface ITrianglesView
    {
        List<Triangle> Triangles { get; set; }

        string ShadesCountText { get; set; }

        string ErrorMessage { get; set; }

        event EventHandler<string> Import;

        void Show();
    }
}
