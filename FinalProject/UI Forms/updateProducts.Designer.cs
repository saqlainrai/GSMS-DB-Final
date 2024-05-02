namespace FinalProject.UI_Forms
{
    partial class updateProducts
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
            this.manageStudentBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(269, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "this is update products";
            // 
            // manageStudentBtn
            // 
            this.manageStudentBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            this.manageStudentBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manageStudentBtn.FlatAppearance.BorderSize = 0;
            this.manageStudentBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.manageStudentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.manageStudentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageStudentBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageStudentBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.manageStudentBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageStudentBtn.Location = new System.Drawing.Point(363, 251);
            this.manageStudentBtn.Name = "manageStudentBtn";
            this.manageStudentBtn.Size = new System.Drawing.Size(239, 35);
            this.manageStudentBtn.TabIndex = 18;
            this.manageStudentBtn.Text = "Manage Students";
            this.manageStudentBtn.UseVisualStyleBackColor = false;
            // 
            // updateProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 537);
            this.Controls.Add(this.manageStudentBtn);
            this.Controls.Add(this.label1);
            this.Name = "updateProducts";
            this.Text = "updateProducts";
            this.Load += new System.EventHandler(this.updateProducts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button manageStudentBtn;
    }
}