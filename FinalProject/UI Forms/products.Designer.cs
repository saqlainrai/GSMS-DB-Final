﻿namespace FinalProject.UI_Forms
{
    partial class products
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
            this.delBtn = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.productsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.updateBtn = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.addBtn = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // delBtn
            // 
            this.delBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.delBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.delBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.delBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.delBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.delBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.delBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.delBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.delBtn.ForeColor = System.Drawing.Color.White;
            this.delBtn.Location = new System.Drawing.Point(721, 3);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(355, 83);
            this.delBtn.TabIndex = 1;
            this.delBtn.Text = "DELETE PRODUCTS";
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // productsPanel
            // 
            this.productsPanel.AutoSize = true;
            this.productsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.productsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsPanel.Location = new System.Drawing.Point(0, 89);
            this.productsPanel.Name = "productsPanel";
            this.productsPanel.Size = new System.Drawing.Size(1079, 584);
            this.productsPanel.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.updateBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.delBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.addBtn, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1079, 89);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // updateBtn
            // 
            this.updateBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.updateBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.updateBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.updateBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.updateBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.updateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.updateBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.updateBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.updateBtn.ForeColor = System.Drawing.Color.White;
            this.updateBtn.Location = new System.Drawing.Point(362, 3);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(353, 83);
            this.updateBtn.TabIndex = 2;
            this.updateBtn.Text = "UPDATE PRODUCTS";
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.addBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.addBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(3, 3);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(353, 83);
            this.addBtn.TabIndex = 1;
            this.addBtn.Text = "ADD PRODUCTS";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 673);
            this.Controls.Add(this.productsPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "products";
            this.Text = "products";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientTileButton delBtn;
        private System.Windows.Forms.Panel productsPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2GradientTileButton updateBtn;
        private Guna.UI2.WinForms.Guna2GradientTileButton addBtn;
    }
}