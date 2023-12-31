﻿namespace Triangles.Views
{
    partial class TrianglesView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.colorPickerPrevewBox = new System.Windows.Forms.PictureBox();
            this.trianglesContainer1 = new Triangles.TrianglesContainerUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickerPrevewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "No Data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(13, 115);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(166, 247);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnPickColor
            // 
            this.btnPickColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickColor.Location = new System.Drawing.Point(13, 394);
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.Size = new System.Drawing.Size(166, 65);
            this.btnPickColor.TabIndex = 7;
            this.btnPickColor.Text = "set color";
            this.btnPickColor.UseVisualStyleBackColor = true;
            this.btnPickColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // colorPickerPrevewBox
            // 
            this.colorPickerPrevewBox.Location = new System.Drawing.Point(13, 465);
            this.colorPickerPrevewBox.Name = "colorPickerPrevewBox";
            this.colorPickerPrevewBox.Size = new System.Drawing.Size(166, 35);
            this.colorPickerPrevewBox.TabIndex = 8;
            this.colorPickerPrevewBox.TabStop = false;
            // 
            // trianglesContainer1
            // 
            this.trianglesContainer1.AccessibleName = "";
            this.trianglesContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trianglesContainer1.Location = new System.Drawing.Point(192, 6);
            this.trianglesContainer1.Name = "trianglesContainer1";
            this.trianglesContainer1.Size = new System.Drawing.Size(1000, 1000);
            this.trianglesContainer1.TabIndex = 6;
            // 
            // TrianglesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 615);
            this.Controls.Add(this.colorPickerPrevewBox);
            this.Controls.Add(this.btnPickColor);
            this.Controls.Add(this.trianglesContainer1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Name = "TrianglesView";
            this.Text = "TrianglesView";
            ((System.ComponentModel.ISupportInitialize)(this.colorPickerPrevewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private TrianglesContainerUserControl trianglesContainer1;
        private System.Windows.Forms.Button btnPickColor;
        private System.Windows.Forms.PictureBox colorPickerPrevewBox;
    }
}