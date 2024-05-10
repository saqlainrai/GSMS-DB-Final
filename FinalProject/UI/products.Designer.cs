namespace FinalProject.UI_Forms
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
            this.productsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // productsPanel
            // 
            this.productsPanel.AutoSize = true;
            this.productsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.productsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsPanel.Location = new System.Drawing.Point(0, 0);
            this.productsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.productsPanel.Name = "productsPanel";
            this.productsPanel.Size = new System.Drawing.Size(959, 538);
            this.productsPanel.TabIndex = 12;
            // 
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 538);
            this.Controls.Add(this.productsPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "products";
            this.Text = "products";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel productsPanel;
    }
}