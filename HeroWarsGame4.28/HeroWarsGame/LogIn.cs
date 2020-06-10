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
    public partial class LogIn : Form
    {
        public Users[] test;
        public LogIn()
        {
            InitializeComponent();

            using (StreamReader readNames = File.OpenText(@"D:\\Users.txt"))
            {
                int sizeOfTable = 0;
                while (!readNames.EndOfStream)
                {
                    string line = readNames.ReadLine();
                    sizeOfTable++;
                }
                test = new Users[sizeOfTable];
            }


            using (StreamReader readNames = File.OpenText(@"D:\\Users.txt"))
            {
                int tILL = test.Length;
                while (!readNames.EndOfStream)
                {
                    string line = readNames.ReadLine();
                    string[] info = line.Split(',');

                    string username = info[0];
                    string password = info[1];

                    if (test.Any(o => o == null) && test.Any(o => o != null))
                    {
                        var bezNulls = test.Skip(tILL).ToArray();
                        test = bezNulls;
                        var Idi = test.SkipWhile(o => o.Name == null).Max(o => o.Id);


                        var newPeopless = new Users[]
                        {
                new Users{ Id = Idi + 1, Name = username, Password = password }
                        };

                        test = test.Concat(newPeopless).ToArray();

                    }
                    else if (test.Any(o => o == null))
                    {
                        var newPeopless = new Users[]
                        {
                new Users{ Id = 1, Name = username, Password = password }
                        };

                        test = test.Concat(newPeopless).ToArray();
                    }
                    else if (test.Any(o => o != null))
                    {
                        var Idi = test.Max(o => o.Id);

                        var newPeopless = new Users[]
                        {
                new Users{ Id = Idi + 1, Name = username, Password = password }
                        };

                        test = test.Concat(newPeopless).ToArray();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text.Length == 0)
                MessageBox.Show("Enter a username!");
            else if (test.Any(o => o.Name == UsernameBox.Text))
            {
                string pass = "";
                foreach (var c in test)
                {
                    if (c.Name == UsernameBox.Text)
                    {
                        pass += c.Password;
                        break;
                    }
                }
                if (pass == PasswordBox.Text)
                {
                    MessageBox.Show("Yes!");
                }
                else if (!(pass == PasswordBox.Text))
                {
                    MessageBox.Show("No!");
                }
            }
            else if (!test.Any(o => o.Name == UsernameBox.Text))
            {
                MessageBox.Show("Not a valid username!");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration reg = new Registration();
            reg.ShowDialog();
            this.Close();
        }
    }
}
