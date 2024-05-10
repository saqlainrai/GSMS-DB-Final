using FinalProject.BL;
using FinalProject.DL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using FinalProject.reports;
using System.Data.SqlClient;
namespace FinalProject.UI_Forms
{
    public partial class Reports : Form
    {
        DataTable dt;
        string fileName;
        string title;
        public Reports()
        {
            InitializeComponent();

        }

        private void reportComboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportComboBx.SelectedIndex == 0)
            {
                
                dt = PdfReports.Attendence();
                
            }
            else if (reportComboBx.SelectedIndex == 1)
            {
                dt = PdfReports.GetExpiry();
                
            }
            else if (reportComboBx.SelectedIndex == 2)
            {
                dt = PdfReports.OrderHistory();
                
            }
            else if (reportComboBx.SelectedIndex == 3)
            {
                dt = PdfReports.GetEmployeePerformane();
               
            }
            reportDG.DataSource = dt;
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            report1 form1 = new report1();
            form1.Show();
            if (reportComboBx.SelectedIndex == 0)
            {

                CrystalReport1 crystalReport1 = new CrystalReport1();
                crystalReport1.SetDataSource(dt); // Use dt directly as the data source
                form1.crystalReportViewer1.ReportSource = null; // Clear existing report source
                form1.crystalReportViewer1.ReportSource = crystalReport1; // Set the new report source

                form1.crystalReportViewer1.Refresh();


            }
            else if (reportComboBx.SelectedIndex == 1)
            {
                CrystalReport4 crystal4 = new CrystalReport4();
                crystal4.SetDataSource(dt); // Use dt directly as the data source
                form1.crystalReportViewer1.ReportSource = null; // Clear existing report source
                form1.crystalReportViewer1.ReportSource = crystal4; // Set the new report source

                form1.crystalReportViewer1.Refresh();


            }
            else if (reportComboBx.SelectedIndex == 2)
            {
                CrystalReport5 crystal5 = new CrystalReport5();
                crystal5.SetDataSource(dt); // Use dt directly as the data source
                form1.crystalReportViewer1.ReportSource = null; // Clear existing report source
                form1.crystalReportViewer1.ReportSource = crystal5; // Set the new report source

                form1.crystalReportViewer1.Refresh();

            }
            // Assuming dt has been assigned based on the selected report type
            



        }
    }
}
