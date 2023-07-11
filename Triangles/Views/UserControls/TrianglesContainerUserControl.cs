using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Triangles.Models;

namespace Triangles
{
    // this user control is only responsible for triangles drawing
    public partial class TrianglesContainerUserControl : UserControl
    {
        private Color BackgroundColor { get; } = Color.LightGreen;

        public TrianglesContainerUserControl()
        {
            InitializeComponent();
        }

        public void DrawTriangles(List<Triangle> triangles)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.BackColor = BackgroundColor;

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

        private Color GetTriangleColor(int maxColorLevel, int colorLevel)
        {
            if (colorLevel > maxColorLevel)
            {
                throw new ArgumentException();
            }
            if (colorLevel == 0)
            {
                return BackgroundColor;
            }

            var firstLevelGreenValue = 255;
            var lastLevelGreenValue = 65;

            if (colorLevel == 1)
            {
                return Color.FromArgb(0, firstLevelGreenValue, 0);
            }
            // colorLevel > 1 => maxColorLevel > 1
            var step = (firstLevelGreenValue - lastLevelGreenValue) / (maxColorLevel - 1);
            var greenValue = firstLevelGreenValue - (colorLevel - 1) * step;
            return Color.FromArgb(0, greenValue, 0);
        }
    }
}
