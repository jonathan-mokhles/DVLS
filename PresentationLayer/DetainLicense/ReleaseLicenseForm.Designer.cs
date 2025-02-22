namespace DVLD.DetainLicense
{
    partial class ReleaseLicenseForm
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
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbRelease = new System.Windows.Forms.GroupBox();
            this.lblTfees = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.lblLicenseId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblAppId = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.licenseInfoControlcs1 = new DVLD.LicenseInfoControlcs();
            this.gbRelease.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRelease
            // 
            this.btnRelease.Enabled = false;
            this.btnRelease.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Location = new System.Drawing.Point(612, 694);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(97, 38);
            this.btnRelease.TabIndex = 56;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(337, 61);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(52, 45);
            this.btnFind.TabIndex = 54;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(144, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 24);
            this.textBox1.TabIndex = 53;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(194, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(337, 27);
            this.label11.TabIndex = 52;
            this.label11.Text = "Detain license Application";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 51;
            this.label5.Text = "license ID :";
            // 
            // gbRelease
            // 
            this.gbRelease.Controls.Add(this.lblTfees);
            this.gbRelease.Controls.Add(this.lblFees);
            this.gbRelease.Controls.Add(this.label13);
            this.gbRelease.Controls.Add(this.label14);
            this.gbRelease.Controls.Add(this.label6);
            this.gbRelease.Controls.Add(this.lblDetainID);
            this.gbRelease.Controls.Add(this.lblLicenseId);
            this.gbRelease.Controls.Add(this.label9);
            this.gbRelease.Controls.Add(this.label10);
            this.gbRelease.Controls.Add(this.lblUser);
            this.gbRelease.Controls.Add(this.lblDate);
            this.gbRelease.Controls.Add(this.lblAppFees);
            this.gbRelease.Controls.Add(this.label16);
            this.gbRelease.Controls.Add(this.lblAppId);
            this.gbRelease.Controls.Add(this.label19);
            this.gbRelease.Controls.Add(this.label20);
            this.gbRelease.Location = new System.Drawing.Point(20, 519);
            this.gbRelease.Name = "gbRelease";
            this.gbRelease.Size = new System.Drawing.Size(689, 169);
            this.gbRelease.TabIndex = 58;
            this.gbRelease.TabStop = false;
            this.gbRelease.Text = "Release Info";
            // 
            // lblTfees
            // 
            this.lblTfees.AutoSize = true;
            this.lblTfees.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTfees.Location = new System.Drawing.Point(537, 135);
            this.lblTfees.Name = "lblTfees";
            this.lblTfees.Size = new System.Drawing.Size(29, 18);
            this.lblTfees.TabIndex = 53;
            this.lblTfees.Text = "???";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(132, 135);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(29, 18);
            this.lblFees.TabIndex = 52;
            this.lblFees.Text = "???";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(32, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 18);
            this.label13.TabIndex = 51;
            this.label13.Text = "Fine fees :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(420, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 18);
            this.label14.TabIndex = 50;
            this.label14.Text = "Total fees :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(430, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 48;
            this.label6.Text = "Detain ID :";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(537, 31);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(29, 18);
            this.lblDetainID.TabIndex = 49;
            this.lblDetainID.Text = "???";
            // 
            // lblLicenseId
            // 
            this.lblLicenseId.AutoSize = true;
            this.lblLicenseId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseId.Location = new System.Drawing.Point(537, 66);
            this.lblLicenseId.Name = "lblLicenseId";
            this.lblLicenseId.Size = new System.Drawing.Size(29, 18);
            this.lblLicenseId.TabIndex = 42;
            this.lblLicenseId.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(424, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 18);
            this.label9.TabIndex = 41;
            this.label9.Text = "license ID :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(49, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 18);
            this.label10.TabIndex = 33;
            this.label10.Text = "App. ID :";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(537, 101);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 18);
            this.lblUser.TabIndex = 39;
            this.lblUser.Text = "???";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(132, 66);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(29, 18);
            this.lblDate.TabIndex = 38;
            this.lblDate.Text = "???";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(132, 101);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(29, 18);
            this.lblAppFees.TabIndex = 37;
            this.lblAppFees.Text = "???";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(31, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 18);
            this.label16.TabIndex = 36;
            this.label16.Text = "App. fees :";
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppId.Location = new System.Drawing.Point(132, 31);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(29, 18);
            this.lblAppId.TabIndex = 35;
            this.lblAppId.Text = "???";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(415, 101);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 18);
            this.label19.TabIndex = 32;
            this.label19.Text = "created by :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Stencil", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(9, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(111, 18);
            this.label20.TabIndex = 30;
            this.label20.Text = "Detain Date :";
            // 
            // licenseInfoControlcs1
            // 
            this.licenseInfoControlcs1.Location = new System.Drawing.Point(11, 124);
            this.licenseInfoControlcs1.Name = "licenseInfoControlcs1";
            this.licenseInfoControlcs1.Size = new System.Drawing.Size(718, 403);
            this.licenseInfoControlcs1.TabIndex = 55;
            // 
            // ReleaseLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 747);
            this.Controls.Add(this.gbRelease);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.licenseInfoControlcs1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReleaseLicenseForm";
            this.Text = "DetainLicenseForm";
            this.gbRelease.ResumeLayout(false);
            this.gbRelease.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private LicenseInfoControlcs licenseInfoControlcs1;
        private System.Windows.Forms.GroupBox gbRelease;
        private System.Windows.Forms.Label lblTfees;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label lblLicenseId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
    }
}