namespace DVLD
{
    partial class UserControl
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
            this.TBUserName = new System.Windows.Forms.TextBox();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tap = new System.Windows.Forms.TabControl();
            this.PersonInfo = new System.Windows.Forms.TabPage();
            this.btnFind = new System.Windows.Forms.Button();
            this.tbNationalNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.chbIsActive = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbConfirm = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelFind = new System.Windows.Forms.Panel();
            this.personControl1 = new DVLD.PersonControl();
            this.tap.SuspendLayout();
            this.PersonInfo.SuspendLayout();
            this.tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panelFind.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBUserName
            // 
            this.TBUserName.Location = new System.Drawing.Point(156, 111);
            this.TBUserName.Name = "TBUserName";
            this.TBUserName.Size = new System.Drawing.Size(188, 24);
            this.TBUserName.TabIndex = 11;
            // 
            // tbpassword
            // 
            this.tbpassword.Location = new System.Drawing.Point(156, 165);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.Size = new System.Drawing.Size(188, 24);
            this.tbpassword.TabIndex = 12;
            this.tbpassword.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Active ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "User ID";
            // 
            // tap
            // 
            this.tap.Controls.Add(this.PersonInfo);
            this.tap.Controls.Add(this.tabUser);
            this.tap.Location = new System.Drawing.Point(6, 25);
            this.tap.Name = "tap";
            this.tap.SelectedIndex = 0;
            this.tap.Size = new System.Drawing.Size(975, 457);
            this.tap.TabIndex = 19;
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
            this.PersonInfo.Validating += new System.ComponentModel.CancelEventHandler(this.PersonInfo_Validating);
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
            // tbNationalNo
            // 
            this.tbNationalNo.Location = new System.Drawing.Point(168, 16);
            this.tbNationalNo.Name = "tbNationalNo";
            this.tbNationalNo.Size = new System.Drawing.Size(191, 24);
            this.tbNationalNo.TabIndex = 2;
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
            // tabUser
            // 
            this.tabUser.Controls.Add(this.btnUpdate);
            this.tabUser.Controls.Add(this.chbIsActive);
            this.tabUser.Controls.Add(this.label8);
            this.tabUser.Controls.Add(this.tbConfirm);
            this.tabUser.Controls.Add(this.btnSave);
            this.tabUser.Controls.Add(this.lblUserId);
            this.tabUser.Controls.Add(this.label6);
            this.tabUser.Controls.Add(this.TBUserName);
            this.tabUser.Controls.Add(this.label4);
            this.tabUser.Controls.Add(this.tbpassword);
            this.tabUser.Controls.Add(this.label3);
            this.tabUser.Controls.Add(this.label1);
            this.tabUser.Controls.Add(this.label2);
            this.tabUser.Location = new System.Drawing.Point(4, 25);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(967, 428);
            this.tabUser.TabIndex = 1;
            this.tabUser.Text = "User Info";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(472, 320);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 36);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // chbIsActive
            // 
            this.chbIsActive.AutoSize = true;
            this.chbIsActive.Location = new System.Drawing.Point(160, 280);
            this.chbIsActive.Name = "chbIsActive";
            this.chbIsActive.Size = new System.Drawing.Size(81, 21);
            this.chbIsActive.TabIndex = 14;
            this.chbIsActive.Text = "Is Active";
            this.chbIsActive.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "confirm password";
            // 
            // tbConfirm
            // 
            this.tbConfirm.Location = new System.Drawing.Point(158, 219);
            this.tbConfirm.Name = "tbConfirm";
            this.tbConfirm.Size = new System.Drawing.Size(188, 24);
            this.tbConfirm.TabIndex = 13;
            this.tbConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.tbConfirm_Validating);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(472, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 36);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(156, 57);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(34, 21);
            this.lblUserId.TabIndex = 20;
            this.lblUserId.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "password";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            // personControl1
            // 
            this.personControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.personControl1.Location = new System.Drawing.Point(6, 81);
            this.personControl1.Name = "personControl1";
            this.personControl1.Size = new System.Drawing.Size(949, 302);
            this.personControl1.TabIndex = 0;
            // 
            // UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tap);
            this.Name = "UserControl";
            this.Size = new System.Drawing.Size(984, 515);
            this.tap.ResumeLayout(false);
            this.PersonInfo.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tabUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panelFind.ResumeLayout(false);
            this.panelFind.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TBUserName;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tap;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage PersonInfo;
        private System.Windows.Forms.Label label5;
        private PersonControl personControl1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox tbNationalNo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbConfirm;
        private System.Windows.Forms.CheckBox chbIsActive;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panelFind;
    }
}
