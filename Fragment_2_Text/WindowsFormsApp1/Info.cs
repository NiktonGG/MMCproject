using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;

namespace WindowsFormsApp1
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            textBoxMessage.Text = "";
        }
        public void AddText(string text, Color color)
        {
            textBoxMessage.SelectionStart = textBoxMessage.TextLength;
            textBoxMessage.SelectionLength = 0;
            textBoxMessage.SelectionColor = color;
            textBoxMessage.AppendText(text);
            textBoxMessage.SelectionColor = textBoxMessage.ForeColor;
        }

        private void Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void buttonExport_Click(object sender, System.EventArgs e)
        {
            string folderPath = @"C:\Users\DDKovalenko\Desktop\";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath + "\\";
            }
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Анализ_документа" + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                BaseFont baseFont = BaseFont.CreateFont("c:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font = new Font(baseFont);
                pdfDoc.Add(new Paragraph(new Phrase(textBoxMessage.Text, font)));
                pdfDoc.Close();
                stream.Close();
            }
            MessageBox.Show("Done");
        }
    }
}
