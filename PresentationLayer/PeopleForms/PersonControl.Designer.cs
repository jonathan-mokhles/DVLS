namespace DVLD
{
    partial class PersonControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbfirstName = new System.Windows.Forms.TextBox();
            this.tblastName = new System.Windows.Forms.TextBox();
            this.TBNational = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ComboxContries = new System.Windows.Forms.ComboBox();
            this.RBMale = new System.Windows.Forms.RadioButton();
            this.RBFemale = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPicture = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblDelete = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Country";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date of birth";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Notional No. ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Last Name ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "First Name ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 249);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "Address";
            // 
            // tbfirstName
            // 
            this.tbfirstName.Location = new System.Drawing.Point(140, 52);
            this.tbfirstName.Name = "tbfirstName";
            this.tbfirstName.Size = new System.Drawing.Size(188, 24);
            this.tbfirstName.TabIndex = 10;
            this.tbfirstName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateRequiredField);
            // 
            // tblastName
            // 
            this.tblastName.Location = new System.Drawing.Point(467, 52);
            this.tblastName.Name = "tblastName";
            this.tblastName.Size = new System.Drawing.Size(197, 24);
            this.tblastName.TabIndex = 11;
            this.tblastName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateRequiredField);
            // 
            // TBNational
            // 
            this.TBNational.Location = new System.Drawing.Point(140, 99);
            this.TBNational.Name = "TBNational";
            this.TBNational.Size = new System.Drawing.Size(188, 24);
            this.TBNational.TabIndex = 12;
            this.TBNational.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateNationalNo);
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(467, 196);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(197, 24);
            this.tbPhone.TabIndex = 14;
            this.tbPhone.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateRequiredField);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(140, 196);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(188, 24);
            this.tbEmail.TabIndex = 15;
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(140, 249);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(524, 24);
            this.tbAddress.TabIndex = 16;
            this.tbAddress.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateRequiredField);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "Gender";
            // 
            // ComboxContries
            // 
            this.ComboxContries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboxContries.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboxContries.FormattingEnabled = true;
            this.ComboxContries.Location = new System.Drawing.Point(467, 147);
            this.ComboxContries.Name = "ComboxContries";
            this.ComboxContries.Size = new System.Drawing.Size(197, 24);
            this.ComboxContries.TabIndex = 18;
            // 
            // RBMale
            // 
            this.RBMale.AutoSize = true;
            this.RBMale.Location = new System.Drawing.Point(150, 149);
            this.RBMale.Name = "RBMale";
            this.RBMale.Size = new System.Drawing.Size(55, 21);
            this.RBMale.TabIndex = 19;
            this.RBMale.TabStop = true;
            this.RBMale.Text = "Male";
            this.RBMale.UseVisualStyleBackColor = true;
            this.RBMale.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // RBFemale
            // 
            this.RBFemale.AutoSize = true;
            this.RBFemale.Location = new System.Drawing.Point(236, 149);
            this.RBFemale.Name = "RBFemale";
            this.RBFemale.Size = new System.Drawing.Size(71, 21);
            this.RBFemale.TabIndex = 20;
            this.RBFemale.TabStop = true;
            this.RBFemale.Text = "Female";
            this.RBFemale.UseVisualStyleBackColor = true;
            this.RBFemale.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(717, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.CustomFormat = "dd/MM/yyyy";
            this.dtDateOfBirth.Location = new System.Drawing.Point(467, 103);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.Size = new System.Drawing.Size(197, 24);
            this.dtDateOfBirth.TabIndex = 22;
            this.dtDateOfBirth.Value = new System.DateTime(2025, 1, 26, 22, 18, 24, 0);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.SkyBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(655, 302);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 35);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SkyBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(655, 301);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 35);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Save";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(147, 8);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(39, 21);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 26;
            this.label7.Text = "ID : ";
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.Location = new System.Drawing.Point(758, 261);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(123, 17);
            this.lblPicture.TabIndex = 27;
            this.lblPicture.TabStop = true;
            this.lblPicture.Text = "change the picture";
            this.lblPicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPicture_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Location = new System.Drawing.Point(758, 22);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(92, 17);
            this.lblDelete.TabIndex = 28;
            this.lblDelete.TabStop = true;
            this.lblDelete.Text = "Delete picture";
            this.lblDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDelete_LinkClicked);
            // 
            // PersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtDateOfBirth);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RBFemale);
            this.Controls.Add(this.RBMale);
            this.Controls.Add(this.ComboxContries);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.TBNational);
            this.Controls.Add(this.tblastName);
            this.Controls.Add(this.tbfirstName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "PersonControl";
            this.Size = new System.Drawing.Size(949, 348);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbfirstName;
        private System.Windows.Forms.TextBox tblastName;
        private System.Windows.Forms.TextBox TBNational;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ComboxContries;
        private System.Windows.Forms.RadioButton RBMale;
        private System.Windows.Forms.RadioButton RBFemale;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtDateOfBirth;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.LinkLabel lblPicture;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel lblDelete;
    }
}
