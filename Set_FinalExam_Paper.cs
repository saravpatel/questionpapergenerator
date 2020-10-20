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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
namespace QPG_AI
{
    public partial class Set_FinalExam_Paper : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\QPG_Database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int flag = 0, flag2 = 0, flag3 = 0, flag4 = 0, flag5 = 0;
        int flag_B = 0, flag2_B = 0, flag3_B = 0, flag4_B = 0, flag5_B = 0;
        List<RandomQuestions> GlobalList = new List<RandomQuestions>();
        public Set_FinalExam_Paper()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            pnlSection_1.Visible = false;
            pnlSection_2.Visible = false;
            pnlSection_3.Visible = false;
            pnlSection_4.Visible = false;
            pnlSection_5.Visible = false;

            btnSection_1.Visible = false;
            btnSection_2.Visible = false;
            btnSection_3.Visible = false;
            btnSection_4.Visible = false;
            btnSection_5.Visible = false;


            txtEachSectionMark.ReadOnly = true;
        }

        //random Number Alogorithm goes here
        public class Shuffler
        {
            /// <summary>Creates the shuffler with a <see cref="MersenneTwister"/> as the random number generator.</summary>

            public Shuffler()
            {
                _rng = new Random();
            }

            /// <summary>Shuffles the specified array.</summary>
            /// <typeparam name="T">The type of the array elements.</typeparam>
            /// <param name="array">The array to shuffle.</param>

            public void Shuffle<T>(IList<T> array)
            {
                for (int n = array.Count; n > 1;)
                {
                    int k = _rng.Next(n);
                    --n;
                    T temp = array[n];
                    array[n] = array[k];
                    array[k] = temp;
                }
            }

            private System.Random _rng;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTotalSection.Text) == 5)
            {
                btnSection_1.Visible = true;
                btnSection_2.Visible = true;
                btnSection_3.Visible = true;
                btnSection_4.Visible = true;
                btnSection_5.Visible = true;

                string SubName = Login_info.SelectedSubject;
                int result = 0;
                result = string.Compare(SubName, "Entrepreneurship (ES)");
                if (result==0)
                    txtEachSectionMark.Text = "10";
                else
                txtEachSectionMark.Text = "20";

                //fill Question type here for section - 1 (A)
                cbQuestionType.Text = "Select Question Type";
                cbQuestionType.Items.Add("LA");
                cbQuestionType.Items.Add("SA");
                cbQuestionType.Items.Add("VLA");
                cbQuestionType.Items.Add("BA");
                cbQuestionType.Items.Add("VSA");

                //fill Question type here for section - 1 (B)
                cbQuestionType1_B.Text = "Select Question Type";
                cbQuestionType1_B.Items.Add("LA");
                cbQuestionType1_B.Items.Add("SA");
                cbQuestionType1_B.Items.Add("VLA");
                cbQuestionType1_B.Items.Add("BA");
                cbQuestionType1_B.Items.Add("VSA");

                //fill Question type here for section - 2
                cbQuestionType2.Text = "Select Question Type";
                cbQuestionType2.Items.Add("LA");
                cbQuestionType2.Items.Add("SA");
                cbQuestionType2.Items.Add("VLA");
                cbQuestionType2.Items.Add("BA");
                cbQuestionType2.Items.Add("VSA");

                //fill Question type here for section - 2 (B)
                cbQuestionType2_B.Text = "Select Question Type";
                cbQuestionType2_B.Items.Add("LA");
                cbQuestionType2_B.Items.Add("SA");
                cbQuestionType2_B.Items.Add("VLA");
                cbQuestionType2_B.Items.Add("BA");
                cbQuestionType2_B.Items.Add("VSA");

                //fill Question type here for section - 3
                cbQuestionType3.Text = "Select Question Type";
                cbQuestionType3.Items.Add("LA");
                cbQuestionType3.Items.Add("SA");
                cbQuestionType3.Items.Add("VLA");
                cbQuestionType3.Items.Add("BA");
                cbQuestionType3.Items.Add("VSA");

                //fill Question type here for section - 3 (B)
                cbQuestionType3_B.Text = "Select Question Type";
                cbQuestionType3_B.Items.Add("LA");
                cbQuestionType3_B.Items.Add("SA");
                cbQuestionType3_B.Items.Add("VLA");
                cbQuestionType3_B.Items.Add("BA");
                cbQuestionType3_B.Items.Add("VSA");

                //fill Question type here for section - 4
                cbQuestionType4.Text = "Select Question Type";
                cbQuestionType4.Items.Add("LA");
                cbQuestionType4.Items.Add("SA");
                cbQuestionType4.Items.Add("VLA");
                cbQuestionType4.Items.Add("BA");
                cbQuestionType4.Items.Add("VSA");

                //fill Question type here for section - 4 (B)
                cbQuestionType4_B.Text = "Select Question Type";
                cbQuestionType4_B.Items.Add("LA");
                cbQuestionType4_B.Items.Add("SA");
                cbQuestionType4_B.Items.Add("VLA");
                cbQuestionType4_B.Items.Add("BA");
                cbQuestionType4_B.Items.Add("VSA");

                //fill Question type here for section - 5
                cbQuestionType5.Text = "Select Question Type";
                cbQuestionType5.Items.Add("LA");
                cbQuestionType5.Items.Add("SA");
                cbQuestionType5.Items.Add("VLA");
                cbQuestionType5.Items.Add("BA");
                cbQuestionType5.Items.Add("VSA");

                //fill Question type here for section - 5 (B)
                cbQuestionType5_B.Text = "Select Question Type";
                cbQuestionType5_B.Items.Add("LA");
                cbQuestionType5_B.Items.Add("SA");
                cbQuestionType5_B.Items.Add("VLA");
                cbQuestionType5_B.Items.Add("BA");
                cbQuestionType5_B.Items.Add("VSA");

                //fill Question Difficulty type here for section - 1 - (A)
                cbQDifficulty.Text = "Select Difficulty Level";
                cbQDifficulty.Items.Add("low");
                cbQDifficulty.Items.Add("medium");
                cbQDifficulty.Items.Add("high");

                //fill Question Difficulty type here for section - 1 - (B)
                cbQDifficulty1_B.Text = "Select Difficulty Level";
                cbQDifficulty1_B.Items.Add("low");
                cbQDifficulty1_B.Items.Add("medium");
                cbQDifficulty1_B.Items.Add("high");

                //fill Question Difficulty type here for section - 2
                cbQDifficulty2.Text = "Select Difficulty Level";
                cbQDifficulty2.Items.Add("low");
                cbQDifficulty2.Items.Add("medium");
                cbQDifficulty2.Items.Add("high");

                //fill Question Difficulty type here for section - 2 - (B)
                cbQDifficulty2_B.Text = "Select Difficulty Level";
                cbQDifficulty2_B.Items.Add("low");
                cbQDifficulty2_B.Items.Add("medium");
                cbQDifficulty2_B.Items.Add("high");

                //fill Question Difficulty type here for section - 3
                cbQDifficulty3.Text = "Select Difficulty Level";
                cbQDifficulty3.Items.Add("low");
                cbQDifficulty3.Items.Add("medium");
                cbQDifficulty3.Items.Add("high");

                //fill Question Difficulty type here for section - 3 - (B)
                cbQDifficulty3_B.Text = "Select Difficulty Level";
                cbQDifficulty3_B.Items.Add("low");
                cbQDifficulty3_B.Items.Add("medium");
                cbQDifficulty3_B.Items.Add("high");

                //fill Question Difficulty type here for section - 4
                cbQDifficulty4.Text = "Select Difficulty Level";
                cbQDifficulty4.Items.Add("low");
                cbQDifficulty4.Items.Add("medium");
                cbQDifficulty4.Items.Add("high");

                //fill Question Difficulty type here for section - 4 - (B)
                cbQDifficulty4_B.Text = "Select Difficulty Level";
                cbQDifficulty4_B.Items.Add("low");
                cbQDifficulty4_B.Items.Add("medium");
                cbQDifficulty4_B.Items.Add("high");

                //fill Question Difficulty type here for section - 5
                cbQDifficulty5.Text = "Select Difficulty Level";
                cbQDifficulty5.Items.Add("low");
                cbQDifficulty5.Items.Add("medium");
                cbQDifficulty5.Items.Add("high");

                //fill Question Difficulty type here for section - 5 - (B)
                cbQDifficulty5_B.Text = "Select Difficulty Level";
                cbQDifficulty5_B.Items.Add("low");
                cbQDifficulty5_B.Items.Add("medium");
                cbQDifficulty5_B.Items.Add("high");

            }
            else
            {
                MessageBox.Show("Sorry !!! Only 5 section are allowed");
            }
        }

        private void txtTotalSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            subject sub1 = new subject();
            sub1.Show();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                PdfWriter.GetInstance(document, new FileStream(@"Z:\Final.pdf", FileMode.Create));
                document.Open();

                string theDate = Login_info.FinalExamDate;
                string subDate = theDate.Substring(0, 2);
                //font setting
                BaseFont bf = BaseFont.CreateFont(
                    BaseFont.TIMES_ROMAN,
                    BaseFont.CP1252,
                    BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 8);

                PdfPTable table = new PdfPTable(3);


                PdfPCell cell1_1 = new PdfPCell(new Phrase("Seat No.:________", font));
                cell1_1.Colspan = 3;
                cell1_1.Border = 0;
                cell1_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell1_1);

                //subject code goes here  
                string subjectName = Login_info.SelectedSubject;
                try
                {
                    DataTable dt = new DataTable();
                    cmd = new SqlCommand("select Paper_Code from Paper_type where Paper_Name=@subjectName", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@subjectName", subjectName);
                    adapt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    string Sub_Code = ds.Tables[0].Rows[0]["Paper_Code"].ToString();
                    con.Close();
                    PdfPCell cell_2 = new PdfPCell(new Phrase(Sub_Code, font));
                    cell_2.Colspan = 3;
                    cell_2.Border = 0;
                    cell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell_2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex);
                    throw;
                }


                string monthName = Login_info.FinalExamMonth;
                string YearName = Login_info.FinalExamYear;
                PdfPCell cell2 = new PdfPCell(new Phrase(monthName + "-" + YearName, font));
                cell2.Colspan = 3;
                cell2.Border = 0;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell(new Phrase("4th Year MSC(CA & IT)", font));
                cell3.Colspan = 3;
                cell3.Border = 0;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell3);

                subjectName = Login_info.SelectedSubject;
                PdfPCell cell4 = new PdfPCell(new Phrase(subjectName, font));
                cell4.Colspan = 3;
                cell4.Border = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell4);

                string STime, ETime;
                STime = Login_info.FinalExamStart;

                ETime = Login_info.FinalExamEnd;


                PdfPCell cell5 = new PdfPCell(new Phrase("TIME: - " + STime + " TO " + ETime, font));
                cell5.Colspan = 2;
                cell5.Border = 0;
                table.AddCell(cell5);

                int TotalMarks = Login_info.Total_Marks;
                PdfPCell cell6 = new PdfPCell(new Phrase("[Max. MARKS: " + TotalMarks + "]", font));
                cell6.Colspan = 1;
                cell6.Border = 0;
                cell6.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell6);

                //blank line...
                PdfPCell Blank_cell_1 = new PdfPCell(new Phrase("\n", font));
                Blank_cell_1.Colspan = 3;
                Blank_cell_1.Border = 0;
                Blank_cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(Blank_cell_1);

                // Question of Section - 1 paper Goes here..
                if (flag == 1)
                {
                    //question header goes here for (A)
                    PdfPCell cell7 = new PdfPCell(new Phrase(txtHeader.Text, font));
                    cell7.Colspan = 2;
                    cell7.Border = 0;
                    table.AddCell(cell7);

                    //section marks goes here for (A)
                    int marks_A = Convert.ToInt32(txtEachQMark.Text) * Convert.ToInt32(txtQNo.Text);
                    PdfPCell cell8 = new PdfPCell(new Phrase(marks_A.ToString(), font));
                    cell8.Colspan = 1;
                    cell8.Border = 0;
                    cell8.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell8);

                    //questions Goes Here for (A)
                    try
                    {
                        string QDLevel = cbQDifficulty.SelectedItem.ToString();
                        string QType = cbQuestionType.SelectedItem.ToString();
                        subjectName = Login_info.SelectedSubject;
                        DataTable dt = new DataTable();
                        cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@subjectName", subjectName);
                        cmd.Parameters.AddWithValue("@QType", QType);
                        cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                        adapt = new SqlDataAdapter(cmd);
                        // DataSet ds = new DataSet();
                        //adapt.Fill(ds);
                        adapt.Fill(dt);

                        List<RandomQuestions> Qlist_A = new List<RandomQuestions>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            RandomQuestions RQ = new RandomQuestions();
                            RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                            RQ.Question = dt.Rows[i]["Question"].ToString();
                            Qlist_A.Add(RQ);
                            GlobalList.Add(RQ);
                        }
                        //Question Suffling goes here
                        Shuffler shuffler = new Shuffler();
                        shuffler.Shuffle(Qlist_A);
                        for (int i = 0; i < Convert.ToInt32(txtQNo.Text) + Convert.ToInt32(txtQoption.Text); i++)
                        {

                            PdfPCell cell9 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist_A[i].Question, font));
                            cell9.Colspan = 3;
                            cell9.Border = 0;
                            cell9.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell9);
                        }

                        con.Close();
                        // for(int i=0;i<Convert.ToInt32(txtQNo.Text)+Convert.ToInt32(txtQoption.Text);i++)
                        for (int i = 0; i < Qlist_A.Count; i++)
                            Console.WriteLine("QList - 1 : " + Qlist_A[i].Q_Id);
                        //foreach (DataRow row in dt.Rows)
                        //{
                        //    foreach(DataColumn column in dt.Columns)
                        //    {
                        //        Console.WriteLine(row[column]);
                        //        Shuffler shuffler = new Shuffler();

                        //    }
                        //}                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : ", ex.ToString());
                        throw;
                    }

                    //blank line...
                    PdfPCell Blank_cell_2_1 = new PdfPCell(new Phrase("\n", font));
                    Blank_cell_2_1.Colspan = 3;
                    Blank_cell_2_1.Border = 0;
                    Blank_cell_2_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(Blank_cell_2_1);

                    if(flag_B==1)
                    {
                        //Question header for section - 1 - (B)              
                        PdfPCell cell7_1 = new PdfPCell(new Phrase(txtHeader1_B.Text, font));
                        cell7_1.Colspan = 2;
                        cell7_1.Border = 0;
                        table.AddCell(cell7_1);

                        //section marks goes here for (B)
                        int marks_B = Convert.ToInt32(txtEachQMarks1_B.Text) * Convert.ToInt32(txtQNo1_B.Text);
                        PdfPCell cell8_1 = new PdfPCell(new Phrase(marks_B.ToString(), font));
                        cell8_1.Colspan = 1;
                        cell8_1.Border = 0;
                        cell8_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell8_1);

                        //questions Goes Here for (B)
                        try
                        {
                            string QDLevel = cbQDifficulty1_B.SelectedItem.ToString();
                            string QType = cbQuestionType1_B.SelectedItem.ToString();
                            subjectName = Login_info.SelectedSubject;
                            DataTable dt = new DataTable();
                            cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                            con.Open();
                            cmd.Parameters.AddWithValue("@subjectName", subjectName);
                            cmd.Parameters.AddWithValue("@QType", QType);
                            cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                            adapt = new SqlDataAdapter(cmd);
                            // DataSet ds = new DataSet();
                            //adapt.Fill(ds);
                            adapt.Fill(dt);

                            List<RandomQuestions> Qlist_B = new List<RandomQuestions>();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                RandomQuestions RQ = new RandomQuestions();
                                RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                                RQ.Question = dt.Rows[i]["Question"].ToString();
                                Qlist_B.Add(RQ);
                                GlobalList.Add(RQ);
                            }
                            //Question Suffling goes here
                            Shuffler shuffler = new Shuffler();
                            shuffler.Shuffle(Qlist_B);
                            for (int i = 0; i < Convert.ToInt32(txtQNo1_B.Text) + Convert.ToInt32(txtQoption1_B.Text); i++)
                            {

                                PdfPCell cell9 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist_B[i].Question, font));
                                cell9.Colspan = 3;
                                cell9.Border = 0;
                                cell9.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell9);
                            }
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error : " + ex.ToString());
                            throw;
                        }
                    }
                    

                }

                //blank line...
                PdfPCell Blank_cell_2 = new PdfPCell(new Phrase("\n", font));
                Blank_cell_2.Colspan = 3;
                Blank_cell_2.Border = 0;
                Blank_cell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(Blank_cell_2);

                // Question of Section - 2 paper Goes here..
                if (flag2 == 2)
                {
                    //question header goes here - (A)
                    PdfPCell cell10 = new PdfPCell(new Phrase(txtHeader2.Text, font));
                    cell10.Colspan = 2;
                    cell10.Border = 0;
                    table.AddCell(cell10);

                    //section marks goes here - (A)
                    int marks2_A = Convert.ToInt32(txtEachQMark2.Text) * Convert.ToInt32(txtQNo2.Text);
                    PdfPCell cell11 = new PdfPCell(new Phrase(marks2_A.ToString(), font));
                    cell11.Colspan = 1;
                    cell11.Border = 0;
                    cell11.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell11);

                    //questions Goes Here. - (A)
                    try
                    {
                        string QDLevel = cbQDifficulty2.SelectedItem.ToString();
                        string QType = cbQuestionType2.SelectedItem.ToString();
                        subjectName = Login_info.SelectedSubject;
                        DataTable dt = new DataTable();
                        cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@subjectName", subjectName);
                        cmd.Parameters.AddWithValue("@QType", QType);
                        cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                        adapt = new SqlDataAdapter(cmd);
                        // DataSet ds = new DataSet();
                        //adapt.Fill(ds);
                        adapt.Fill(dt);

                        List<RandomQuestions> Qlist2 = new List<RandomQuestions>();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            RandomQuestions RQ = new RandomQuestions();
                            RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                            RQ.Question = dt.Rows[i]["Question"].ToString();
                            Qlist2.Add(RQ);
                            GlobalList.Add(RQ);
                        }
                        //Question Suffling goes here
                        Shuffler shuffler = new Shuffler();
                        shuffler.Shuffle(Qlist2);
                        for (int i = 0; i < Convert.ToInt32(txtQNo2.Text) + Convert.ToInt32(txtQoption2.Text); i++)
                        {

                            PdfPCell cell12 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist2[i].Question, font));
                            cell12.Colspan = 3;
                            cell12.Border = 0;
                            cell12.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell12);
                        }
                        // for(int i=0;i<Convert.ToInt32(txtQNo.Text)+Convert.ToInt32(txtQoption.Text);i++)

                        for (int i = 0; i < Qlist2.Count; i++)
                            Console.WriteLine("Qlist - 2 : " + Qlist2[i].Q_Id);

                        //foreach (DataRow row in dt.Rows)
                        //{
                        //    foreach(DataColumn column in dt.Columns)
                        //    {
                        //        Console.WriteLine(row[column]);
                        //        Shuffler shuffler = new Shuffler();

                        //    }
                        //}

                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : ", ex.ToString());
                        throw;
                    }

                    //blank line...
                    PdfPCell Blank_cell_3_1 = new PdfPCell(new Phrase("\n", font));
                    Blank_cell_3_1.Colspan = 3;
                    Blank_cell_3_1.Border = 0;
                    Blank_cell_3_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(Blank_cell_3_1);

                    if(flag2_B==2)
                    {
                        //question header goes here - (B)
                        PdfPCell cell10_1 = new PdfPCell(new Phrase(txtHeader2_B.Text, font));
                        cell10_1.Colspan = 2;
                        cell10_1.Border = 0;
                        table.AddCell(cell10_1);

                        //section marks goes here - (B)
                        int marks2_B = Convert.ToInt32(txtEachQMark2_B.Text) * Convert.ToInt32(txtQNo2_B.Text);
                        PdfPCell cell11_1 = new PdfPCell(new Phrase(marks2_B.ToString(), font));
                        cell11_1.Colspan = 1;
                        cell11_1.Border = 0;
                        cell11_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell11_1);

                        //questions Goes Here. - (B)
                        try
                        {
                            string QDLevel = cbQDifficulty2_B.SelectedItem.ToString();
                            string QType = cbQuestionType2_B.SelectedItem.ToString();
                            subjectName = Login_info.SelectedSubject;
                            DataTable dt = new DataTable();
                            cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                            con.Open();
                            cmd.Parameters.AddWithValue("@subjectName", subjectName);
                            cmd.Parameters.AddWithValue("@QType", QType);
                            cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                            adapt = new SqlDataAdapter(cmd);
                            // DataSet ds = new DataSet();
                            //adapt.Fill(ds);
                            adapt.Fill(dt);

                            List<RandomQuestions> Qlist2_B = new List<RandomQuestions>();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                RandomQuestions RQ = new RandomQuestions();
                                RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                                RQ.Question = dt.Rows[i]["Question"].ToString();
                                Qlist2_B.Add(RQ);
                                GlobalList.Add(RQ);
                            }
                            //Question Suffling goes here
                            Shuffler shuffler = new Shuffler();
                            shuffler.Shuffle(Qlist2_B);
                            for (int i = 0; i < Convert.ToInt32(txtQNo2_B.Text) + Convert.ToInt32(txtQoption2_B.Text); i++)
                            {
                                PdfPCell cell12 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist2_B[i].Question, font));
                                cell12.Colspan = 3;
                                cell12.Border = 0;
                                cell12.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell12);
                            }
                            // for(int i=0;i<Convert.ToInt32(txtQNo.Text)+Convert.ToInt32(txtQoption.Text);i++)

                            for (int i = 0; i < Qlist2_B.Count; i++)
                                Console.WriteLine("Qlist - 2 : " + Qlist2_B[i].Q_Id);

                            //foreach (DataRow row in dt.Rows)
                            //{
                            //    foreach(DataColumn column in dt.Columns)
                            //    {
                            //        Console.WriteLine(row[column]);
                            //        Shuffler shuffler = new Shuffler();

                            //    }
                            //}

                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error : ", ex.ToString());
                            throw;
                        }
                    }
                    

                }

                //blank line...
                PdfPCell Blank_cell_3 = new PdfPCell(new Phrase("\n", font));
                Blank_cell_3.Colspan = 3;
                Blank_cell_3.Border = 0;
                Blank_cell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(Blank_cell_3);

                // Question of Section - 3 paper Goes here..
                if (flag3 == 3)
                {
                    //question header goes here - (A)
                    PdfPCell cell13 = new PdfPCell(new Phrase(txtHeader3.Text, font));
                    cell13.Colspan = 2;
                    cell13.Border = 0;
                    table.AddCell(cell13);

                    //section marks goes here - (A)
                    int marks3_A = Convert.ToInt32(txtEachQMark3.Text) * Convert.ToInt32(txtQNo3.Text);
                    PdfPCell cell14 = new PdfPCell(new Phrase(marks3_A.ToString(), font));
                    cell14.Colspan = 1;
                    cell14.Border = 0;
                    cell14.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell14);

                    //questions Goes Here. - (A)
                    try
                    {
                        string QDLevel = cbQDifficulty3.SelectedItem.ToString();
                        string QType = cbQuestionType3.SelectedItem.ToString();
                        subjectName = Login_info.SelectedSubject;
                        DataTable dt = new DataTable();
                        cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@subjectName", subjectName);
                        cmd.Parameters.AddWithValue("@QType", QType);
                        cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                        adapt = new SqlDataAdapter(cmd);
                        // DataSet ds = new DataSet();
                        //adapt.Fill(ds);
                        adapt.Fill(dt);

                        List<RandomQuestions> Qlist3 = new List<RandomQuestions>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            RandomQuestions RQ = new RandomQuestions();
                            RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                            RQ.Question = dt.Rows[i]["Question"].ToString();
                            Qlist3.Add(RQ);
                            GlobalList.Add(RQ);
                        }
                        //Question Suffling goes here
                        Shuffler shuffler = new Shuffler();
                        shuffler.Shuffle(Qlist3);
                        for (int i = 0; i < Convert.ToInt32(txtQNo3.Text) + Convert.ToInt32(txtQoption3.Text); i++)
                        {

                            PdfPCell cell15 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist3[i].Question, font));
                            cell15.Colspan = 3;
                            cell15.Border = 0;
                            cell15.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell15);
                        }



                        // for(int i=0;i<Convert.ToInt32(txtQNo.Text)+Convert.ToInt32(txtQoption.Text);i++)

                        for (int i = 0; i < Qlist3.Count; i++)
                            Console.WriteLine("QList - 3 : " + Qlist3[i].Q_Id);

                        //foreach (DataRow row in dt.Rows)
                        //{
                        //    foreach(DataColumn column in dt.Columns)
                        //    {
                        //        Console.WriteLine(row[column]);
                        //        Shuffler shuffler = new Shuffler();

                        //    }
                        //}

                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : ", ex.ToString());
                        throw;
                    }

                    //blank line...
                    PdfPCell Blank_cell_4_1 = new PdfPCell(new Phrase("\n", font));
                    Blank_cell_4_1.Colspan = 3;
                    Blank_cell_4_1.Border = 0;
                    Blank_cell_4_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(Blank_cell_4_1);

                    if(flag3_B==3)
                    {
                        //question header goes here - (B)
                        PdfPCell cell10_1 = new PdfPCell(new Phrase(txtHeader3_B.Text, font));
                        cell10_1.Colspan = 2;
                        cell10_1.Border = 0;
                        table.AddCell(cell10_1);

                        //section marks goes here - (B)
                        int marks3_B = Convert.ToInt32(txtEachQMark3_B.Text) * Convert.ToInt32(txtQNo3_B.Text);
                        PdfPCell cell11_1 = new PdfPCell(new Phrase(marks3_B.ToString(), font));
                        cell11_1.Colspan = 1;
                        cell11_1.Border = 0;
                        cell11_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell11_1);

                        //questions Goes Here. - (B)
                        try
                        {
                            string QDLevel = cbQDifficulty3_B.SelectedItem.ToString();
                            string QType = cbQuestionType3_B.SelectedItem.ToString();
                            subjectName = Login_info.SelectedSubject;
                            DataTable dt = new DataTable();
                            cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                            con.Open();
                            cmd.Parameters.AddWithValue("@subjectName", subjectName);
                            cmd.Parameters.AddWithValue("@QType", QType);
                            cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                            adapt = new SqlDataAdapter(cmd);
                            // DataSet ds = new DataSet();
                            //adapt.Fill(ds);
                            adapt.Fill(dt);

                            List<RandomQuestions> Qlist3_B = new List<RandomQuestions>();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                RandomQuestions RQ = new RandomQuestions();
                                RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                                RQ.Question = dt.Rows[i]["Question"].ToString();
                                Qlist3_B.Add(RQ);
                                GlobalList.Add(RQ);
                            }
                            //Question Suffling goes here
                            Shuffler shuffler = new Shuffler();
                            shuffler.Shuffle(Qlist3_B);
                            for (int i = 0; i < Convert.ToInt32(txtQNo3_B.Text) + Convert.ToInt32(txtQoption3_B.Text); i++)
                            {
                                PdfPCell cell12 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist3_B[i].Question, font));
                                cell12.Colspan = 3;
                                cell12.Border = 0;
                                cell12.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell12);
                            }
                            // for(int i=0;i<Convert.ToInt32(txtQNo.Text)+Convert.ToInt32(txtQoption.Text);i++)

                            for (int i = 0; i < Qlist3_B.Count; i++)
                                Console.WriteLine("Qlist - 3 : " + Qlist3_B[i].Q_Id);

                            //foreach (DataRow row in dt.Rows)
                            //{
                            //    foreach(DataColumn column in dt.Columns)
                            //    {
                            //        Console.WriteLine(row[column]);
                            //        Shuffler shuffler = new Shuffler();

                            //    }
                            //}

                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error : ", ex.ToString());
                            throw;
                        }
                    }
                    

                }

                //blank line...
                PdfPCell Blank_cell_4 = new PdfPCell(new Phrase("\n", font));
                Blank_cell_4.Colspan = 3;
                Blank_cell_4.Border = 0;
                Blank_cell_4.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(Blank_cell_4);

                // Question of Section - 4 paper Goes here..
                if (flag4 == 4)
                {
                    //question header goes here - (A)
                    PdfPCell cell16 = new PdfPCell(new Phrase(txtHeader4.Text, font));
                    cell16.Colspan = 2;
                    cell16.Border = 0;
                    table.AddCell(cell16);

                    //section marks goes here - (A)
                    int marks4_A = Convert.ToInt32(txtEachQMark4.Text) * Convert.ToInt32(txtQNo4.Text);
                    PdfPCell cell17 = new PdfPCell(new Phrase(marks4_A.ToString(), font));
                    cell17.Colspan = 1;
                    cell17.Border = 0;
                    cell17.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell17);

                    //questions Goes Here. - (A)
                    try
                    {
                        string QDLevel = cbQDifficulty4.SelectedItem.ToString();
                        string QType = cbQuestionType4.SelectedItem.ToString();
                        subjectName = Login_info.SelectedSubject;
                        DataTable dt = new DataTable();
                        cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@subjectName", subjectName);
                        cmd.Parameters.AddWithValue("@QType", QType);
                        cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                        adapt = new SqlDataAdapter(cmd);
                        // DataSet ds = new DataSet();
                        //adapt.Fill(ds);
                        adapt.Fill(dt);

                        List<RandomQuestions> Qlist4 = new List<RandomQuestions>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            RandomQuestions RQ = new RandomQuestions();
                            RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                            RQ.Question = dt.Rows[i]["Question"].ToString();
                            Qlist4.Add(RQ);
                            GlobalList.Add(RQ);
                        }
                        //Question Suffling goes here
                        Shuffler shuffler = new Shuffler();
                        shuffler.Shuffle(Qlist4);
                        for (int i = 0; i < Convert.ToInt32(txtQNo4.Text) + Convert.ToInt32(txtQoption4.Text); i++)
                        {

                            PdfPCell cell18 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist4[i].Question, font));
                            cell18.Colspan = 3;
                            cell18.Border = 0;
                            cell18.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell18);
                        }



                        // for(int i=0;i<Convert.ToInt32(txtQNo.Text)+Convert.ToInt32(txtQoption.Text);i++)

                        for (int i = 0; i < Qlist4.Count; i++)
                            Console.WriteLine("QList - 4 : " + Qlist4[i].Q_Id);

                        //foreach (DataRow row in dt.Rows)
                        //{
                        //    foreach(DataColumn column in dt.Columns)
                        //    {
                        //        Console.WriteLine(row[column]);
                        //        Shuffler shuffler = new Shuffler();

                        //    }
                        //}

                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : ", ex.ToString());
                        throw;
                    }

                    //blank line...
                    PdfPCell Blank_cell_5_1 = new PdfPCell(new Phrase("\n", font));
                    Blank_cell_5_1.Colspan = 3;
                    Blank_cell_5_1.Border = 0;
                    Blank_cell_5_1.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(Blank_cell_5_1);

                    if(flag4_B==4)
                    {
                        //question header goes here - (B)
                        PdfPCell cell10_1 = new PdfPCell(new Phrase(txtHeader4_B.Text, font));
                        cell10_1.Colspan = 2;
                        cell10_1.Border = 0;
                        table.AddCell(cell10_1);

                        //section marks goes here - (B)
                        int marks4_B = Convert.ToInt32(txtEachQMark4_B.Text) * Convert.ToInt32(txtQNo4_B.Text);
                        PdfPCell cell11_1 = new PdfPCell(new Phrase(marks4_B.ToString(), font));
                        cell11_1.Colspan = 1;
                        cell11_1.Border = 0;
                        cell11_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell11_1);

                        //questions Goes Here. - (B)
                        try
                        {
                            string QDLevel = cbQDifficulty4_B.SelectedItem.ToString();
                            string QType = cbQuestionType4_B.SelectedItem.ToString();
                            subjectName = Login_info.SelectedSubject;
                            DataTable dt = new DataTable();
                            cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                            con.Open();
                            cmd.Parameters.AddWithValue("@subjectName", subjectName);
                            cmd.Parameters.AddWithValue("@QType", QType);
                            cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                            adapt = new SqlDataAdapter(cmd);
                            // DataSet ds = new DataSet();
                            //adapt.Fill(ds);
                            adapt.Fill(dt);

                            List<RandomQuestions> Qlist4_B = new List<RandomQuestions>();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                RandomQuestions RQ = new RandomQuestions();
                                RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                                RQ.Question = dt.Rows[i]["Question"].ToString();
                                Qlist4_B.Add(RQ);
                                GlobalList.Add(RQ);
                            }
                            //Question Suffling goes here
                            Shuffler shuffler = new Shuffler();
                            shuffler.Shuffle(Qlist4_B);
                            for (int i = 0; i < Convert.ToInt32(txtQNo4_B.Text) + Convert.ToInt32(txtQoption4_B.Text); i++)
                            {
                                PdfPCell cell12 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist4_B[i].Question, font));
                                cell12.Colspan = 3;
                                cell12.Border = 0;
                                cell12.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell12);
                            }
                            // for(int i=0;i<Convert.ToInt32(txtQNo.Text)+Convert.ToInt32(txtQoption.Text);i++)

                            for (int i = 0; i < Qlist4_B.Count; i++)
                                Console.WriteLine("Qlist - 4 : " + Qlist4_B[i].Q_Id);

                            //foreach (DataRow row in dt.Rows)
                            //{
                            //    foreach(DataColumn column in dt.Columns)
                            //    {
                            //        Console.WriteLine(row[column]);
                            //        Shuffler shuffler = new Shuffler();

                            //    }
                            //}

                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error : ", ex.ToString());
                            throw;
                        }
                    }
                    

                }

                //blank line...
                PdfPCell Blank_cell_5 = new PdfPCell(new Phrase("\n", font));
                Blank_cell_5.Colspan = 3;
                Blank_cell_5.Border = 0;
                Blank_cell_5.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(Blank_cell_5);

                // Question of Section - 5 paper Goes here..
                if (flag5 == 5)
                {
                    //question header goes here - (A)
                    PdfPCell cell19 = new PdfPCell(new Phrase(txtHeader5.Text, font));
                    cell19.Colspan = 2;
                    cell19.Border = 0;
                    table.AddCell(cell19);

                    //section marks goes here - (A)

                    int marks5_A = Convert.ToInt32(txtEachQMark5.Text) * Convert.ToInt32(txtQNo5.Text);
                    PdfPCell cell20 = new PdfPCell(new Phrase(marks5_A.ToString(), font));
                    cell20.Colspan = 1;
                    cell20.Border = 0;
                    cell20.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell20);

                    //questions Goes Here. - (A)
                    try
                    {
                        string QDLevel = cbQDifficulty5.SelectedItem.ToString();
                        string QType = cbQuestionType5.SelectedItem.ToString();
                        subjectName = Login_info.SelectedSubject;
                        DataTable dt = new DataTable();
                        cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@subjectName", subjectName);
                        cmd.Parameters.AddWithValue("@QType", QType);
                        cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                        adapt = new SqlDataAdapter(cmd);
                        // DataSet ds = new DataSet();
                        //adapt.Fill(ds);
                        adapt.Fill(dt);

                        List<RandomQuestions> Qlist5 = new List<RandomQuestions>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            RandomQuestions RQ = new RandomQuestions();
                            RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                            RQ.Question = dt.Rows[i]["Question"].ToString();
                            Qlist5.Add(RQ);
                            GlobalList.Add(RQ);
                        }
                        //Question Suffling goes here
                        Shuffler shuffler = new Shuffler();
                        shuffler.Shuffle(Qlist5);
                        for (int i = 0; i < Convert.ToInt32(txtQNo5.Text) + Convert.ToInt32(txtQoption5.Text); i++)
                        {

                            PdfPCell cell21 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist5[i].Question, font));
                            cell21.Colspan = 3;
                            cell21.Border = 0;
                            cell21.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell21);
                        }
                        for (int i = 0; i < Qlist5.Count; i++)
                            Console.WriteLine("QList - 5 : " + Qlist5[i].Q_Id);
                        //foreach (DataRow row in dt.Rows)
                        //{
                        //    foreach(DataColumn column in dt.Columns)
                        //    {
                        //        Console.WriteLine(row[column]);
                        //        Shuffler shuffler = new Shuffler();

                        //    }
                        //}
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : ", ex.ToString());
                        throw;
                    }

                    //blank line...
                    PdfPCell Blank_cell_6 = new PdfPCell(new Phrase("\n", font));
                    Blank_cell_6.Colspan = 3;
                    Blank_cell_6.Border = 0;
                    Blank_cell_6.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(Blank_cell_6);

                    if(flag5_B==5)
                    {
                        //question header goes here - (B)
                        PdfPCell cell10_1 = new PdfPCell(new Phrase(txtHeader5_B.Text, font));
                        cell10_1.Colspan = 2;
                        cell10_1.Border = 0;
                        table.AddCell(cell10_1);

                        //section marks goes here - (B)
                        int marks5_B = Convert.ToInt32(txtEachQMark5_B.Text) * Convert.ToInt32(txtQNo5_B.Text);
                        PdfPCell cell11_1 = new PdfPCell(new Phrase(marks5_B.ToString(), font));
                        cell11_1.Colspan = 1;
                        cell11_1.Border = 0;
                        cell11_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell11_1);

                        //questions Goes Here. - (B)
                        try
                        {
                            string QDLevel = cbQDifficulty5_B.SelectedItem.ToString();
                            string QType = cbQuestionType5_B.SelectedItem.ToString();
                            subjectName = Login_info.SelectedSubject;
                            DataTable dt = new DataTable();
                            cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QDLevel", con);
                            con.Open();
                            cmd.Parameters.AddWithValue("@subjectName", subjectName);
                            cmd.Parameters.AddWithValue("@QType", QType);
                            cmd.Parameters.AddWithValue("@QDLevel", QDLevel);
                            adapt = new SqlDataAdapter(cmd);
                            // DataSet ds = new DataSet();
                            //adapt.Fill(ds);
                            adapt.Fill(dt);

                            List<RandomQuestions> Qlist5_B = new List<RandomQuestions>();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                RandomQuestions RQ = new RandomQuestions();
                                RQ.Q_Id = Convert.ToInt32(dt.Rows[i]["Q_Id"]);
                                RQ.Question = dt.Rows[i]["Question"].ToString();
                                Qlist5_B.Add(RQ);
                                GlobalList.Add(RQ);
                            }
                            //Question Suffling goes here
                            Shuffler shuffler = new Shuffler();
                            shuffler.Shuffle(Qlist5_B);
                            for (int i = 0; i < Convert.ToInt32(txtQNo5_B.Text) + Convert.ToInt32(txtQoption5_B.Text); i++)
                            {
                                PdfPCell cell12 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist5_B[i].Question, font));
                                cell12.Colspan = 3;
                                cell12.Border = 0;
                                cell12.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell12);
                            }
                            // for(int i=0;i<Convert.ToInt32(txtQNo.Text)+Convert.ToInt32(txtQoption.Text);i++)

                            for (int i = 0; i < Qlist5_B.Count; i++)
                                Console.WriteLine("Qlist - 2 : " + Qlist5_B[i].Q_Id);

                            //foreach (DataRow row in dt.Rows)
                            //{
                            //    foreach(DataColumn column in dt.Columns)
                            //    {
                            //        Console.WriteLine(row[column]);
                            //        Shuffler shuffler = new Shuffler();

                            //    }
                            //}

                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error : ", ex.ToString());
                            throw;
                        }
                    }
                    

                }
                //global list display
                for (int i = 0; i < GlobalList.Count; i++)
                    Console.WriteLine("Global List  : " + GlobalList[i].Q_Id);

                document.Add(table);
                document.Close();
                this.Hide();
                Final_Paper_Preview p2 = new Final_Paper_Preview();
                p2.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : ", ex.ToString());
                throw;
            }
        }

        private void btnSetQuestion1_Click(object sender, EventArgs e)
        {
            int track = Convert.ToInt32(txtQNo.Text) + Convert.ToInt32(txtQoption.Text);

            if (Convert.ToInt32(txtQNo.Text) <= Convert.ToInt32(txtTotalAvailable.Text))
            {
                if (Convert.ToInt32(txtEachQMark.Text) * Convert.ToInt32(txtQNo.Text) > 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark.Text) * Convert.ToInt32(txtQNo.Text);
                    MessageBox.Show(difference + " Mark Is More Than 20 .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                   // if (Convert.ToInt32(txtEachQMark.Text) * Convert.ToInt32(txtQNo.Text) == 20)
                    //{
                        // pnlSection_2.Visible = true;
                        flag = 1;
                    //}

                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }



        private void btnSetQuestion2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo2.Text) <= Convert.ToInt32(txtTotalAvailable2.Text))
            {
                if (Convert.ToInt32(txtEachQMark2.Text) * Convert.ToInt32(txtQNo2.Text) > 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark2.Text) * Convert.ToInt32(txtQNo2.Text);
                    MessageBox.Show(difference + " Mark Is More Than 20 .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    // pnlSection_3.Visible = true;
                    flag2 = 2;
                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }
        private void cbQDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty.SelectedItem.ToString();
                string QType = cbQuestionType.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;
               

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable.Text = count.ToString();
                txtEachQMark.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }
        private void cbQDifficulty1_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty1_B.SelectedItem.ToString();
                string QType = cbQuestionType1_B.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable1_B.Text = count.ToString();
                txtEachQMarks1_B.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }
        private void cbQDifficulty2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty2.SelectedItem.ToString();
                string QType = cbQuestionType2.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable2.Text = count.ToString();
                txtEachQMark2.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }

        private void cbQDifficulty3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty3.SelectedItem.ToString();
                string QType = cbQuestionType3.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable3.Text = count.ToString();
                txtEachQMark3.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }

        private void cbQDifficulty4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty4.SelectedItem.ToString();
                string QType = cbQuestionType4.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable4.Text = count.ToString();
                txtEachQMark4.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }

        private void btnSetQuestion1_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo1_B.Text) <= Convert.ToInt32(txtTotalAvailable1_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMarks1_B.Text) * Convert.ToInt32(txtQNo1_B.Text)) + (Convert.ToInt32(txtEachQMark.Text) * Convert.ToInt32(txtQNo.Text)) < 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark.Text) * Convert.ToInt32(txtQNo.Text);
                    MessageBox.Show(difference + " Mark Is Remaining .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMarks1_B.Text) * Convert.ToInt32(txtQNo1_B.Text)) + (Convert.ToInt32(txtEachQMark.Text) * Convert.ToInt32(txtQNo.Text)) > 20)
                {
                    int difference = ((Convert.ToInt32(txtEachQMark.Text) * Convert.ToInt32(txtQNo.Text) + Convert.ToInt32(txtEachQMarks1_B.Text) * Convert.ToInt32(txtQNo1_B.Text))) - Convert.ToInt32(txtEachSectionMark.Text);
                    MessageBox.Show(difference + " Mark Is More Than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //pnlSection_2.Visible = true;
                    //flag = 1;
                    flag_B = 1;
                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }

        private void btnSection_1_Click(object sender, EventArgs e)
        {
            pnlSection_1.Visible = true;
            pnlSection_2.Visible = false;
            pnlSection_3.Visible = false;
            pnlSection_4.Visible = false;
            pnlSection_5.Visible = false;

        }

        private void btnSection_2_Click(object sender, EventArgs e)
        {
            if (flag == 1 || flag_B == 1)
            {
                pnlSection_1.Visible = false;
                pnlSection_2.Visible = true;
                pnlSection_3.Visible = false;
                pnlSection_4.Visible = false;
                pnlSection_5.Visible = false;
            }
            else
            {
                MessageBox.Show("Complete Section - 1 First.");
            }

        }

        private void btnSection_3_Click(object sender, EventArgs e)
        {
            if (flag2 == 2 || flag2_B == 2)
            {
                pnlSection_1.Visible = false;
                pnlSection_2.Visible = false;
                pnlSection_3.Visible = true;
                pnlSection_4.Visible = false;
                pnlSection_5.Visible = false;
            }
            else
            {
                MessageBox.Show("Complete Section - 2 First.");
            }
        }

        private void btnSection_4_Click(object sender, EventArgs e)
        {
            if (flag3 == 3 || flag3_B == 3)
            {
                pnlSection_1.Visible = false;
                pnlSection_2.Visible = false;
                pnlSection_3.Visible = false;
                pnlSection_4.Visible = true;
                pnlSection_5.Visible = false;
            }
            else
            {
                MessageBox.Show("Complete Section - 3 First.");
            }

        }

        private void btnSection_5_Click(object sender, EventArgs e)
        {
            if (flag4 == 4 || flag4_B == 4)
            {
                pnlSection_1.Visible = false;
                pnlSection_2.Visible = false;
                pnlSection_3.Visible = false;
                pnlSection_4.Visible = false;
                pnlSection_5.Visible = true;
            }
            else
            {
                MessageBox.Show("Complete Section - 4 First.");
            }

        }

        private void btnSetQuestion2_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo2_B.Text) <= Convert.ToInt32(txtTotalAvailable2_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMark2_B.Text) * Convert.ToInt32(txtQNo2_B.Text)) + (Convert.ToInt32(txtEachQMark2.Text) * Convert.ToInt32(txtQNo2.Text)) < 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark2.Text) * Convert.ToInt32(txtQNo2.Text);
                    MessageBox.Show(difference + " Mark Is Remaining .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMark2_B.Text) * Convert.ToInt32(txtQNo2_B.Text)) + (Convert.ToInt32(txtEachQMark2.Text) * Convert.ToInt32(txtQNo2.Text)) > 20)
                {
                    int difference = ((Convert.ToInt32(txtEachQMark2.Text) * Convert.ToInt32(txtQNo2.Text) + Convert.ToInt32(txtEachQMark2_B.Text) * Convert.ToInt32(txtQNo2_B.Text))) - Convert.ToInt32(txtEachSectionMark.Text);
                    MessageBox.Show(difference + " Mark Is More Than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //pnlSection_2.Visible = true;
                    //   flag2 = 2;
                    flag2_B = 2;
                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }

        private void btnSetQuestion3_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo3_B.Text) <= Convert.ToInt32(txtTotalAvailable3_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMark3_B.Text) * Convert.ToInt32(txtQNo3_B.Text)) + (Convert.ToInt32(txtEachQMark3.Text) * Convert.ToInt32(txtQNo3.Text)) < 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark3.Text) * Convert.ToInt32(txtQNo3.Text);
                    MessageBox.Show(difference + " Mark Is Remaining .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMark3_B.Text) * Convert.ToInt32(txtQNo3_B.Text)) + (Convert.ToInt32(txtEachQMark3.Text) * Convert.ToInt32(txtQNo3.Text)) > 20)
                {
                    int difference = ((Convert.ToInt32(txtEachQMark3.Text) * Convert.ToInt32(txtQNo3.Text) + Convert.ToInt32(txtEachQMark3_B.Text) * Convert.ToInt32(txtQNo3_B.Text))) - Convert.ToInt32(txtEachSectionMark.Text);
                    MessageBox.Show(difference + " Mark Is More Than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //pnlSection_2.Visible = true;
                    //flag3 = 3;
                    flag3_B = 3;
                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }

        private void btnSetQuestion4_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo4_B.Text) <= Convert.ToInt32(txtTotalAvailable4_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMark4_B.Text) * Convert.ToInt32(txtQNo4_B.Text)) + (Convert.ToInt32(txtEachQMark4.Text) * Convert.ToInt32(txtQNo4.Text)) < 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark4.Text) * Convert.ToInt32(txtQNo4.Text);
                    MessageBox.Show(difference + " Mark Is Remaining .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMark4_B.Text) * Convert.ToInt32(txtQNo4_B.Text)) + (Convert.ToInt32(txtEachQMark4.Text) * Convert.ToInt32(txtQNo4.Text)) > 20)
                {
                    int difference = ((Convert.ToInt32(txtEachQMark4.Text) * Convert.ToInt32(txtQNo4.Text) + Convert.ToInt32(txtEachQMark4_B.Text) * Convert.ToInt32(txtQNo4_B.Text))) - Convert.ToInt32(txtEachSectionMark.Text);
                    MessageBox.Show(difference + " Mark Is More Than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //pnlSection_2.Visible = true;
                    //flag4 = 4;
                    flag4_B = 4;
                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }

        private void btnSetQuestion5_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo5_B.Text) <= Convert.ToInt32(txtTotalAvailable5_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMark5_B.Text) * Convert.ToInt32(txtQNo5_B.Text)) + (Convert.ToInt32(txtEachQMark5.Text) * Convert.ToInt32(txtQNo5.Text)) < 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark5.Text) * Convert.ToInt32(txtQNo5.Text);
                    MessageBox.Show(difference + " Mark Is Remaining .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMark5_B.Text) * Convert.ToInt32(txtQNo5_B.Text)) + (Convert.ToInt32(txtEachQMark5.Text) * Convert.ToInt32(txtQNo5.Text)) > 20)
                {
                    int difference = ((Convert.ToInt32(txtEachQMark5.Text) * Convert.ToInt32(txtQNo5.Text) + Convert.ToInt32(txtEachQMark5_B.Text) * Convert.ToInt32(txtQNo5_B.Text))) - Convert.ToInt32(txtEachSectionMark.Text);
                    MessageBox.Show(difference + " Mark Is More Than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //pnlSection_2.Visible = true;
                    //flag5 = 5;
                    flag5_B = 5;
                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }

        private void cbQDifficulty2_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty2_B.SelectedItem.ToString();
                string QType = cbQuestionType2_B.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable2_B.Text = count.ToString();
                txtEachQMark2_B.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }

        private void cbQDifficulty3_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty3_B.SelectedItem.ToString();
                string QType = cbQuestionType3_B.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable3_B.Text = count.ToString();
                txtEachQMark3_B.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }

        private void cbQDifficulty4_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty4_B.SelectedItem.ToString();
                string QType = cbQuestionType4_B.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable4_B.Text = count.ToString();
                txtEachQMark4_B.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }

        private void cbQDifficulty5_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty5_B.SelectedItem.ToString();
                string QType = cbQuestionType5_B.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable5_B.Text = count.ToString();
                txtEachQMark5_B.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }

        private void cbQDifficulty5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string QDLevel = cbQDifficulty5.SelectedItem.ToString();
                string QType = cbQuestionType5.SelectedItem.ToString();
                string subjectName = Login_info.SelectedSubject;
                DataTable dt = new DataTable();
                cmd = new SqlCommand("select Q_Type from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                con.Open();
                cmd.Parameters.AddWithValue("@subjectName", subjectName);
                cmd.Parameters.AddWithValue("@QType", QType);
                cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();

                //total question available for selected type
                int count = ds.Tables[0].Rows.Count;

                //Each question marks
                int QueMark = 0;
                if (QType == "LA")
                    QueMark = 5;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "VLA")
                    QueMark = 10;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "VSA")
                    QueMark = 1;

                txtTotalAvailable5.Text = count.ToString();
                txtEachQMark5.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }

        private void btnSetQuestion3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo3.Text) <= Convert.ToInt32(txtTotalAvailable3.Text))
            {
                if (Convert.ToInt32(txtEachQMark3.Text) * Convert.ToInt32(txtQNo3.Text) > 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark3.Text) * Convert.ToInt32(txtQNo3.Text);
                    MessageBox.Show(difference + " Mark Is More Than 20 .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //    pnlSection_4.Visible = true;
                    flag3 = 3;
                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }

        private void btnSetQuestion4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo4.Text) <= Convert.ToInt32(txtTotalAvailable4.Text))
            {
                if (Convert.ToInt32(txtEachQMark4.Text) * Convert.ToInt32(txtQNo4.Text) > 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark4.Text) * Convert.ToInt32(txtQNo4.Text);
                    MessageBox.Show(difference + " Mark Is More Than 20 .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    // pnlSection_5.Visible = true;
                    flag4 = 4;
                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }

        private void btnSetQuestion5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo5.Text) <= Convert.ToInt32(txtTotalAvailable5.Text))
            {
                if (Convert.ToInt32(txtEachQMark5.Text) * Convert.ToInt32(txtQNo5.Text) > 20)
                {
                    int difference = Convert.ToInt32(txtEachSectionMark.Text) - Convert.ToInt32(txtEachQMark5.Text) * Convert.ToInt32(txtQNo5.Text);
                    MessageBox.Show(difference + " Mark Is More Than 20 .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    //       pnlSection_2.Visible = true;
                    flag5 = 5;
                }

            }
            else
            {
                MessageBox.Show("Sorry !! You Select More than available Question");
            }
        }
    }
}
