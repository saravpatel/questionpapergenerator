namespace QPG_AI
{
    partial class Final_Paper_Preview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Final_Paper_Preview));
            this.FinalPreview = new AxAcroPDFLib.AxAcroPDF();
            this.BtnPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FinalPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // FinalPreview
            // 
            this.FinalPreview.Enabled = true;
            this.FinalPreview.Location = new System.Drawing.Point(0, 0);
            this.FinalPreview.Name = "FinalPreview";
            this.FinalPreview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FinalPreview.OcxState")));
            this.FinalPreview.Size = new System.Drawing.Size(1345, 619);
            this.FinalPreview.TabIndex = 0;
            // 
            // BtnPreview
            // 
            this.BtnPreview.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreview.Location = new System.Drawing.Point(565, 647);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(237, 58);
            this.BtnPreview.TabIndex = 1;
            this.BtnPreview.Text = "Back To Previous";
            this.BtnPreview.UseVisualStyleBackColor = true;
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // Final_Paper_Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 741);
            this.Controls.Add(this.BtnPreview);
            this.Controls.Add(this.FinalPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Final_Paper_Preview";
            this.Text = "Final_Paper_Preview";
            ((System.ComponentModel.ISupportInitialize)(this.FinalPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF FinalPreview;
        private System.Windows.Forms.Button BtnPreview;
    }
}