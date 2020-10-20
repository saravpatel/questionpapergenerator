using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity.Core;
namespace QPG_AI
{
   
    public partial class sign_up : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\QPG_Database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int id = 0;
        ErrorProvider er1 = new ErrorProvider();
        public sign_up()
        {
            InitializeComponent();
            bind();
            WindowState = FormWindowState.Maximized;
        
            lbl_password.Font = new Font("Georgia", 13);
            lbl_confirm_password.Font = new Font("Georgia", 13);
            lbl_dob.Font = new Font("Georgia", 13);
            lbl_gender.Font = new Font("Georgia", 13);
            lbl_insti_name.Font = new Font("Georgia", 13);
            lbl_user_name.Font = new Font("Georgia", 13);

            Font fnt = new Font(txt_confirm_password.Font.FontFamily, 12.0F);//Edit your size asper your requirement. it's float value
            txt_confirm_password.Font = fnt;

            Font fnt1 = new Font(txt_dob.Font.FontFamily, 12.0F);//Edit your size asper your requirement. it's float value
            txt_dob.Font = fnt1;

            Font fnt2 = new Font(txt_insti_name.Font.FontFamily, 12.0F);//Edit your size asper your requirement. it's float value
            txt_insti_name.Font = fnt2;

            Font fnt3 = new Font(txt_password.Font.FontFamily, 12.0F);//Edit your size asper your requirement. it's float value
            txt_password.Font = fnt3;

            Font fnt4 = new Font(txt_user_name.Font.FontFamily, 12.0F);//Edit your size asper your requirement. it's float value
            txt_user_name.Font = fnt4;
        }

        private void btn_sign_in_Click(object sender, EventArgs e)
        {            
            string gen="";
            if(rdo_male.Checked==true)
            {
                gen="Male";
            }
            else
            {
                gen="Female";
            }
            //MessageBox.Show("Record insert successfully.");
            if (txt_user_name.Text.Trim() != "" && txt_confirm_password.Text.Trim() != "" && txt_password.Text.Trim() != "" && txt_insti_name.Text.Trim() != "" && txt_dob.Value.ToString() != "")
            {
                if (txt_password.Text.Trim() != txt_confirm_password.Text.Trim())
                {
                    MessageBox.Show("confirm password not matching with new passsword");
                    txt_confirm_password.Focus();
                }
                else
                {

                    cmd = new SqlCommand("insert into user_registration(user_name,user_gender,user_dob,insti_name,user_password) values(@name,@gender,@dob,@insti,@password)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", txt_user_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", gen);
                    cmd.Parameters.AddWithValue("@dob", txt_dob.Value);
                    cmd.Parameters.AddWithValue("@insti", txt_insti_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txt_password.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record insert successfully.");
                    con.Close();
                    bind();
                    clear();

                    this.Hide();
                    sign_in s1 = new sign_in();
                    s1.Show();
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details !");
            }
         
          
        }
        public void clear()
        {
            txt_user_name.Text = "";
            txt_password.Text = "";
            txt_insti_name.Text = "";
            txt_confirm_password.Text = "";
            if (rdo_male.Checked||rdo_female.Checked)
            {
                rdo_male.Checked = false;
                rdo_female.Checked = false;
            }
        }

        public void bind()
        {

            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from user_registration", con);
            adapt.Fill(dt);
          
            con.Close();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Hide();
            QPG q1 = new QPG();
            q1.Show();
        }
    }
}
