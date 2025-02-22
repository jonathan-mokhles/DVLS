namespace DVLD
{
    partial class IssueDriverLicensecs
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
            this.localLicenseApplicationInfo1 = new DVLD.LocalLicenseApplicationInfo();
            this.btnIssue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // localLicenseApplicationInfo1
            // 
            this.localLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.localLicenseApplicationInfo1.Name = "localLicenseApplicationInfo1";
            this.localLicenseApplicationInfo1.Size = new System.Drawing.Size(764, 345);
            this.localLicenseApplicationInfo1.TabIndex = 1;
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(582, 363);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(105, 40);
            this.btnIssue.TabIndex = 2;
            this.btnIssue.Text = "issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // IssueDriverLicensecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 422);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.localLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IssueDriverLicensecs";
            this.Text = "IssueDriverLicensecs";
            this.ResumeLayout(false);

        }

        #endregion

        private LocalLicenseApplicationInfo localLicenseApplicationInfo1;
        private System.Windows.Forms.Button btnIssue;
    }
}