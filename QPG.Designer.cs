namespace QPG_AI
{
    partial class QPG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QPG));
            this.btn_sign_in = new System.Windows.Forms.Button();
            this.btn_sign_up = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_sign_in
            // 
            this.btn_sign_in.BackColor = System.Drawing.SystemColors.Control;
            this.btn_sign_in.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sign_in.Location = new System.Drawing.Point(509, 529);
            this.btn_sign_in.Name = "btn_sign_in";
            this.btn_sign_in.Size = new System.Drawing.Size(181, 50);
            this.btn_sign_in.TabIndex = 0;
            this.btn_sign_in.Text = "Sign In";
            this.btn_sign_in.UseVisualStyleBackColor = false;
            this.btn_sign_in.Click += new System.EventHandler(this.btn_sign_in_Click);
            // 
            // btn_sign_up
            // 
            this.btn_sign_up.BackColor = System.Drawing.SystemColors.Control;
            this.btn_sign_up.Location = new System.Drawing.Point(732, 529);
            this.btn_sign_up.Name = "btn_sign_up";
            this.btn_sign_up.Size = new System.Drawing.Size(188, 50);
            this.btn_sign_up.TabIndex = 1;
            this.btn_sign_up.Text = "sign_Up";
            this.btn_sign_up.UseVisualStyleBackColor = false;
            this.btn_sign_up.Click += new System.EventHandler(this.btn_sign_up_Click);
            // 
            // QPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QPG_AI.Properties.Resources.kssbm;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1021, 608);
            this.Controls.Add(this.btn_sign_up);
            this.Controls.Add(this.btn_sign_in);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QPG";
            this.Text = "QPG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QPG_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_sign_in;
        private System.Windows.Forms.Button btn_sign_up;
    }
}