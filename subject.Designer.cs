namespace QPG_AI
{
    partial class subject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subject));
            this.lblusername = new System.Windows.Forms.Label();
            this.btnlogout = new System.Windows.Forms.Button();
            this.dtExamTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelectSubject = new System.Windows.Forms.ComboBox();
            this.lblSelectSubject = new System.Windows.Forms.Label();
            this.dtExamDate = new System.Windows.Forms.DateTimePicker();
            this.lblExamDate = new System.Windows.Forms.Label();
            this.lblExamName = new System.Windows.Forms.Label();
            this.cbExamName = new System.Windows.Forms.ComboBox();
            this.PaperPanel = new System.Windows.Forms.Panel();
            this.btnSetPaper = new System.Windows.Forms.Button();
            this.PaperPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.BackColor = System.Drawing.Color.Transparent;
            this.lblusername.Location = new System.Drawing.Point(1183, 21);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(35, 13);
            this.lblusername.TabIndex = 0;
            this.lblusername.Text = "label1";
            // 
            // btnlogout
            // 
            this.btnlogout.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.Location = new System.Drawing.Point(1200, 65);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(75, 23);
            this.btnlogout.TabIndex = 4;
            this.btnlogout.Text = "Log Out";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // dtExamTime
            // 
            this.dtExamTime.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExamTime.Location = new System.Drawing.Point(500, 219);
            this.dtExamTime.Name = "dtExamTime";
            this.dtExamTime.Size = new System.Drawing.Size(200, 27);
            this.dtExamTime.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select Exam Time";
            // 
            // cbSelectSubject
            // 
            this.cbSelectSubject.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectSubject.FormattingEnabled = true;
            this.cbSelectSubject.Location = new System.Drawing.Point(500, 262);
            this.cbSelectSubject.Name = "cbSelectSubject";
            this.cbSelectSubject.Size = new System.Drawing.Size(405, 28);
            this.cbSelectSubject.TabIndex = 3;
            // 
            // lblSelectSubject
            // 
            this.lblSelectSubject.AutoSize = true;
            this.lblSelectSubject.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectSubject.Location = new System.Drawing.Point(268, 270);
            this.lblSelectSubject.Name = "lblSelectSubject";
            this.lblSelectSubject.Size = new System.Drawing.Size(115, 20);
            this.lblSelectSubject.TabIndex = 4;
            this.lblSelectSubject.Text = "Select Subject";
            // 
            // dtExamDate
            // 
            this.dtExamDate.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtExamDate.Location = new System.Drawing.Point(500, 186);
            this.dtExamDate.Name = "dtExamDate";
            this.dtExamDate.Size = new System.Drawing.Size(200, 27);
            this.dtExamDate.TabIndex = 2;
            // 
            // lblExamDate
            // 
            this.lblExamDate.AutoSize = true;
            this.lblExamDate.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamDate.Location = new System.Drawing.Point(268, 188);
            this.lblExamDate.Name = "lblExamDate";
            this.lblExamDate.Size = new System.Drawing.Size(142, 20);
            this.lblExamDate.TabIndex = 2;
            this.lblExamDate.Text = "Select Exam Date";
            // 
            // lblExamName
            // 
            this.lblExamName.AutoSize = true;
            this.lblExamName.Location = new System.Drawing.Point(269, 155);
            this.lblExamName.Name = "lblExamName";
            this.lblExamName.Size = new System.Drawing.Size(97, 13);
            this.lblExamName.TabIndex = 1;
            this.lblExamName.Text = "Select Exam Name";
            // 
            // cbExamName
            // 
            this.cbExamName.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExamName.FormattingEnabled = true;
            this.cbExamName.Location = new System.Drawing.Point(500, 148);
            this.cbExamName.Name = "cbExamName";
            this.cbExamName.Size = new System.Drawing.Size(195, 26);
            this.cbExamName.TabIndex = 1;
            // 
            // PaperPanel
            // 
            this.PaperPanel.AutoScroll = true;
            this.PaperPanel.Controls.Add(this.btnSetPaper);
            this.PaperPanel.Controls.Add(this.lblExamName);
            this.PaperPanel.Controls.Add(this.dtExamTime);
            this.PaperPanel.Controls.Add(this.cbSelectSubject);
            this.PaperPanel.Controls.Add(this.lblExamDate);
            this.PaperPanel.Controls.Add(this.label1);
            this.PaperPanel.Controls.Add(this.lblSelectSubject);
            this.PaperPanel.Controls.Add(this.dtExamDate);
            this.PaperPanel.Controls.Add(this.cbExamName);
            this.PaperPanel.Location = new System.Drawing.Point(180, 65);
            this.PaperPanel.Name = "PaperPanel";
            this.PaperPanel.Size = new System.Drawing.Size(996, 514);
            this.PaperPanel.TabIndex = 14;
            // 
            // btnSetPaper
            // 
            this.btnSetPaper.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPaper.Location = new System.Drawing.Point(485, 392);
            this.btnSetPaper.Name = "btnSetPaper";
            this.btnSetPaper.Size = new System.Drawing.Size(198, 52);
            this.btnSetPaper.TabIndex = 13;
            this.btnSetPaper.Text = "Set Paper";
            this.btnSetPaper.UseVisualStyleBackColor = true;
            this.btnSetPaper.Click += new System.EventHandler(this.btnSetPaper_Click);
            // 
            // subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.PaperPanel);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.lblusername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "subject";
            this.Text = "Welcome to QPG";
            this.Load += new System.EventHandler(this.subject_Load);
            this.PaperPanel.ResumeLayout(false);
            this.PaperPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.ComboBox cbExamName;
        private System.Windows.Forms.Label lblExamName;
        private System.Windows.Forms.Label lblExamDate;
        private System.Windows.Forms.DateTimePicker dtExamDate;
        private System.Windows.Forms.ComboBox cbSelectSubject;
        private System.Windows.Forms.Label lblSelectSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtExamTime;
        private System.Windows.Forms.Panel PaperPanel;
        private System.Windows.Forms.Button btnSetPaper;
    }
}