namespace DVLD
{
    partial class ApplicationLicenseForm
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
            this.title = new System.Windows.Forms.Label();
            this.localLicenseApplication1 = new DVLD.LocalLicenseApplication();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.title.Font = new System.Drawing.Font("Snap ITC", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.title.Location = new System.Drawing.Point(173, 29);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(653, 36);
            this.title.TabIndex = 4;
            this.title.Text = "New local Driving license application";
            // 
            // localLicenseApplication1
            // 
            this.localLicenseApplication1.Location = new System.Drawing.Point(24, 83);
            this.localLicenseApplication1.Name = "localLicenseApplication1";
            this.localLicenseApplication1.Size = new System.Drawing.Size(984, 488);
            this.localLicenseApplication1.TabIndex = 5;
            // 
            // ApplicationLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 583);
            this.Controls.Add(this.localLicenseApplication1);
            this.Controls.Add(this.title);
            this.Name = "ApplicationLicenseForm";
            this.Text = "ApplicationLicenseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private LocalLicenseApplication localLicenseApplication1;
    }
}