namespace DVLD
{
    partial class InternationalLicenseInfo
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
            this.internationalLicenseControl1 = new DVLD.InternationalLicenseControl();
            this.SuspendLayout();
            // 
            // internationalLicenseControl1
            // 
            this.internationalLicenseControl1.Location = new System.Drawing.Point(32, 64);
            this.internationalLicenseControl1.Name = "internationalLicenseControl1";
            this.internationalLicenseControl1.Size = new System.Drawing.Size(700, 364);
            this.internationalLicenseControl1.TabIndex = 0;
            // 
            // InternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.internationalLicenseControl1);
            this.Name = "InternationalLicenseInfo";
            this.Text = "InternationalLicenseInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private InternationalLicenseControl internationalLicenseControl1;
    }
}