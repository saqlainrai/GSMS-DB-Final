﻿using FinalProject.UI_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Main : Form
    {
        public Form activeForm = null;
        Color defaultButtonColor = Color.FromArgb(33, 11, 97); // Example default color
        Color activeButtonColor = Color.FromArgb(75, 8, 138); // Example active color
        public Main()
        {
            InitializeComponent();
            
        }
        public void OpenChildForm(Form childForm)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            flowPanel.Controls.Add(childForm);
            this.Tag = childForm;
            childForm.Tag = this;
            childForm.BringToFront();
            childForm.Show();
            ResetButtonColors();
        }
        private void ResetButtonColors()
        {
            homeBtn.BackColor = defaultButtonColor;
            credentialsBtn.BackColor = defaultButtonColor;
            customersBtn.BackColor = defaultButtonColor;
            employeesBtn.BackColor = defaultButtonColor;
            supplierBtn.BackColor = defaultButtonColor;
            productsBtn.BackColor = defaultButtonColor;
            categoriesBtn.BackColor = defaultButtonColor;
            attendenceBtn.BackColor = defaultButtonColor;
            discountsBtn.BackColor = defaultButtonColor;
            reportsBtn.BackColor = defaultButtonColor;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            homeBtn.BackColor = activeButtonColor;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void flowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void credentialsBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new credentials());
            credentialsBtn.BackColor = activeButtonColor;
        }

        private void customersBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new customers());
            customersBtn.BackColor = activeButtonColor;
        }

        private void employeesBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new employees());
            employeesBtn.BackColor = activeButtonColor;
        }

        private void supplierBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new supplier());
            supplierBtn.BackColor = activeButtonColor;  
        }

        private void productsBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new products());
            productsBtn.BackColor = activeButtonColor;  
        }

        private void categoriesBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new categories());
            categoriesBtn.BackColor = activeButtonColor;    
        }

        private void attendenceBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Attendence());
            attendenceBtn.BackColor = activeButtonColor;
        }

        private void discountsBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Discounts());
            discountsBtn.BackColor = activeButtonColor; 
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reports());
            reportsBtn.BackColor = activeButtonColor;   
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            activeForm?.Close();
            homeBtn.BackColor = activeButtonColor;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {



            // Show a message box with Yes and No buttons
            DialogResult result = MessageBox.Show("Are you sure you want to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // Close the current form
                this.Close();
            }
            else
            {
                // Do nothing or handle the case when the user selects No
            }
        }


        private void flowPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}