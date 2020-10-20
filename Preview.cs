using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
namespace QPG_AI
{
    public partial class Preview : Form
    {
      

        public Preview()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
            PaperPreview.src = @"Z:\Preview_Paper.pdf";

            //PaperPreview.Open(@"Z:\a.pdf");
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Hide();
            subject s1 = new subject();
            s1.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // When user clicks button, show the dialog.
                SFD_Paper.ShowDialog();

                //SFD_Paper.InitialDirectory = @"Z:\";
                //SFD_Paper.Title = "Save text Files";
                //SFD_Paper.CheckFileExists = true;
                //SFD_Paper.CheckPathExists = true;
                //SFD_Paper.FilterIndex = 2;
                //SFD_Paper.RestoreDirectory = true;

                //if (SFD_Paper.ShowDialog() == DialogResult.OK)
                //{
                ////    textBox1.Text = saveFileDialog1.FileName;
                //}
            }
            catch (Exception err)
            {
                MessageBox.Show("Error : : " + err.ToString());
                throw;
            }
        }

        private void SFD_Paper_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
              
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
