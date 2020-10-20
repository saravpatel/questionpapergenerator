namespace QPG_AI
{
    partial class MidSem_Paper_Preview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MidSem_Paper_Preview));
            this.mid_paper_preview = new AxAcroPDFLib.AxAcroPDF();
            this.BtnPreview = new System.Windows.Forms.Button();
            this.SFD_Paper = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mid_paper_preview)).BeginInit();
            this.SuspendLayout();
            // 
            // mid_paper_preview
            // 
            this.mid_paper_preview.Enabled = true;
            this.mid_paper_preview.Location = new System.Drawing.Point(0, -1);
            this.mid_paper_preview.Name = "mid_paper_preview";
            this.mid_paper_preview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mid_paper_preview.OcxState")));
            this.mid_paper_preview.Size = new System.Drawing.Size(1346, 622);
            this.mid_paper_preview.TabIndex = 1;
            // 
            // BtnPreview
            // 
            this.BtnPreview.Font = new System.Drawing.Font("Georgia", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreview.Location = new System.Drawing.Point(733, 642);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(237, 58);
            this.BtnPreview.TabIndex = 2;
            this.BtnPreview.Text = "Back To Previous";
            this.BtnPreview.UseVisualStyleBackColor = true;
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // MidSem_Paper_Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1347, 724);
            this.Controls.Add(this.BtnPreview);
            this.Controls.Add(this.mid_paper_preview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MidSem_Paper_Preview";
            this.Text = "MidSem_Paper_Preview";
            ((System.ComponentModel.ISupportInitialize)(this.mid_paper_preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal AxAcroPDFLib.AxAcroPDF mid_paper_preview;
        private System.Windows.Forms.Button BtnPreview;
        private System.Windows.Forms.SaveFileDialog SFD_Paper;
    }
}