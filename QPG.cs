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
    public partial class QPG : Form
    {
        public QPG()
        {
            InitializeComponent();
            //FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            
        }

        private void btn_sign_up_Click(object sender, EventArgs e)
        {
            this.Hide();
            sign_up s1=new sign_up();
            s1.Show();
        }

        private void btn_sign_in_Click(object sender, EventArgs e)
        {
            this.Hide();
            sign_in s2 = new sign_in();
            s2.Show();
        }

        private void QPG_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
