using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            numCountriesAsync(100,this.lblDrivers);
            numCountriesAsync(100,this.lblicense);
            numCountriesAsync(1000,this.lblilicense);

        }

        private void numCountriesAsync(int n,Label label)
        {
            int currentNumber = 0; // Start counting from 0
            int step = 10;          // Increment step
            Timer timer = new Timer(); 

            // Set the timer interval (e.g., 50 milliseconds for smooth animation)
            timer.Interval = 50;

            timer.Tick += (sender, e) =>
            {
                currentNumber += step;

                if (currentNumber >= n)
                {
                    currentNumber = n; 
                    timer.Stop();
                }

                label.Text = currentNumber.ToString();
            };

            timer.Start();
        }

        private void userMangmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMangment userMangment = new UserMangment();
            userMangment.ShowDialog();
           
        }

        private void peopleMangmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           PeopleMangment form = new PeopleMangment();
            form.ShowDialog();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.SetMode(FormMode.View, GlobalSettings.CurrentUserID);
            form.ShowDialog();
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            form.SetMode(FormMode.Update, GlobalSettings.CurrentUserID);
            form.ShowDialog();

        }
    }
}
