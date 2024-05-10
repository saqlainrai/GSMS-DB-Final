using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FinalProject.BL
{
    internal class ReportGenerator
    {
        public static void GeneratePDF(DataTable dataTable, string filePath, string heading)
        {
            Document document = new Document();

            try
            {
                // Add automatic numbering if the file already exists
                string originalFilePath = filePath;
                int fileCount = 1;
                while (File.Exists(filePath))
                {
                    filePath = Path.Combine(
                        Path.GetDirectoryName(originalFilePath),
                        Path.GetFileNameWithoutExtension(originalFilePath) + $" ({fileCount++})" + Path.GetExtension(originalFilePath)
                    );
                }

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Add heading
                iTextSharp.text.Font headingFont = FontFactory.GetFont(FontFactory.HELVETICA, 24, BaseColor.BLACK);
                Paragraph headingParagraph = new Paragraph(heading, headingFont);
                headingParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(headingParagraph);
                document.Add(new Paragraph("\n")); // Add some space after heading

                // Create table
                PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

                // Add headers
                foreach (DataColumn column in dataTable.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }

                // Add rows
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (object item in row.ItemArray)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(item.ToString()));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.AddCell(cell);
                    }
                }

                // Add table to document
                document.Add(pdfTable);
            }
            catch (DocumentException dex)
            {
                // Handle document exception
                MessageBox.Show(dex.Message);
            }
            catch (IOException ioex)
            {
                // Handle IO exception
                MessageBox.Show(ioex.Message);
            }
            finally
            {
                // Close the document
                document.Close();
            }
        }
    
}
}
