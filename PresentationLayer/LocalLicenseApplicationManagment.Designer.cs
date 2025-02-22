namespace DVLD
{
    partial class LocalLicenseApplicationManagment
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.msShowApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.msEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.msDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.msCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.msScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.msVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.msWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.msPracticalTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.msIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.msShowDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(60, 200);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(982, 366);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msShowApplication,
            this.msEditApplication,
            this.msDeleteApplication,
            this.toolStripSeparator3,
            this.msCancelApplication,
            this.toolStripSeparator2,
            this.msScheduleTest,
            this.toolStripSeparator1,
            this.msIssueDrivingLicense,
            this.msShowDrivingLicense});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 190);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // msShowApplication
            // 
            this.msShowApplication.Name = "msShowApplication";
            this.msShowApplication.Size = new System.Drawing.Size(214, 24);
            this.msShowApplication.Text = "Show Application";
            this.msShowApplication.Click += new System.EventHandler(this.showApplicationToolStripMenuItem_Click);
            // 
            // msEditApplication
            // 
            this.msEditApplication.Name = "msEditApplication";
            this.msEditApplication.Size = new System.Drawing.Size(214, 24);
            this.msEditApplication.Text = "Edit Application";
            // 
            // msDeleteApplication
            // 
            this.msDeleteApplication.Name = "msDeleteApplication";
            this.msDeleteApplication.Size = new System.Drawing.Size(214, 24);
            this.msDeleteApplication.Text = "Delete Application";
            this.msDeleteApplication.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(211, 6);
            // 
            // msCancelApplication
            // 
            this.msCancelApplication.Name = "msCancelApplication";
            this.msCancelApplication.Size = new System.Drawing.Size(214, 24);
            this.msCancelApplication.Text = "Cancel Application";
            this.msCancelApplication.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // msScheduleTest
            // 
            this.msScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msVisionTest,
            this.msWrittenTest,
            this.msPracticalTest});
            this.msScheduleTest.Name = "msScheduleTest";
            this.msScheduleTest.Size = new System.Drawing.Size(214, 24);
            this.msScheduleTest.Text = "Schedule Test";
            // 
            // msVisionTest
            // 
            this.msVisionTest.Enabled = false;
            this.msVisionTest.Name = "msVisionTest";
            this.msVisionTest.Size = new System.Drawing.Size(176, 26);
            this.msVisionTest.Text = "Vision test";
            this.msVisionTest.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // msWrittenTest
            // 
            this.msWrittenTest.Enabled = false;
            this.msWrittenTest.Name = "msWrittenTest";
            this.msWrittenTest.Size = new System.Drawing.Size(176, 26);
            this.msWrittenTest.Text = "Written test";
            this.msWrittenTest.Click += new System.EventHandler(this.msWrittenTest_Click);
            // 
            // msPracticalTest
            // 
            this.msPracticalTest.Enabled = false;
            this.msPracticalTest.Name = "msPracticalTest";
            this.msPracticalTest.Size = new System.Drawing.Size(176, 26);
            this.msPracticalTest.Text = "Practical test";
            this.msPracticalTest.Click += new System.EventHandler(this.msPracticalTest_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // msIssueDrivingLicense
            // 
            this.msIssueDrivingLicense.Enabled = false;
            this.msIssueDrivingLicense.Name = "msIssueDrivingLicense";
            this.msIssueDrivingLicense.Size = new System.Drawing.Size(214, 24);
            this.msIssueDrivingLicense.Text = "Issue Driving License";
            this.msIssueDrivingLicense.Click += new System.EventHandler(this.msIssueDrivingLicense_Click);
            // 
            // msShowDrivingLicense
            // 
            this.msShowDrivingLicense.Enabled = false;
            this.msShowDrivingLicense.Name = "msShowDrivingLicense";
            this.msShowDrivingLicense.Size = new System.Drawing.Size(214, 24);
            this.msShowDrivingLicense.Text = "Show driving license";
            this.msShowDrivingLicense.Click += new System.EventHandler(this.msShowDrivingLicense_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lemon", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(293, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local License Application";
            // 
            // LocalLicenseApplicationManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 598);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LocalLicenseApplicationManagment";
            this.Text = "Local License Application";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msShowApplication;
        private System.Windows.Forms.ToolStripMenuItem msCancelApplication;
        private System.Windows.Forms.ToolStripMenuItem msScheduleTest;
        private System.Windows.Forms.ToolStripMenuItem msVisionTest;
        private System.Windows.Forms.ToolStripMenuItem msWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem msPracticalTest;
        private System.Windows.Forms.ToolStripMenuItem msDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem msIssueDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem msEditApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem msShowDrivingLicense;
    }
}