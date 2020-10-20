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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace QPG_AI
{
    public partial class Set_MidsemExam_Paper : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\QPG_Database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int flag = 0, flag2 = 0, flag3 = 0, flag4 = 0, flag5 = 0;
        int flag_B = 0, flag2_B = 0, flag3_B = 0, flag4_B = 0, flag5_B = 0;
        List<RandomQuestions> GlobalList = new List<RandomQuestions>();
        public Set_MidsemExam_Paper()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            pnlSection1.Visible = false;
            pnlSection2.Visible = false;
            pnlSection3.Visible = false;
            pnlSection4.Visible = false;
            pnlSection5.Visible = false;

            btnSection_1.Visible = false;
            btnSection_2.Visible = false;
            btnSection_3.Visible = false;
            btnSection_4.Visible = false;
            btnSection_5.Visible = false;

            txtEachSectionMarks.ReadOnly = true;
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

        private void btnGO_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTotalSection.Text) == 5)
            {
                btnSection_1.Visible = true;
                btnSection_2.Visible = true;
                btnSection_3.Visible = true;
                btnSection_4.Visible = true;
                btnSection_5.Visible = true;

                txtEachSectionMarks.Text = "10";

                //fill Question type here for section - 1 (A)
                cbQuestionType.Text = "Select Question Type";
                cbQuestionType.Items.Add("VSA");
                cbQuestionType.Items.Add("SA");
                cbQuestionType.Items.Add("BA");
                cbQuestionType.Items.Add("LA");
                cbQuestionType.Items.Add("VLA");

                //fill Question type here for section - 1 (B)
                cbQuestionType1_B.Text = "Select Question Type";
                cbQuestionType1_B.Items.Add("VSA");
                cbQuestionType1_B.Items.Add("SA");
                cbQuestionType1_B.Items.Add("BA");
                cbQuestionType1_B.Items.Add("LA");
                cbQuestionType1_B.Items.Add("VLA");

                //fill Question type here for section - 2
                cbQuestionType2.Text = "Select Question Type";
                cbQuestionType2.Items.Add("VSA");
                cbQuestionType2.Items.Add("SA");
                cbQuestionType2.Items.Add("BA");
                cbQuestionType2.Items.Add("LA");
                cbQuestionType2.Items.Add("VLA");

                //fill Question type here for section - 2 (B)
                cbQuestionType2_B.Text = "Select Question Type";
                cbQuestionType2_B.Items.Add("VSA");
                cbQuestionType2_B.Items.Add("SA");
                cbQuestionType2_B.Items.Add("BA");
                cbQuestionType2_B.Items.Add("LA");
                cbQuestionType2_B.Items.Add("VLA");

                //fill Question type here for section - 3
                cbQuestionType3.Text = "Select Question Type";
                cbQuestionType3.Items.Add("VSA");
                cbQuestionType3.Items.Add("SA");
                cbQuestionType3.Items.Add("BA");
                cbQuestionType3.Items.Add("LA");
                cbQuestionType3.Items.Add("VLA");

                //fill Question type here for section - 3 (B)
                cbQuestionType3_B.Text = "Select Question Type";
                cbQuestionType3_B.Items.Add("VSA");
                cbQuestionType3_B.Items.Add("SA");
                cbQuestionType3_B.Items.Add("BA");
                cbQuestionType3_B.Items.Add("LA");
                cbQuestionType3_B.Items.Add("VLA");

                //fill Question type here for section - 4
                cbQuestionType4.Text = "Select Question Type";
                cbQuestionType4.Items.Add("VSA");
                cbQuestionType4.Items.Add("SA");
                cbQuestionType4.Items.Add("BA");
                cbQuestionType4.Items.Add("LA");
                cbQuestionType4.Items.Add("VLA");

                //fill Question type here for section - 4 (B)
                cbQuestionType4_B.Text = "Select Question Type";
                cbQuestionType4_B.Items.Add("VSA");
                cbQuestionType4_B.Items.Add("SA");
                cbQuestionType4_B.Items.Add("BA");
                cbQuestionType4_B.Items.Add("LA");
                cbQuestionType4_B.Items.Add("VLA");

                //fill Question type here for section - 5
                cbQuestionType5.Text = "Select Question Type";
                cbQuestionType5.Items.Add("VSA");
                cbQuestionType5.Items.Add("SA");
                cbQuestionType5.Items.Add("BA");
                cbQuestionType5.Items.Add("LA");
                cbQuestionType5.Items.Add("VLA");

                //fill Question type here for section - 5 (B)
                cbQuestionType5_B.Text = "Select Question Type";
                cbQuestionType5_B.Items.Add("VSA");
                cbQuestionType5_B.Items.Add("SA");
                cbQuestionType5_B.Items.Add("BA");
                cbQuestionType5_B.Items.Add("LA");
                cbQuestionType5_B.Items.Add("VLA");

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
           else if (Convert.ToInt32(txtTotalSection.Text) == 3)
            {
                btnSection_1.Visible = true;
                btnSection_2.Visible = true;
                btnSection_3.Visible = true;
               // btnSection_4.Visible = true;
                //btnSection_5.Visible = true;

                txtEachSectionMarks.Text = "10";

                //fill Question type here for section - 1 (A)
                cbQuestionType.Text = "Select Question Type";
                cbQuestionType.Items.Add("VSA");
                cbQuestionType.Items.Add("SA");
                cbQuestionType.Items.Add("BA");
                cbQuestionType.Items.Add("LA");
                cbQuestionType.Items.Add("VLA");

                //fill Question type here for section - 1 (B)
                cbQuestionType1_B.Text = "Select Question Type";
                cbQuestionType1_B.Items.Add("VSA");
                cbQuestionType1_B.Items.Add("SA");
                cbQuestionType1_B.Items.Add("BA");
                cbQuestionType1_B.Items.Add("LA");
                cbQuestionType1_B.Items.Add("VLA");

                //fill Question type here for section - 2
                cbQuestionType2.Text = "Select Question Type";
                cbQuestionType2.Items.Add("VSA");
                cbQuestionType2.Items.Add("SA");
                cbQuestionType2.Items.Add("BA");
                cbQuestionType2.Items.Add("LA");
                cbQuestionType2.Items.Add("VLA");

                //fill Question type here for section - 2 (B)
                cbQuestionType2_B.Text = "Select Question Type";
                cbQuestionType2_B.Items.Add("VSA");
                cbQuestionType2_B.Items.Add("SA");
                cbQuestionType2_B.Items.Add("BA");
                cbQuestionType2_B.Items.Add("LA");
                cbQuestionType2_B.Items.Add("VLA");

                //fill Question type here for section - 3
                cbQuestionType3.Text = "Select Question Type";
                cbQuestionType3.Items.Add("VSA");
                cbQuestionType3.Items.Add("SA");
                cbQuestionType3.Items.Add("BA");
                cbQuestionType3.Items.Add("LA");
                cbQuestionType3.Items.Add("VLA");

                //fill Question type here for section - 3 (B)
                cbQuestionType3_B.Text = "Select Question Type";
                cbQuestionType3_B.Items.Add("VSA");
                cbQuestionType3_B.Items.Add("SA");
                cbQuestionType3_B.Items.Add("BA");
                cbQuestionType3_B.Items.Add("LA");
                cbQuestionType3_B.Items.Add("VLA");

                //fill Question type here for section - 4
                cbQuestionType4.Text = "Select Question Type";
                cbQuestionType4.Items.Add("VSA");
                cbQuestionType4.Items.Add("SA");
                cbQuestionType4.Items.Add("BA");
                cbQuestionType4.Items.Add("LA");
                cbQuestionType4.Items.Add("VLA");

                //fill Question type here for section - 4 (B)
                cbQuestionType4_B.Text = "Select Question Type";
                cbQuestionType4_B.Items.Add("VSA");
                cbQuestionType4_B.Items.Add("SA");
                cbQuestionType4_B.Items.Add("BA");
                cbQuestionType4_B.Items.Add("LA");
                cbQuestionType4_B.Items.Add("VLA");

                //fill Question type here for section - 5
                cbQuestionType5.Text = "Select Question Type";
                cbQuestionType5.Items.Add("VSA");
                cbQuestionType5.Items.Add("SA");
                cbQuestionType5.Items.Add("BA");
                cbQuestionType5.Items.Add("LA");
                cbQuestionType5.Items.Add("VLA");

                //fill Question type here for section - 5 (B)
                cbQuestionType5_B.Text = "Select Question Type";
                cbQuestionType5_B.Items.Add("VSA");
                cbQuestionType5_B.Items.Add("SA");
                cbQuestionType5_B.Items.Add("BA");
                cbQuestionType5_B.Items.Add("LA");
                cbQuestionType5_B.Items.Add("VLA");

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
                MessageBox.Show("Sorry !!! Total Number of section must be 5 or 3" );
            }
        }

        private void txtTotalSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            subject sub1 = new subject();
            sub1.Show();
        }

        private void btnSetQuestion1_Click(object sender, EventArgs e)
        {
            int track = Convert.ToInt32(txtQNo.Text) + Convert.ToInt32(txtQoption.Text);
            if (Convert.ToInt32(txtQNo.Text) <= Convert.ToInt32(txtTotalAvailable.Text))
            {
                if (Convert.ToInt32(txtEachQMarks.Text) * Convert.ToInt32(txtQNo.Text) > 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks.Text) * Convert.ToInt32(txtQNo.Text);
                    MessageBox.Show(difference + " Mark is more than 10.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag = 1;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
            }
        }

        private void btnSetQuestion1_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo1_B.Text) <= Convert.ToInt32(txtTotalAvailable1_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMarks1_B.Text) * Convert.ToInt32(txtQNo1_B.Text)) + (Convert.ToInt32(txtEachQMarks.Text) * Convert.ToInt32(txtQNo.Text)) < 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks.Text) * Convert.ToInt32(txtQNo.Text);
                    MessageBox.Show(difference + " Mark is Remaining.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMarks1_B.Text) * Convert.ToInt32(txtQNo1_B.Text)) + (Convert.ToInt32(txtEachQMarks.Text) * Convert.ToInt32(txtQNo.Text)) > 10)
                {
                    int difference = ((Convert.ToInt32(txtEachQMarks.Text) * Convert.ToInt32(txtQNo.Text) + Convert.ToInt32(txtEachQMarks1_B.Text) * Convert.ToInt32(txtQNo1_B.Text))) - Convert.ToInt32(txtEachSectionMarks.Text);
                    MessageBox.Show(difference + " Mark is More than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag_B = 1;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
            }
        }

        private void btnSetQuestion2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo2.Text) <= Convert.ToInt32(txtTotalAvailable2.Text))
            {
                if (Convert.ToInt32(txtEachQMarks2.Text) * Convert.ToInt32(txtQNo2.Text) > 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks2.Text) * Convert.ToInt32(txtQNo2.Text);
                    MessageBox.Show(difference + " Mark Is More Than 10 .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag2 = 2;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
            }
        }

        private void btnSetQuestion2_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo2_B.Text) <= Convert.ToInt32(txtTotalAvailable2_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMarks2_B.Text) * Convert.ToInt32(txtQNo2_B.Text)) + (Convert.ToInt32(txtEachQMarks2.Text) * Convert.ToInt32(txtQNo2.Text)) < 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks2.Text) * Convert.ToInt32(txtQNo2.Text);
                    MessageBox.Show(difference + " Mark Is Remaining .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMarks2_B.Text) * Convert.ToInt32(txtQNo2_B.Text)) + (Convert.ToInt32(txtEachQMarks2.Text) * Convert.ToInt32(txtQNo2.Text)) > 10)
                {
                    int difference = ((Convert.ToInt32(txtEachQMarks2.Text) * Convert.ToInt32(txtQNo2.Text) + Convert.ToInt32(txtEachQMarks2_B.Text) * Convert.ToInt32(txtQNo2_B.Text))) - Convert.ToInt32(txtEachSectionMarks.Text);
                    MessageBox.Show(difference + " Mark Is More Than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag2_B = 2;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
            }
        }

        private void btnSetQuestion3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo3.Text) <= Convert.ToInt32(txtTotalAvailable3.Text))
            {
                if (Convert.ToInt32(txtEachQMarks3.Text) * Convert.ToInt32(txtQNo3.Text) > 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks3.Text) * Convert.ToInt32(txtQNo3.Text);
                    MessageBox.Show(difference + " Mark Is More Than 20 .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag3 = 3;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
            }
        }

        private void btnSetQuestion3_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo3_B.Text) <= Convert.ToInt32(txtTotalAvailable3_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMarks3_B.Text) * Convert.ToInt32(txtQNo3_B.Text)) + (Convert.ToInt32(txtEachQMarks3.Text) * Convert.ToInt32(txtQNo3.Text)) < 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks3.Text) * Convert.ToInt32(txtQNo3.Text);
                    MessageBox.Show(difference + " Mark Is Remaining .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMarks3_B.Text) * Convert.ToInt32(txtQNo3_B.Text)) + (Convert.ToInt32(txtEachQMarks3.Text) * Convert.ToInt32(txtQNo3.Text)) > 10)
                {
                    int difference = ((Convert.ToInt32(txtEachQMarks3.Text) * Convert.ToInt32(txtQNo3.Text) + Convert.ToInt32(txtEachQMarks3_B.Text) * Convert.ToInt32(txtQNo3_B.Text))) - Convert.ToInt32(txtEachSectionMarks.Text);
                    MessageBox.Show(difference + " Mark Is More Than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag3_B = 3;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
            }
        }

        private void btnSetQuestion4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo4.Text) <= Convert.ToInt32(txtTotalAvailable4.Text))
            {
                if (Convert.ToInt32(txtEachQMarks4.Text) * Convert.ToInt32(txtQNo4.Text) > 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks4.Text) * Convert.ToInt32(txtQNo4.Text);
                    MessageBox.Show(difference + " Mark Is More Than 10.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag4 = 4;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
            }
        }

        private void btnSetQuestion4_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo4_B.Text) <= Convert.ToInt32(txtTotalAvailable4_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMarks4_B.Text) * Convert.ToInt32(txtQNo4_B.Text)) + (Convert.ToInt32(txtEachQMarks4.Text) * Convert.ToInt32(txtQNo4.Text)) < 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks4.Text) * Convert.ToInt32(txtQNo4.Text);
                    MessageBox.Show(difference + " Mark Is Remaining .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMarks4_B.Text) * Convert.ToInt32(txtQNo4_B.Text)) + (Convert.ToInt32(txtEachQMarks4.Text) * Convert.ToInt32(txtQNo4.Text)) > 10)
                {
                    int difference = ((Convert.ToInt32(txtEachQMarks4.Text) * Convert.ToInt32(txtQNo4.Text) + Convert.ToInt32(txtEachQMarks4_B.Text) * Convert.ToInt32(txtQNo4_B.Text))) - Convert.ToInt32(txtEachSectionMarks.Text);
                    MessageBox.Show(difference + " Mark Is More Than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag4_B = 4;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
            }
        }

        private void btnSetQuestion5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo5.Text) <= Convert.ToInt32(txtTotalAvailable5.Text))
            {
                if (Convert.ToInt32(txtEachQMarks5.Text) * Convert.ToInt32(txtQNo5.Text) > 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks5.Text) * Convert.ToInt32(txtQNo5.Text);
                    MessageBox.Show(difference + " Mark Is More Than 10 .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag5 = 5;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
            }
        }

        private void btnSetQuestion5_B_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtQNo5_B.Text) <= Convert.ToInt32(txtTotalAvailable5_B.Text))
            {
                if ((Convert.ToInt32(txtEachQMarks5_B.Text) * Convert.ToInt32(txtQNo5_B.Text)) + (Convert.ToInt32(txtEachQMarks5.Text) * Convert.ToInt32(txtQNo5.Text)) < 10)
                {
                    int difference = Convert.ToInt32(txtEachSectionMarks.Text) - Convert.ToInt32(txtEachQMarks5.Text) * Convert.ToInt32(txtQNo5.Text);
                    MessageBox.Show(difference + " Mark Is Remaining .", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if ((Convert.ToInt32(txtEachQMarks5_B.Text) * Convert.ToInt32(txtQNo5_B.Text)) + (Convert.ToInt32(txtEachQMarks5.Text) * Convert.ToInt32(txtQNo5.Text)) > 10)
                {
                    int difference = ((Convert.ToInt32(txtEachQMarks5.Text) * Convert.ToInt32(txtQNo5.Text) + Convert.ToInt32(txtEachQMarks5_B.Text) * Convert.ToInt32(txtQNo5_B.Text))) - Convert.ToInt32(txtEachSectionMarks.Text);
                    MessageBox.Show(difference + " Mark Is More Than Section Mark.", "Section", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    flag5_B = 5;
                }
            }
            else
            {
                MessageBox.Show("Sorry!!! You can not add more than available Questions.");
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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

                txtTotalAvailable.Text = count.ToString();
                txtEachQMarks.Text = QueMark.ToString();
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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

                txtTotalAvailable2.Text = count.ToString();
                txtEachQMarks2.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

                txtTotalAvailable2_B.Text = count.ToString();
                txtEachQMarks2_B.Text = QueMark.ToString();
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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

                txtTotalAvailable3.Text = count.ToString();
                txtEachQMarks3.Text = QueMark.ToString();
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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

                txtTotalAvailable3_B.Text = count.ToString();
                txtEachQMarks3_B.Text = QueMark.ToString();
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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

                txtTotalAvailable4.Text = count.ToString();
                txtEachQMarks4.Text = QueMark.ToString();
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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

                txtTotalAvailable4_B.Text = count.ToString();
                txtEachQMarks4_B.Text = QueMark.ToString();
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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

                txtTotalAvailable5.Text = count.ToString();
                txtEachQMarks5.Text = QueMark.ToString();
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
                if (QType == "VSA")
                    QueMark = 1;
                else if (QType == "SA")
                    QueMark = 2;
                else if (QType == "BA")
                    QueMark = 3;
                else if (QType == "LA")
                    QueMark = 5;
                else if (QType == "VLA")
                    QueMark = 10;

                txtTotalAvailable5_B.Text = count.ToString();
                txtEachQMarks5_B.Text = QueMark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }

        private void btnSection_1_Click(object sender, EventArgs e)
        {
            pnlSection1.Visible = true;
            pnlSection2.Visible = false;
            pnlSection3.Visible = false;
            pnlSection4.Visible = false;
            pnlSection5.Visible = false;
        }

        private void btnSection_2_Click(object sender, EventArgs e)
        {
            if (flag == 1 || flag_B == 1)
            {
                pnlSection1.Visible = false;
                pnlSection2.Visible = true;
                pnlSection3.Visible = false;
                pnlSection4.Visible = false;
                pnlSection5.Visible = false;
            }
            else
            {
                MessageBox.Show("Complete Section - 1 first.");
            }
        }

        private void btnSection_3_Click(object sender, EventArgs e)
        {
            if (flag2 == 2 || flag2_B == 2)
            {
                pnlSection1.Visible = false;
                pnlSection2.Visible = false;
                pnlSection3.Visible = true;
                pnlSection4.Visible = false;
                pnlSection5.Visible = false;
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
                pnlSection1.Visible = false;
                pnlSection2.Visible = false;
                pnlSection3.Visible = false;
                pnlSection4.Visible = true;
                pnlSection5.Visible = false;
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
                pnlSection1.Visible = false;
                pnlSection2.Visible = false;
                pnlSection3.Visible = false;
                pnlSection4.Visible = false;
                pnlSection5.Visible = true;
            }
            else
            {
                MessageBox.Show("Complete Section - 4 First.");
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                PdfWriter.GetInstance(document, new FileStream(@"Z:\MidSem.pdf", FileMode.Create));
                document.Open();

                string theDate = Login_info.MidExamDate;
                string subDate = theDate.Substring(0, 2);
                //font setting
                BaseFont bf = BaseFont.CreateFont(
                    BaseFont.TIMES_ROMAN,
                    BaseFont.CP1252,
                    BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 8);

                PdfPTable table = new PdfPTable(3);

                PdfPCell cell1 = new PdfPCell(new Phrase("Msc.4." + Login_info.MidSemDateOnly, font));
                cell1.Colspan = 2;
                cell1.Border = 0;
                table.AddCell(cell1);

                PdfPCell cell1_1 = new PdfPCell(new Phrase("ROLL NO.:________", font));
                cell1_1.Colspan = 1;
                cell1_1.Border = 0;
                cell1_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell1_1);

                PdfPCell cell2 = new PdfPCell(new Phrase(" GUJARAT UNIVERSITY", font));
                cell2.Colspan = 3;
                cell2.Border = 0;
                cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell2);


                PdfPCell cell3 = new PdfPCell(new Phrase("K.S.SCHOOL OF BUSINESS MANAGEMENT", font));
                cell3.Colspan = 3;
                cell3.Border = 0;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell3);


                PdfPCell cell4 = new PdfPCell(new Phrase("[FIVE YEARS FULL-TIME M.Sc INTEGRATED DEGREE COURSE]", font));
                cell4.Colspan = 3;
                cell4.Border = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell4);

                PdfPCell cell5_1 = new PdfPCell(new Phrase("MID-SEM EXAM OF SEVENTH SEMESTER OF FOURTH YEAR M.Sc.(CA&IT)", font));
                cell5_1.Colspan = 3;
                cell5_1.Border = 0;
                cell5_1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell5_1);

                string monthName = Login_info.MidExamMonth;
                string YearName = Login_info.MidExamYear;
                PdfPCell cell6 = new PdfPCell(new Phrase(monthName + ", " + YearName, font));
                cell6.Colspan = 3;
                cell6.Border = 0;
                cell6.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell6);

                string subjectName = Login_info.SelectedSubject;
                PdfPCell cell5 = new PdfPCell(new Phrase("SUBJECT :-" + subjectName, font));
                cell5.Colspan = 3;
                cell5.Border = 0;
                cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell5);

                PdfPCell cell6_1 = new PdfPCell(new Phrase("DATE :- "+theDate, font));
                cell6_1.Colspan = 1;
                cell6_1.Border = 0;
                table.AddCell(cell6_1);

                string STime, ETime;
                STime = Login_info.MidExamStart;
                ETime = Login_info.MidExamEnd;
                PdfPCell cell7 = new PdfPCell(new Phrase("TIME : " + STime + " TO " + ETime, font));
                cell7.Colspan = 1;
                cell7.Border = 0;
                cell7.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell7);

                int TotalMarks = Login_info.Total_Marks;
                PdfPCell cell8 = new PdfPCell(new Phrase("MARKS : " + TotalMarks, font));
                cell8.Colspan = 1;
                cell8.Border = 0;
                cell8.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell8);

                //blank line...
                PdfPCell blank_cell_1 = new PdfPCell(new Phrase("\n", font));
                blank_cell_1.Colspan = 3;
                blank_cell_1.Border = 0;
                blank_cell_1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(blank_cell_1);

                //Section - 1 starts from here
                if (flag == 1)
                {
                    //Qusetion header goes here for (A)
                    PdfPCell cell9 = new PdfPCell(new Phrase(txtHeader.Text, font));
                    cell9.Colspan = 2;
                    cell9.Border = 0;
                    table.AddCell(cell9);

                    //section marks goes here for (A)
                    int marks_A = Convert.ToInt32(txtEachQMarks.Text) * Convert.ToInt32(txtQNo.Text);
                    PdfPCell cell10 = new PdfPCell(new Phrase(marks_A.ToString(), font));
                    cell10.Colspan = 1;
                    cell10.Border = 0;
                    cell10.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell10);

                    //Question goes here for (A)
                    try
                    {
                        string QDLevel = cbQDifficulty.SelectedItem.ToString();
                        string QType = cbQuestionType.SelectedItem.ToString();
                        subjectName = Login_info.SelectedSubject;
                        DataTable dt = new DataTable();
                        cmd = new SqlCommand("select * from Questions where Subject_Name=@subjectName AND Q_Type=@QType AND Q_Level=@QLevel", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@subjectName", subjectName);
                        cmd.Parameters.AddWithValue("@QType", QType);
                        cmd.Parameters.AddWithValue("@QLevel", QDLevel);
                        adapt = new SqlDataAdapter(cmd);
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

                        //Question Shiffling goes here
                        Shuffler shuffler = new Shuffler();
                        shuffler.Shuffle(Qlist_A);
                        for (int i = 0; i < Convert.ToInt32(txtQNo.Text) + Convert.ToInt32(txtQoption.Text); i++)
                        {
                            PdfPCell cell11 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist_A[i].Question, font));
                            cell11.Colspan = 3;
                            cell11.Border = 0;
                            cell11.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell11);
                        }
                        con.Close();

                        for (int i = 0; i < Qlist_A.Count; i++)
                            Console.WriteLine("QList - 1 : " + Qlist_A);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.ToString());
                        throw;
                    }
                    PdfPCell blank_cell_2 = new PdfPCell(new Phrase("\n", font));
                    blank_cell_2.Colspan = 3;
                    blank_cell_2.Border = 0;
                    blank_cell_2.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(blank_cell_2);

                    if (flag_B == 1)
                    {
                        //Question header for section - 1 (B)
                        PdfPCell cell9_1 = new PdfPCell(new Phrase(txtHeader1_B.Text, font));
                        cell9_1.Colspan = 2;
                        cell9_1.Border = 0;
                        table.AddCell(cell9_1);

                        //section marks goes here for (B)
                        int marks_B = Convert.ToInt32(txtEachQMarks.Text) * Convert.ToInt32(txtQNo1_B.Text);
                        PdfPCell cell10_1 = new PdfPCell(new Phrase(marks_B.ToString(), font));
                        cell10_1.Colspan = 1;
                        cell10_1.Border = 0;
                        cell10_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell10_1);

                        //Question goes here for (B)
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
                                PdfPCell cell11 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist_B[i].Question, font));
                                cell11.Colspan = 3;
                                cell11.Border = 0;
                                cell11.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell11);
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
                PdfPCell blank_cell_2_1 = new PdfPCell(new Phrase("\n", font));
                blank_cell_2_1.Colspan = 3;
                blank_cell_2_1.Border = 0;
                blank_cell_2_1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(blank_cell_2_1);

                //Question for Section - 2 Paper goes here
                if (flag2 == 2)
                {
                    //Question header goes here - (A)
                    PdfPCell cell12 = new PdfPCell(new Phrase(txtHeader2.Text, font));
                    cell12.Colspan = 2;
                    cell12.Border = 0;
                    table.AddCell(cell12);

                    //Section marks goes here - (A)
                    int marks2_A = Convert.ToInt32(txtEachQMarks2.Text) * Convert.ToInt32(txtQNo2.Text);
                    PdfPCell cell13 = new PdfPCell(new Phrase(marks2_A.ToString(), font));
                    cell13.Colspan = 1;
                    cell13.Border = 0;
                    cell13.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell13);

                    //Question goes here - (A)
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
                            PdfPCell cell14 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist2[i].Question, font));
                            cell14.Colspan = 3;
                            cell14.Border = 0;
                            cell14.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell14);
                        }

                        for (int i = 0; i < Qlist2.Count; i++)
                            Console.WriteLine("Qlist - 2 : " + Qlist2[i].Q_Id);
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.ToString());
                        throw;
                    }
                    //blank line...
                    PdfPCell Blank_cell_3 = new PdfPCell(new Phrase("\n", font));
                    Blank_cell_3.Colspan = 3;
                    Blank_cell_3.Border = 0;
                    Blank_cell_3.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(Blank_cell_3);

                    if (flag2_B == 2)
                    {
                        //Question header goes here - (B)
                        PdfPCell cell12_1 = new PdfPCell(new Phrase(txtHeader2_B.Text, font));
                        cell12_1.Colspan = 2;
                        cell12_1.Border = 0;
                        table.AddCell(cell12_1);

                        //section mark goes here - (B)
                        int marks2_B = Convert.ToInt32(txtEachQMarks2_B.Text) * Convert.ToInt32(txtQNo2_B);
                        PdfPCell cell13_1 = new PdfPCell(new Phrase(marks2_B.ToString(), font));
                        cell13_1.Colspan = 1;
                        cell13_1.Border = 0;
                        cell13_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell13_1);

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
                            for (int i = 0; i < Convert.ToInt32(txtQNo2_B.Text) * Convert.ToInt32(txtQoption2_B.Text); i++)
                            {
                                PdfPCell cell14 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist2_B[i].Question, font));
                                cell14.Colspan = 3;
                                cell14.Border = 0;
                                cell14.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell14);
                            }

                            for (int i = 0; i < Qlist2_B.Count; i++)
                                Console.WriteLine("Qlist - 2 : " + Qlist2_B[i].Q_Id);
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
                PdfPCell Blank_cell_3_1 = new PdfPCell(new Phrase("\n", font));
                Blank_cell_3_1.Colspan = 3;
                Blank_cell_3_1.Border = 0;
                Blank_cell_3_1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(Blank_cell_3_1);

                //Question of Section - 3 goes here
                if (flag3 == 3)
                {
                    //Question header goes here - (A)
                    PdfPCell cell15 = new PdfPCell(new Phrase(txtHeader3.Text, font));
                    cell15.Colspan = 2;
                    cell15.Border = 0;
                    table.AddCell(cell15);

                    //Question header goes here - (A)
                    int marks3_A = Convert.ToInt32(txtEachQMarks3.Text) * Convert.ToInt32(txtQNo3.Text);
                    PdfPCell cell16 = new PdfPCell(new Phrase(marks3_A.ToString(), font));
                    cell16.Colspan = 1;
                    cell16.Border = 0;
                    cell16.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell16);

                    //Question goes here - (A)
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
                            PdfPCell cell17 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist3[i].Question, font));
                            cell17.Colspan = 3;
                            cell17.Border = 0;
                            cell17.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell17);
                        }

                        for (int i = 0; i < Qlist3.Count; i++)
                            Console.WriteLine("Qlist - 3 : " + Qlist3[i].Q_Id);
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.ToString());
                        throw;
                    }

                    //blank line...
                    PdfPCell Blank_cell_4 = new PdfPCell(new Phrase("\n", font));
                    Blank_cell_4.Colspan = 3;
                    Blank_cell_4.Border = 0;
                    Blank_cell_4.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(Blank_cell_4);

                    if (flag3_B == 3)
                    {
                        //Question header goes here - (B)
                        PdfPCell cell15_1 = new PdfPCell(new Phrase(txtHeader3_B.Text, font));
                        cell15_1.Colspan = 2;
                        cell15_1.Border = 0;
                        table.AddCell(cell15_1);

                        //Section marks goes here - (B)
                        int marks3_B = Convert.ToInt32(txtEachQMarks3_B.Text) * Convert.ToInt32(txtQNo3_B.Text);
                        PdfPCell cell16_1 = new PdfPCell(new Phrase(marks3_B.ToString(), font));
                        cell16_1.Colspan = 1;
                        cell16_1.Border = 0;
                        cell16_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell16_1);

                        //Question goes here - (B)
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
                                PdfPCell cell17 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist3_B[i].Question, font));
                                cell17.Colspan = 3;
                                cell17.Border = 0;
                                cell17.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell17);
                            }

                            for (int i = 0; i < Qlist3_B.Count; i++)
                                Console.WriteLine("Qlist - 3 : " + Qlist3_B[i].Q_Id);
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
                PdfPCell Blank_cell_4_1 = new PdfPCell(new Phrase("\n", font));
                Blank_cell_4_1.Colspan = 3;
                Blank_cell_4_1.Border = 0;
                Blank_cell_4_1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(Blank_cell_4_1);

                //Question of Section - 4 Paper goes here
                if (flag4 == 4)
                {
                    //Question header goes here - (A)
                    PdfPCell cell18 = new PdfPCell(new Phrase(txtHeader4.Text, font));
                    cell18.Colspan = 2;
                    cell18.Border = 0;
                    table.AddCell(cell18);

                    //section marks goes here - (A)
                    int marks4_A = Convert.ToInt32(txtEachQMarks4.Text) * Convert.ToInt32(txtQNo4.Text);
                    PdfPCell cell19 = new PdfPCell(new Phrase(marks4_A.ToString(), font));
                    cell19.Colspan = 1;
                    cell19.Border = 0;
                    cell19.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell19);

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

                            PdfPCell cell20 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist4[i].Question, font));
                            cell20.Colspan = 3;
                            cell20.Border = 0;
                            cell20.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell20);
                        }

                        for (int i = 0; i < Qlist4.Count; i++)
                            Console.WriteLine("QList - 4 : " + Qlist4[i].Q_Id);
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.ToString());
                        throw;
                    }

                    //blank line...
                    PdfPCell Blank_cell_5 = new PdfPCell(new Phrase("\n", font));
                    Blank_cell_5.Colspan = 3;
                    Blank_cell_5.Border = 0;
                    Blank_cell_5.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(Blank_cell_5);

                    if (flag4_B == 4)
                    {
                        //question header goes here - (B)
                        PdfPCell cell18_1 = new PdfPCell(new Phrase(txtHeader4_B.Text, font));
                        cell18_1.Colspan = 2;
                        cell18_1.Border = 0;
                        table.AddCell(cell18_1);

                        //section marks goes here - (B)
                        int marks4_B = Convert.ToInt32(txtEachQMarks4_B.Text) * Convert.ToInt32(txtQNo4_B.Text);
                        PdfPCell cell19_1 = new PdfPCell(new Phrase(marks4_B.ToString(), font));
                        cell19_1.Colspan = 1;
                        cell19_1.Border = 0;
                        cell19_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell19_1);

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
                                PdfPCell cell20 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist4_B[i].Question, font));
                                cell20.Colspan = 3;
                                cell20.Border = 0;
                                cell20.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell20);
                            }

                            for (int i = 0; i < Qlist4_B.Count; i++)
                                Console.WriteLine("Qlist - 4 : " + Qlist4_B[i].Q_Id);
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
                PdfPCell Blank_cell_5_1 = new PdfPCell(new Phrase("\n", font));
                Blank_cell_5_1.Colspan = 3;
                Blank_cell_5_1.Border = 0;
                Blank_cell_5_1.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(Blank_cell_5_1);

                //Question of Section - 5 goes here
                if (flag5 == 5)
                {
                    //question header goes here - (A)
                    PdfPCell cell21 = new PdfPCell(new Phrase(txtHeader5.Text, font));
                    cell21.Colspan = 2;
                    cell21.Border = 0;
                    table.AddCell(cell21);

                    //section marks goes here - (A)

                    int marks5_A = Convert.ToInt32(txtEachQMarks5.Text) * Convert.ToInt32(txtQNo5.Text);
                    PdfPCell cell22 = new PdfPCell(new Phrase(marks5_A.ToString(), font));
                    cell22.Colspan = 1;
                    cell22.Border = 0;
                    cell22.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cell22);

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

                            PdfPCell cell23 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist5[i].Question, font));
                            cell23.Colspan = 3;
                            cell23.Border = 0;
                            cell23.HorizontalAlignment = Element.ALIGN_LEFT;
                            table.AddCell(cell23);
                        }
                        for (int i = 0; i < Qlist5.Count; i++)
                            Console.WriteLine("QList - 5 : " + Qlist5[i].Q_Id);
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.ToString());
                        throw;
                    }

                    //blank line...
                    PdfPCell Blank_cell_6 = new PdfPCell(new Phrase("\n", font));
                    Blank_cell_6.Colspan = 3;
                    Blank_cell_6.Border = 0;
                    Blank_cell_6.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(Blank_cell_6);

                    if (flag5_B == 5)
                    {
                        //question header goes here - (B)
                        PdfPCell cell21_1 = new PdfPCell(new Phrase(txtHeader5_B.Text, font));
                        cell21_1.Colspan = 2;
                        cell21_1.Border = 0;
                        table.AddCell(cell21_1);

                        //section marks goes here - (B)
                        int marks5_B = Convert.ToInt32(txtEachQMarks5_B.Text) * Convert.ToInt32(txtQNo5_B.Text);
                        PdfPCell cell22_1 = new PdfPCell(new Phrase(marks5_B.ToString(), font));
                        cell22_1.Colspan = 1;
                        cell22_1.Border = 0;
                        cell22_1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell22_1);

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
                                PdfPCell cell23 = new PdfPCell(new Phrase("(" + (i + 1) + ")" + Qlist5_B[i].Question, font));
                                cell23.Colspan = 3;
                                cell23.Border = 0;
                                cell23.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(cell23);
                            }
                            for (int i = 0; i < Qlist5_B.Count; i++)
                                Console.WriteLine("Qlist - 5 : " + Qlist5_B[i].Q_Id);
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error : " + ex.ToString());
                            throw;
                        }
                    }
                }
                //Global list Display
                for (int i = 0; i < GlobalList.Count; i++)
                    Console.WriteLine("Global List : " + GlobalList[i].Q_Id);

                document.Add(table);
                document.Close();
                this.Hide();


                MidSem_Paper_Preview msp = new MidSem_Paper_Preview();
                msp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.ToString());
                throw;
            }
        }
    }
}
