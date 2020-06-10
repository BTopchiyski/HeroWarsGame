using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HeroWarsGame
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Sign_Up_Click(object sender, EventArgs e)
        {
            try
            {
                if (UsernameBox.Text.Length < 2)
                {
                    MessageBox.Show("Please choose a longer username!");
                    throw new Exception();
                }
                if (PasswordBox.Text != RepeatPass.Text)
                {
                    MessageBox.Show("Passwords do not match!");
                    throw new Exception();
                }
                if (PasswordBox.Text.Length == 0)
                {
                    MessageBox.Show("Enter a password!");
                    throw new Exception();
                }


                using (FileStream file = new FileStream(@"D:\\Users.txt", FileMode.Append, FileAccess.Write))
                {
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine(UsernameBox.Text + "," + PasswordBox.Text);
                    sw.Close();
                }
                this.Hide();
                LogIn login = new LogIn();
                login.ShowDialog();
                this.Close();
            } 
            catch
            {

            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn login = new LogIn();
            login.ShowDialog();
            this.Close();
        }
    }
}
