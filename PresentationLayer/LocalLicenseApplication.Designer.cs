namespace DVLD
{
    partial class LocalLicenseApplication
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tap = new System.Windows.Forms.TabControl();
            this.PersonInfo = new System.Windows.Forms.TabPage();
            this.panelFind = new System.Windows.Forms.Panel();
            this.tbNationalNo = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.personControl1 = new DVLD.PersonControl();
            this.ApplicationInfo = new System.Windows.Forms.TabPage();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tap.SuspendLayout();
            this.PersonInfo.SuspendLayout();
            this.panelFind.SuspendLayout();
            this.ApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tap
            // 
            this.tap.Controls.Add(this.PersonInfo);
            this.tap.Controls.Add(this.ApplicationInfo);
            this.tap.Location = new System.Drawing.Point(3, 19);
            this.tap.Name = "tap";
            this.tap.SelectedIndex = 0;
            this.tap.Size = new System.Drawing.Size(975, 457);
            this.tap.TabIndex = 20;
            this.tap.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tap_Selecting);
            // 
            // PersonInfo
            // 
            this.PersonInfo.Controls.Add(this.panelFind);
            this.PersonInfo.Controls.Add(this.personControl1);
            this.PersonInfo.Location = new System.Drawing.Point(4, 25);
            this.PersonInfo.Name = "PersonInfo";
            this.PersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.PersonInfo.Size = new System.Drawing.Size(967, 428);
            this.PersonInfo.TabIndex = 0;
            this.PersonInfo.Text = "Person Info";
            this.PersonInfo.UseVisualStyleBackColor = true;
            // 
            // panelFind
            // 
            this.panelFind.Controls.Add(this.tbNationalNo);
            this.panelFind.Controls.Add(this.btnFind);
            this.panelFind.Controls.Add(this.label5);
            this.panelFind.Location = new System.Drawing.Point(181, 17);
            this.panelFind.Name = "panelFind";
            this.panelFind.Size = new System.Drawing.Size(599, 53);
            this.panelFind.TabIndex = 4;
            // 
            // tbNationalNo
            // 
            this.tbNationalNo.Location = new System.Drawing.Point(168, 16);
            this.tbNationalNo.Name = "tbNationalNo";
            this.tbNationalNo.Size = new System.Drawing.Size(191, 24);
            this.tbNationalNo.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(435, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(84, 28);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "find by National No.";
            // 
            // personControl1
            // 
            this.personControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.personControl1.Location = new System.Drawing.Point(6, 81);
            this.personControl1.Name = "personControl1";
            this.personControl1.Size = new System.Drawing.Size(949, 302);
            this.personControl1.TabIndex = 0;
            // 
            // ApplicationInfo
            // 
            this.ApplicationInfo.Controls.Add(this.lblStatus);
            this.ApplicationInfo.Controls.Add(this.label9);
            this.ApplicationInfo.Controls.Add(this.cbClass);
            this.ApplicationInfo.Controls.Add(this.lblUser);
            this.ApplicationInfo.Controls.Add(this.lblDate);
            this.ApplicationInfo.Controls.Add(this.lblFees);
            this.ApplicationInfo.Controls.Add(this.label8);
            this.ApplicationInfo.Controls.Add(this.btnSave);
            this.ApplicationInfo.Controls.Add(this.lblId);
            this.ApplicationInfo.Controls.Add(this.label6);
            this.ApplicationInfo.Controls.Add(this.label4);
            this.ApplicationInfo.Controls.Add(this.label3);
            this.ApplicationInfo.Controls.Add(this.label1);
            this.ApplicationInfo.Controls.Add(this.label2);
            this.ApplicationInfo.Location = new System.Drawing.Point(4, 25);
            this.ApplicationInfo.Name = "ApplicationInfo";
            this.ApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.ApplicationInfo.Size = new System.Drawing.Size(967, 428);
            this.ApplicationInfo.TabIndex = 1;
            this.ApplicationInfo.Text = "Application Info";
            this.ApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(176, 162);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(238, 24);
            this.cbClass.TabIndex = 27;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(207, 281);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(37, 24);
            this.lblUser.TabIndex = 26;
            this.lblUser.Text = "???";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(207, 115);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 24);
            this.lblDate.TabIndex = 25;
            this.lblDate.Text = "???";
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(207, 216);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(37, 24);
            this.lblFees.TabIndex = 24;
            this.lblFees.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(52, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 24);
            this.label8.TabIndex = 23;
            this.label8.Text = "fees :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(415, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 36);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(207, 57);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(37, 24);
            this.lblId.TabIndex = 20;
            this.lblId.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(46, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "class :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = " ID : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "created by :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 14;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(675, 158);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 24);
            this.lblStatus.TabIndex = 29;
            this.lblStatus.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(527, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 24);
            this.label9.TabIndex = 28;
            this.label9.Text = "Status : ";
            // 
            // LocalLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tap);
            this.Name = "LocalLicenseApplication";
            this.Size = new System.Drawing.Size(984, 488);
            this.tap.ResumeLayout(false);
            this.PersonInfo.ResumeLayout(false);
            this.panelFind.ResumeLayout(false);
            this.panelFind.PerformLayout();
            this.ApplicationInfo.ResumeLayout(false);
            this.ApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tap;
        private System.Windows.Forms.TabPage PersonInfo;
        private System.Windows.Forms.Panel panelFind;
        private System.Windows.Forms.TextBox tbNationalNo;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label5;
        private PersonControl personControl1;
        private System.Windows.Forms.TabPage ApplicationInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label9;
    }
}
