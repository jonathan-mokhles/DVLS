namespace DVLD
{
    partial class LicenseInfoForm
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
            this.licenseInfoControlcs1 = new DVLD.LicenseInfoControlcs();
            this.SuspendLayout();
            // 
            // licenseInfoControlcs1
            // 
            this.licenseInfoControlcs1.Location = new System.Drawing.Point(27, 114);
            this.licenseInfoControlcs1.Name = "licenseInfoControlcs1";
            this.licenseInfoControlcs1.Size = new System.Drawing.Size(718, 454);
            this.licenseInfoControlcs1.TabIndex = 0;
            // 
            // LicenseInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.licenseInfoControlcs1);
            this.Name = "LicenseInfoForm";
            this.Text = "LicenseInfoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private LicenseInfoControlcs licenseInfoControlcs1;
    }
}