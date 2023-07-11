using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Triangles.Models;

namespace Triangles.Views
{
    public partial class TrianglesView : Form, ITrianglesView
    {
        private List<Triangle> _triangles;
        private string _errorMessage;

        public TrianglesView()
        {
            InitializeComponent();
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

        private void ShowErrorMessage()
        {
            MessageBox.Show(_errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
