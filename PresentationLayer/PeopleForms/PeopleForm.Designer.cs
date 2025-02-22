namespace DVLD
{
    partial class PeopleForm
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
            this.personControl1 = new DVLD.PersonControl();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.title.Font = new System.Drawing.Font("Snap ITC", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.title.Location = new System.Drawing.Point(327, 34);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(281, 36);
            this.title.TabIndex = 3;
            this.title.Text = "Add new preson";
            // 
            // personControl1
            // 
            this.personControl1.Location = new System.Drawing.Point(12, 73);
            this.personControl1.Name = "personControl1";
            this.personControl1.Size = new System.Drawing.Size(949, 402);
            this.personControl1.TabIndex = 4;
            // 
            // PeopleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 479);
            this.Controls.Add(this.title);
            this.Controls.Add(this.personControl1);
            this.Name = "PeopleForm";
            this.Text = "PeopleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label title;
        private PersonControl personControl1;
    }
}