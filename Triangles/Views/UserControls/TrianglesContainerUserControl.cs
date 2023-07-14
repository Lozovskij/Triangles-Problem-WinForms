using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Triangles.Models;

namespace Triangles
{
    /// <summary>
    /// control for drawing triangles
    /// </summary>
    public partial class TrianglesContainerUserControl : UserControl
    {
        private byte _maxColorChange;
        private Color _backColor;
        private List<Triangle> _triangles;

        public override Color BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                _maxColorChange = MinColorValue(value);
            }
        }

        public TrianglesContainerUserControl()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(133, 233, 133);
        }

        public void ApplyNewColor(Color color)
        {
            BackColor = color;
            if (_triangles != null)
            {
                DrawTriangles(_triangles);
            }
            else
            {
                SetUpNewDrawingArea();
            }
        }

        public void DrawTriangles(List<Triangle> triangles)
        {
            _triangles = triangles;
            SetUpNewDrawingArea();

            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var orderedTriangles = triangles
                    .OrderBy(t => t.ColorLevel)
                    .ThenBy(t => t.IsIntersected)
                    .ToArray();

                var maxColorLevel = orderedTriangles.Length > 0 ? triangles.Max(t => t.ColorLevel) : 0;

                var brush = new SolidBrush(Color.Empty);
                var pen = new Pen(Color.Black);
                foreach (Triangle t in orderedTriangles)
                {
                    var points = new[] { t.A, t.B, t.C };
                    if (!t.IsIntersected)
                    {
                        brush.Color = GetTriangleColor(maxColorLevel, t.ColorLevel);
                        g.FillPolygon(brush, points);
                    }
                    g.DrawPolygon(pen, points);
                }

                pictureBox1.Refresh();
            }
        }

        private void SetUpNewDrawingArea()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.BackColor = BackColor;
        }

        private byte MinColorValue(Color color)
        {
            return Math.Min(color.R, Math.Min(color.G, color.B));
        }

        private Color GetTriangleColor(int maxColorLevel, int colorLevel)
        {
            if (colorLevel > maxColorLevel)
            {
                throw new ArgumentException();
            }
            if (colorLevel == 0)
            {
                return BackColor;
            }

            var step = _maxColorChange / maxColorLevel;
            var colorChange = colorLevel * step;
            return Color.FromArgb(
                BackColor.R - colorChange,
                BackColor.G - colorChange,
                BackColor.B - colorChange);
        }
    }
}
