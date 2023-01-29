using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patagames.Ocr;


namespace Clinical_project_
{
    public partial class ocr : Form
    {
        public ocr()
        {
            InitializeComponent();
        }

        private void ocr_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Users\tarek\source\repos\Clinical_project_\Clinical_project_\OCR\ocr2.jpeg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var objOcr = OcrApi.Create())
            {
                objOcr.Init(Patagames.Ocr.Enums.Languages.English);
                string plainText = objOcr.GetTextFromImage(pictureBox1.ImageLocation);
                textBox1.Text = plainText;
            }
        }
    }
}
