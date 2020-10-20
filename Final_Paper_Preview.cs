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
    public partial class Final_Paper_Preview : Form
    {
        public Final_Paper_Preview()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            FinalPreview.src = @"Z:\Final.pdf";
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            this.Hide();
            Set_FinalExam_Paper s1 = new Set_FinalExam_Paper();
            s1.Show();
        }
    }
}
