namespace FinalProject.UI_Forms
{
    partial class EmployeeDashBoard
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
            this.customersBtn = new Guna.UI2.WinForms.Guna2Button();
            this.flowPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.homeBtn = new Guna.UI2.WinForms.Guna2Button();
            this.supplierBtn = new Guna.UI2.WinForms.Guna2Button();
            this.orderBtn = new Guna.UI2.WinForms.Guna2Button();
            this.reportsBtn = new Guna.UI2.WinForms.Guna2Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.flowPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // customersBtn
            // 
            this.customersBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customersBtn.BorderColor = System.Drawing.Color.White;
            this.customersBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.customersBtn.BorderThickness = 1;
            this.customersBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.customersBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.customersBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.customersBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.customersBtn.FillColor = System.Drawing.Color.Transparent;
            this.customersBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.customersBtn.ForeColor = System.Drawing.Color.White;
            this.customersBtn.Image = global::FinalProject.Properties.Resources.customers;
            this.customersBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.customersBtn.ImageSize = new System.Drawing.Size(30, 30);
            this.customersBtn.Location = new System.Drawing.Point(3, 147);
            this.customersBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customersBtn.Name = "customersBtn";
            this.customersBtn.Size = new System.Drawing.Size(238, 29);
            this.customersBtn.TabIndex = 4;
            this.customersBtn.Text = "Customers";
            this.customersBtn.Click += new System.EventHandler(this.customersBtn_Click);
            // 
            // flowPanel
            // 
            this.flowPanel.AutoSize = true;
            this.flowPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowPanel.Controls.Add(this.button3);
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(244, 63);
            this.flowPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(751, 416);
            this.flowPanel.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(57, 365);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 46);
            this.button3.TabIndex = 20;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.homeBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.supplierBtn, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.customersBtn, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.orderBtn, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.reportsBtn, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 63);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.19192F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.080807F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 416);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // homeBtn
            // 
            this.homeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeBtn.BorderColor = System.Drawing.Color.White;
            this.homeBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.homeBtn.BorderThickness = 1;
            this.homeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.homeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.homeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.homeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.homeBtn.FillColor = System.Drawing.Color.Transparent;
            this.homeBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.homeBtn.ForeColor = System.Drawing.Color.White;
            this.homeBtn.Image = global::FinalProject.Properties.Resources.icons8_home_48;
            this.homeBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.homeBtn.ImageSize = new System.Drawing.Size(30, 30);
            this.homeBtn.Location = new System.Drawing.Point(3, 81);
            this.homeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(238, 29);
            this.homeBtn.TabIndex = 2;
            this.homeBtn.Text = "Home";
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // supplierBtn
            // 
            this.supplierBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierBtn.BorderColor = System.Drawing.Color.White;
            this.supplierBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.supplierBtn.BorderThickness = 1;
            this.supplierBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.supplierBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.supplierBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.supplierBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.supplierBtn.FillColor = System.Drawing.Color.Transparent;
            this.supplierBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.supplierBtn.ForeColor = System.Drawing.Color.White;
            this.supplierBtn.Image = global::FinalProject.Properties.Resources.suplier;
            this.supplierBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.supplierBtn.ImageSize = new System.Drawing.Size(30, 30);
            this.supplierBtn.Location = new System.Drawing.Point(3, 180);
            this.supplierBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.supplierBtn.Name = "supplierBtn";
            this.supplierBtn.Size = new System.Drawing.Size(238, 29);
            this.supplierBtn.TabIndex = 4;
            this.supplierBtn.Text = "Suppliers";
            this.supplierBtn.Click += new System.EventHandler(this.supplierBtn_Click);
            // 
            // orderBtn
            // 
            this.orderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderBtn.BorderColor = System.Drawing.Color.White;
            this.orderBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.orderBtn.BorderThickness = 1;
            this.orderBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.orderBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.orderBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.orderBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.orderBtn.FillColor = System.Drawing.Color.Transparent;
            this.orderBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.orderBtn.ForeColor = System.Drawing.Color.White;
            this.orderBtn.Image = global::FinalProject.Properties.Resources.order;
            this.orderBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.orderBtn.ImageSize = new System.Drawing.Size(30, 30);
            this.orderBtn.Location = new System.Drawing.Point(3, 114);
            this.orderBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(238, 29);
            this.orderBtn.TabIndex = 4;
            this.orderBtn.Text = "Place Order";
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // reportsBtn
            // 
            this.reportsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportsBtn.BorderColor = System.Drawing.Color.White;
            this.reportsBtn.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.reportsBtn.BorderThickness = 1;
            this.reportsBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.reportsBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.reportsBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.reportsBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.reportsBtn.FillColor = System.Drawing.Color.Transparent;
            this.reportsBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.reportsBtn.ForeColor = System.Drawing.Color.White;
            this.reportsBtn.Image = global::FinalProject.Properties.Resources.products;
            this.reportsBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.reportsBtn.ImageSize = new System.Drawing.Size(30, 30);
            this.reportsBtn.Location = new System.Drawing.Point(3, 213);
            this.reportsBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Size = new System.Drawing.Size(238, 29);
            this.reportsBtn.TabIndex = 5;
            this.reportsBtn.Text = "Purchase";
            this.reportsBtn.Click += new System.EventHandler(this.reportsBtn_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(839, 63);
            this.label6.TabIndex = 12;
            this.label6.Text = "General Store Management System";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.guna2Button1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(995, 63);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BorderColor = System.Drawing.Color.White;
            this.guna2Button1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = global::FinalProject.Properties.Resources.icons8_logout_64;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button1.Location = new System.Drawing.Point(848, 2);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(144, 59);
            this.guna2Button1.TabIndex = 6;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // EmployeeDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 479);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EmployeeDashBoard";
            this.Text = "EmployeeDashBoard";
            this.flowPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button customersBtn;
        private System.Windows.Forms.Panel flowPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button homeBtn;
        private Guna.UI2.WinForms.Guna2Button reportsBtn;
        private Guna.UI2.WinForms.Guna2Button orderBtn;
        private Guna.UI2.WinForms.Guna2Button supplierBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}