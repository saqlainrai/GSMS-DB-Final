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
                


                dt = PdfReports.GetTopCustomers();
                fileName = "TopCustomers";
                title = "Top Customer";
            }
            else if (reportComboBx.SelectedIndex == 1)
            {
                dt = PdfReports.GetTopSaledProducts
();
                fileName = "TopSale";
                title = "TopSale";
            }
            else if (reportComboBx.SelectedIndex == 2)
            {
                dt = PdfReports.GetLowInStockProducts();
                fileName = "LowInStock";
                title = "LowInStock";
            }
            else if (reportComboBx.SelectedIndex == 3)
            {
                dt = PdfReports.GetEmployeePerformane();
                fileName = "EmployeePerformance";
                title = "EmployeePerformance";
            }
            reportDG.DataSource = dt;
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            ReportGenerator.GeneratePDF(dt, $"../../{fileName}.pdf", title);
            MessageBox.Show($"Successfully Created the Report in ../../{fileName}.pdf");
        }
    }
}
