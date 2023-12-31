﻿using System;
using System.Collections.Generic;
using System.Linq;
using Triangles.Models;
using Triangles.Models.Helpers.Interfaces;
using Triangles.Views;

namespace Triangles.Presenters
{
    public class TrianglesPresenter
    {
        private readonly ITrianglesView _view;
        private readonly ITrianglesFactory _trianglesFactory;

        public TrianglesPresenter(ITrianglesView view, ITrianglesFactory trianglesFactory)
        {
            _view = view;
            _trianglesFactory = trianglesFactory;

            _view.Import += Import;
            _view.Show();
        }

        public void Import(object sender, string fileName)
        {
            try
            {
                var triangles = _trianglesFactory.CreateTriangles(fileName);
                _view.Triangles = triangles;
                _view.ShadesCountText = GetShadesCountText(triangles);
            }
            catch (Exception ex)
            {
                _view.ErrorMessage = ex.Message;
            }
        }

        private string GetShadesCountText(List<Triangle> triangles)
        {
            // don't forget to count rectangle
            var count = triangles.Any(t => t.IsIntersected) ? -1 : (triangles.Max(t => t.ColorLevel) + 1);
            var countStr = count == -1 ? "Error" : count.ToString();
            return countStr;
        }
    }
}
