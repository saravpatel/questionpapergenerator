using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace QPG_AI
{
    public partial class sign_in : Form
    {
        QPG q1 = new QPG();

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\QPG_Database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public sign_in()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            lbl_username.Font = new Font("Georgia", 13);           
            lbl_password.Font = new Font("Georgia", 13);
            Font fnt = new Font(txt_username.Font.FontFamily, 12.0F);//Edit your size asper your requirement. it's float value
            txt_username.Font = fnt;

            Font fnt1 = new Font(txt_password.Font.FontFamily, 12.0F);//Edit your size asper your requirement. it's float value
            txt_password.Font = fnt1;
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Hide();
           
            q1.Show();
        }

        private void btn_sign_in_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_username.Text.Trim() != "" && txt_password.Text.Trim() != "")
                {

                    DataTable dt = new DataTable();
                    cmd = new SqlCommand("select user_name , user_password from user_registration where user_name=@user and user_password=@password", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@user", txt_username.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txt_password.Text.Trim());
                    adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    con.Close();
                    int count = ds.Tables[0].Rows.Count;
                    if (count == 1)
                    {

                        MessageBox.Show("Welcome " + txt_username.Text.Trim());
                        Login_info.user_name = txt_username.Text.Trim();
                        this.Hide();
                        subject s1 = new subject();
                        s1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name Or Password !! ");
                    }
                }
                else
                {
                    MessageBox.Show("Please Provide Login Details");
                }

            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
