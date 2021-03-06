﻿namespace XMLEdit.Controls
{
    partial class EditCategory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlsGrpbx = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.nameTxtbx = new System.Windows.Forms.TextBox();
            this.typeTxtbx = new System.Windows.Forms.TextBox();
            this.typeLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.controlsGrpbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsGrpbx
            // 
            this.controlsGrpbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsGrpbx.Controls.Add(this.saveBtn);
            this.controlsGrpbx.Controls.Add(this.nameTxtbx);
            this.controlsGrpbx.Controls.Add(this.typeTxtbx);
            this.controlsGrpbx.Controls.Add(this.typeLbl);
            this.controlsGrpbx.Controls.Add(this.nameLbl);
            this.controlsGrpbx.Location = new System.Drawing.Point(3, 3);
            this.controlsGrpbx.Name = "controlsGrpbx";
            this.controlsGrpbx.Size = new System.Drawing.Size(498, 510);
            this.controlsGrpbx.TabIndex = 0;
            this.controlsGrpbx.TabStop = false;
            this.controlsGrpbx.Text = "Edit category";
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(416, 71);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Apply";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // nameTxtbx
            // 
            this.nameTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTxtbx.Location = new System.Drawing.Point(46, 19);
            this.nameTxtbx.Name = "nameTxtbx";
            this.nameTxtbx.Size = new System.Drawing.Size(445, 20);
            this.nameTxtbx.TabIndex = 2;
            // 
            // typeTxtbx
            // 
            this.typeTxtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeTxtbx.Location = new System.Drawing.Point(47, 45);
            this.typeTxtbx.Name = "typeTxtbx";
            this.typeTxtbx.Size = new System.Drawing.Size(445, 20);
            this.typeTxtbx.TabIndex = 2;
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Location = new System.Drawing.Point(6, 48);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(31, 13);
            this.typeLbl.TabIndex = 1;
            this.typeLbl.Text = "Type";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(6, 22);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(35, 13);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name";
            // 
            // EditCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlsGrpbx);
            this.Name = "EditCategory";
            this.Size = new System.Drawing.Size(504, 516);
            this.controlsGrpbx.ResumeLayout(false);
            this.controlsGrpbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox controlsGrpbx;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label typeLbl;
        private System.Windows.Forms.TextBox nameTxtbx;
        private System.Windows.Forms.TextBox typeTxtbx;
        private System.Windows.Forms.Button saveBtn;
    }
}
