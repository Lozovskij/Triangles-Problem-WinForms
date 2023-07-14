using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Triangles.Models;
using System.Drawing;

namespace Triangles.Views
{
    public partial class TrianglesView : Form, ITrianglesView
    {
        private List<Triangle> _triangles;
        private string _errorMessage;
        private Color _colorPickerColor;

        public TrianglesView()
        {
            InitializeComponent();
            colorPickerPrevewBox.BackColor = trianglesContainer1.BackColor;
        }

        public string ShadesCountText
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        public List<Triangle> Triangles
        {
            get => _triangles;
            set
            {
                _triangles = value;
                DrawTriangles();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                ShowErrorMessage();
            }
        }

        public Color ColorPickerColor
        {
            get => _colorPickerColor;
            set
            {
                _colorPickerColor = value;
                ApplyNewColor();
            }
        }

        public event EventHandler<string> Import;

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Import?.Invoke(this, fileDialog.FileName);
            }
        }

        private void DrawTriangles()
        {
            trianglesContainer1.DrawTriangles(_triangles);
        }

        private void ApplyNewColor()
        {
            trianglesContainer1.ApplyNewColor(_colorPickerColor);
        }


        private void ShowErrorMessage()
        {
            MessageBox.Show(_errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog()
            {
                FullOpen = true
            };
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                ColorPickerColor = colorDlg.Color;
                colorPickerPrevewBox.BackColor = colorDlg.Color;
            }
        }
    }
}
