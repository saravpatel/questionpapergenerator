using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data.SqlClient;
namespace QPG_AI
{
    public partial class subject : Form
    {
        string connetionString = null;
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adpt;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\QPG_Database.mdf;Integrated Security=True");
        public subject()
        {
          
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            dtExamTime.Format = DateTimePickerFormat.Time;
            dtExamTime.ShowUpDown = true;

            lblusername.Text = "Welcome " + Login_info.user_name;

            cbExamName.Text = "Select Exam Type";
            cbExamName.Items.Add("Mid-sem Exam");
            cbExamName.Items.Add("Final Exam");

            lblExamName.Font = new System.Drawing.Font("Georgia", 13);
            lblusername.Font = new System.Drawing.Font("Georgia", 13);
            lblExamDate.Font = new System.Drawing.Font("Georgia", 13);
            lblSelectSubject.Font = new System.Drawing.Font("Georgia", 13);


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string sql = null;
            connetionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\QPG_Database.mdf;Integrated Security=True";
            sql = "select Paper_Name from Paper_type";
            connection = new SqlConnection(connetionString);
            try
            {

                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                cbSelectSubject.DataSource = ds.Tables[0];
                cbSelectSubject.ValueMember = "Paper_Name";
                cbSelectSubject.DisplayMember = "Paper_Id";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.ToString());
                throw;
            }

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            QPG q1 = new QPG();
            q1.Show();
            lblusername.Text = string.Empty;
        }

        //private void btnPreview_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (cbExamName.SelectedIndex == -1)
        //        {
        //            MessageBox.Show("Plz !! Select Exam Name First ", "Error");
        //        }
        //        else if (cbSelectSubject.SelectedIndex == -1)
        //        {
        //            MessageBox.Show("Plz !! Select Exam Subject ", "Error");
        //        }
        //        else
        //        {
        //            if (cbExamName.Items[cbExamName.SelectedIndex].ToString() == "Mid-sem Exam")
        //            {
        //                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
        //                PdfWriter.GetInstance(document, new FileStream(@"Z:/Preview_Paper.pdf", FileMode.Create));
        //                document.Open();

        //                //int theHour =Convert.ToInt32( dtExamTime.Value.Hour);
        //                //int theMinute = Convert.ToInt32(dtExamTime.Value.Minute);
        //                //int theSecond = Convert.ToInt32(dtExamTime.Value.Second);
        //                string theDate = dtExamDate.Value.ToShortDateString();
        //                string subDate = theDate.Substring(0, 2);
        //                //font setting
        //                BaseFont bf = BaseFont.CreateFont(
        //                    BaseFont.TIMES_ROMAN,
        //                    BaseFont.CP1252,
        //                    BaseFont.EMBEDDED);
        //                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 8);

        //                PdfPTable table = new PdfPTable(3);


        //                PdfPCell cell1 = new PdfPCell(new Phrase("Msc.4." + subDate, font));
        //                cell1.Colspan = 2;
        //                cell1.Border = 0;
        //                table.AddCell(cell1);


        //                PdfPCell cell1_1 = new PdfPCell(new Phrase("ROLLNO.________", font));
        //                cell1_1.Colspan = 1;
        //                cell1_1.Border = 0;
        //                cell1_1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                table.AddCell(cell1_1);


        //                PdfPCell cell2 = new PdfPCell(new Phrase(" GUJARAT UNIVERSITY", font));
        //                cell2.Colspan = 3;
        //                cell2.Border = 0;
        //                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell2);


        //                PdfPCell cell3 = new PdfPCell(new Phrase("K.S.SCHOOL OF BUSINESS MANAGEMENT", font));
        //                cell3.Colspan = 3;
        //                cell3.Border = 0;
        //                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell3);


        //                PdfPCell cell4 = new PdfPCell(new Phrase("[FIVE YEARS FULL-TIME M.Sc INTEGRATED DEGREE COURSE]", font));
        //                cell4.Colspan = 3;
        //                cell4.Border = 0;
        //                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell4);


        //                PdfPCell cell5 = new PdfPCell(new Phrase("MID-SEM EXAM OF SEVENTH SEMESTER OF FOURTH YEAR M.Sc.(CA&IT)", font));
        //                cell5.Colspan = 3;
        //                cell5.Border = 0;
        //                cell5.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell5);


        //                string monthName = dtExamDate.Value.ToString("MMMM");
        //                string YearName = dtExamDate.Value.Year.ToString();
        //                PdfPCell cell6 = new PdfPCell(new Phrase(monthName + ", " + YearName, font));
        //                cell6.Colspan = 3;
        //                cell6.Border = 0;
        //                cell6.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell6);

        //                string subjectName = cbSelectSubject.SelectedValue.ToString();
        //                PdfPCell cell7 = new PdfPCell(new Phrase("SUBJECT: - " + subjectName, font));
        //                cell7.Colspan = 3;
        //                cell7.Border = 0;
        //                cell7.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell7);

        //                PdfPCell cell8 = new PdfPCell(new Phrase("DATE: - " + theDate, font));
        //                cell8.Colspan = 0;
        //                cell8.BorderWidthLeft = 0;
        //                cell8.BorderWidthRight = 0;
        //                cell8.BorderWidthTop = 0;
        //                //cell8.BorderWidthBottom = 1;
        //                cell8.HorizontalAlignment = Element.ALIGN_LEFT;
        //                table.AddCell(cell8);


        //                int credit;
        //                try
        //                {
        //                    DataTable dt = new DataTable();
        //                    command = new SqlCommand("select * from Paper_type where Paper_Name=@subjectName", con);
        //                    con.Open();
        //                    command.Parameters.AddWithValue("@subjectName", subjectName);
        //                    adpt = new SqlDataAdapter(command);
        //                    DataSet ds = new DataSet();
        //                    adpt.Fill(ds);
        //                    credit = Convert.ToInt32(ds.Tables[0].Rows[0]["Paper_Credit"]);
        //                    con.Close();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Error::" + ex.ToString());
        //                    throw;
        //                }
        //                string STime, ETime;
        //                if (credit == 3)
        //                {
        //                     STime = dtExamTime.Value.ToString("hh:mm tt");
        //                    //int ETime = Convert.ToInt32(dtExamTime.Value.Hour);

        //                  ETime = ( dtExamTime.Value.AddHours(2).ToString("hh:mm tt"));

        //                }
        //                else
        //                {
        //                     STime = dtExamTime.Value.ToString("hh:mm tt");
        //                    //int ETime = Convert.ToInt32(dtExamTime.Value.Hour);

        //                     ETime = (dtExamTime.Value.AddHours(1).ToString("hh:mm tt"));
                           
        //                }

        //                PdfPCell cell9 = new PdfPCell(new Phrase("TIME: - "+STime+" TO "+ ETime, font));
        //                cell9.Colspan = 0;
        //                cell9.BorderWidthLeft = 0;
        //                cell9.BorderWidthRight = 0;
        //                cell9.BorderWidthTop = 0;
        //                //cell9.BorderWidthBottom = 1;
        //                //cell8.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell9);

        //                string TotalMarks;
        //                try
        //                {
        //                    DataTable dt = new DataTable();
        //                    command = new SqlCommand("select * from Paper_type where Paper_Name=@subjectName", con);
        //                    con.Open();
        //                    command.Parameters.AddWithValue("@subjectName", subjectName);
        //                    adpt = new SqlDataAdapter(command);
        //                    DataSet ds = new DataSet();
        //                    adpt.Fill(ds);
        //                    credit = Convert.ToInt32(ds.Tables[0].Rows[0]["Paper_Credit"]);
        //                    con.Close();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Error::" + ex.ToString());
        //                    throw;
        //                }
        //                if (credit == 3)
        //                {
        //                    TotalMarks = "50";
        //                }
        //                else
        //                {
        //                    TotalMarks = "30";
        //                }
        //                PdfPCell cell10 = new PdfPCell(new Phrase("MARKS: " + TotalMarks, font));
        //                cell10.Colspan = 0;
        //                cell10.BorderWidthLeft = 0;
        //                cell10.BorderWidthRight = 0;
        //                cell10.BorderWidthTop = 0;
        //                //cell10.BorderWidthBottom = 1;
        //                //cell8.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell10);


        //                document.Add(table);
        //                document.Close();
        //                this.Hide();
        //                Preview p1 = new Preview();
        //                p1.Show();
        //            }
        //            else if (cbExamName.Items[cbExamName.SelectedIndex].ToString() == "Final Exam")
        //            {
        //                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
        //                PdfWriter.GetInstance(document, new FileStream(@"Z:\Final.pdf", FileMode.Create));
        //                document.Open();

        //                //int theHour =Convert.ToInt32( dtExamTime.Value.Hour);
        //                //int theMinute = Convert.ToInt32(dtExamTime.Value.Minute);
        //                //int theSecond = Convert.ToInt32(dtExamTime.Value.Second);
        //                string theDate = dtExamDate.Value.ToShortDateString();
        //                string subDate = theDate.Substring(0, 2);
        //                //font setting
        //                BaseFont bf = BaseFont.CreateFont(
        //                    BaseFont.TIMES_ROMAN,
        //                    BaseFont.CP1252,
        //                    BaseFont.EMBEDDED);
        //                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 8);

        //                PdfPTable table = new PdfPTable(3);
                        

        //                PdfPCell cell1_1 = new PdfPCell(new Phrase("Seat No.:________", font));
        //                cell1_1.Colspan = 3;
        //                cell1_1.Border = 0;
        //                cell1_1.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                table.AddCell(cell1_1);

        //                //subject code goes here  
        //                string subjectName = cbSelectSubject.SelectedValue.ToString();
        //                try
        //                {
        //                    DataTable dt = new DataTable();
        //                    command = new SqlCommand("select Paper_Code from Paper_type where Paper_Name=@subjectName", con);
        //                    con.Open();
        //                    command.Parameters.AddWithValue("@subjectName", subjectName);
        //                    adpt = new SqlDataAdapter(command);
        //                    DataSet ds = new DataSet();
        //                    adpt.Fill(ds);
        //                    string Sub_Code = ds.Tables[0].Rows[0]["Paper_Code"].ToString();
        //                    con.Close();
        //                    PdfPCell cell_2 = new PdfPCell(new Phrase(Sub_Code, font));
        //                    cell_2.Colspan = 3;
        //                    cell_2.Border = 0;
        //                    cell_2.HorizontalAlignment = Element.ALIGN_CENTER;
        //                    table.AddCell(cell_2);
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Error : "+ex);
        //                    throw;
        //                }


        //                string monthName = dtExamDate.Value.ToString("MMMM");
        //                string YearName = dtExamDate.Value.Year.ToString();
        //                PdfPCell cell2 = new PdfPCell(new Phrase(monthName + "-" + YearName, font));
        //                cell2.Colspan = 3;
        //                cell2.Border = 0;
        //                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell2);

        //                PdfPCell cell3 = new PdfPCell(new Phrase("4th Year MSC(CA & IT)", font));
        //                cell3.Colspan = 3;
        //                cell3.Border = 0;
        //                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell3);

        //                subjectName = cbSelectSubject.SelectedValue.ToString();
        //                PdfPCell cell4 = new PdfPCell(new Phrase(subjectName, font));
        //                cell4.Colspan = 3;
        //                cell4.Border = 0;
        //                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell4);

        //                int credit;
        //                try
        //                {
        //                    DataTable dt = new DataTable();
        //                    command = new SqlCommand("select * from Paper_type where Paper_Name=@subjectName", con);
        //                    con.Open();
        //                    command.Parameters.AddWithValue("@subjectName", subjectName);
        //                    adpt = new SqlDataAdapter(command);
        //                    DataSet ds = new DataSet();
        //                    adpt.Fill(ds);
        //                    credit = Convert.ToInt32(ds.Tables[0].Rows[0]["Paper_Credit"]);
        //                    con.Close();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Error::" + ex.ToString());
        //                    throw;
        //                }
        //                string STime, ETime;
        //                if (credit == 3)
        //                {
        //                    STime = dtExamTime.Value.ToString("hh:mm tt");
        //                    //int ETime = Convert.ToInt32(dtExamTime.Value.Hour);

        //                    ETime = (dtExamTime.Value.AddHours(3).ToString("hh:mm tt"));

        //                }
        //                else
        //                {
        //                    STime = dtExamTime.Value.ToString("hh:mm tt");
        //                    //int ETime = Convert.ToInt32(dtExamTime.Value.Hour);

        //                    ETime = (dtExamTime.Value.AddHours(2).ToString("hh:mm tt"));

        //                }

        //                PdfPCell cell5 = new PdfPCell(new Phrase("TIME: - " + STime + " TO " + ETime, font));
        //                cell5.Colspan = 2;
        //                cell5.Border = 0;
        //                //cell5.BorderWidthLeft = 0;
        //                //cell5.BorderWidthRight = 0;
        //                //cell5.BorderWidthTop = 0;
        //                //cell9.BorderWidthBottom = 1;
        //                //cell8.HorizontalAlignment = Element.ALIGN_CENTER;
        //                table.AddCell(cell5);

        //                string TotalMarks;

        //                try
        //                {
        //                    DataTable dt = new DataTable();
        //                    command = new SqlCommand("select * from Paper_type where Paper_Name=@subjectName", con);
        //                    con.Open();
        //                    command.Parameters.AddWithValue("@subjectName", subjectName);
        //                    adpt = new SqlDataAdapter(command);
        //                    DataSet ds = new DataSet();
        //                    adpt.Fill(ds);
        //                    credit = Convert.ToInt32(ds.Tables[0].Rows[0]["Paper_Credit"]);
        //                    con.Close();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Error::" + ex.ToString());
        //                    throw;
        //                }
        //                if (credit == 3)
        //                {
        //                    TotalMarks = "100";
        //                }
        //                else
        //                {
        //                    TotalMarks = "50";
        //                }
        //                PdfPCell cell6 = new PdfPCell(new Phrase("[Max. MARKS: " + TotalMarks+"]", font));
        //                cell6.Colspan = 1;
        //                cell6.Border = 0;
        //                //cell6.BorderWidthLeft = 0;
        //                //cell6.BorderWidthRight = 0;
        //                //cell6.BorderWidthTop = 0;
        //                //cell10.BorderWidthBottom = 1;
        //                cell6.HorizontalAlignment = Element.ALIGN_RIGHT;
        //                table.AddCell(cell6);


        //                document.Add(table);
        //                document.Close();
        //                this.Hide();
        //                Final_Paper_Preview p2 = new Final_Paper_Preview();
        //                p2.Show();
        //            }
        //        }


        //        //Paragraph p = new Paragraph("Hello");
        //        //document.Add(p);



        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show("" + err);
        //        throw;
        //    }
        //}

        private void gbQuestionPaper_Enter(object sender, EventArgs e)
        {

        }

        private void subject_Load(object sender, EventArgs e)
        {

        }

        private void btnSetPaper_Click(object sender, EventArgs e)
        {
            if (cbExamName.SelectedIndex == -1)
            {
                MessageBox.Show("Plz !! Select Exam Name First ", "Error");
            }
            else if (cbSelectSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Plz !! Select Exam Subject ", "Error");
            }            
           else if (cbExamName.Items[cbExamName.SelectedIndex].ToString() == "Final Exam")
            {
                string subjectName = cbSelectSubject.SelectedValue.ToString();
                Login_info.SelectedSubject = subjectName;
                Login_info.FinalExamDate=dtExamDate.Value.ToShortDateString();
                Login_info.FinalExamMonth= dtExamDate.Value.ToString("MMMM");
                Login_info.FinalExamYear = dtExamDate.Value.Year.ToString();

                //subject credit decision goes here
                int credit,TotalMarks;
                try
                {
                    DataTable dt = new DataTable();
                    command = new SqlCommand("select * from Paper_type where Paper_Name=@subjectName", con);
                    con.Open();
                    command.Parameters.AddWithValue("@subjectName", subjectName);
                    adpt = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    credit = Convert.ToInt32(ds.Tables[0].Rows[0]["Paper_Credit"]);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error::" + ex.ToString());
                    throw;
                }
                if(credit==3)
                {
                    Login_info.FinalExamStart = dtExamTime.Value.ToString("hh:mm tt");
                    Login_info.FinalExamEnd = (dtExamTime.Value.AddHours(3).ToString("hh:mm tt"));
                    TotalMarks = 100;
                    Login_info.Total_Marks = TotalMarks;
                }
                else
                {
                    Login_info.FinalExamStart = dtExamTime.Value.ToString("hh:mm tt");
                    Login_info.FinalExamEnd = (dtExamTime.Value.AddHours(2).ToString("hh:mm tt"));
                    TotalMarks = 50;
                    Login_info.Total_Marks = TotalMarks;
                }

                this.Hide();
                Set_FinalExam_Paper sf1 = new Set_FinalExam_Paper();
                sf1.Show();
            }
            else if (cbExamName.Items[cbExamName.SelectedIndex].ToString() == "Mid-sem Exam")
            {
                string subjectName = cbSelectSubject.SelectedValue.ToString();
                Login_info.SelectedSubject = subjectName;
                Login_info.MidExamDate = dtExamDate.Value.ToShortDateString();
                Login_info.MidExamMonth = dtExamDate.Value.ToString("MMMM");
                Login_info.MidExamYear = dtExamDate.Value.Year.ToString();
                string theDate = dtExamDate.Value.ToShortDateString();
                 string subDate = theDate.Substring(0, 2);
                Login_info.MidSemDateOnly = subDate;
              
                int credit, TotalMarks;

                try
                {
                    DataTable dt = new DataTable();
                    command = new SqlCommand("select * from Paper_type where Paper_Name=@subjectName", con);
                    con.Open();
                    command.Parameters.AddWithValue("@subjectName", subjectName);
                    adpt = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    credit = Convert.ToInt32(ds.Tables[0].Rows[0]["Paper_Credit"]);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error::" + ex.ToString());
                    throw;
                }
                if (credit == 3)
                {
                    Login_info.MidExamStart = dtExamTime.Value.ToString("hh:mm tt");
                    Login_info.MidExamEnd = dtExamTime.Value.AddHours(3).ToString("hh:mm tt");
                    TotalMarks = 50;
                    Login_info.Total_Marks = TotalMarks;
                }
                else
                {
                    Login_info.MidExamStart = dtExamTime.Value.ToString("hh:mm tt");
                    Login_info.MidExamEnd = dtExamTime.Value.AddHours(2).ToString("hh:mm tt");
                    TotalMarks = 30;
                    Login_info.Total_Marks = TotalMarks;
                }
                this.Hide();
                Set_MidsemExam_Paper sm1 = new Set_MidsemExam_Paper();
                sm1.Show();
            }
        }

      
    }
}
