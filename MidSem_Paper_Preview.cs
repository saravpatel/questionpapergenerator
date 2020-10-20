using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QPG_AI
{
    public partial class MidSem_Paper_Preview : Form
    {
        public MidSem_Paper_Preview()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            mid_paper_preview.src = @"Z:\MidSem.pdf";
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            this.Hide();
            Set_MidsemExam_Paper smp = new Set_MidsemExam_Paper();
            smp.Show();
        }

       
    }
}
