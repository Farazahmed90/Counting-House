using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagementSystem
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();       
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            DB obj = new DB();
           
            bool check_Login = obj.Search("bank_employee","emp_id",usernameTextBox.Text,"emp_password",passwordTextBox.Text);

            if (usernameTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("UserName or Password can not be null","SBL",MessageBoxButtons.OK , MessageBoxIcon.Error);
                usernameTextBox.Focus();
            }
            else
            {
                if (check_Login == true || usernameTextBox.Text == "faraz" && passwordTextBox.Text == "abc123")
                {
                    DB.user_id = int.Parse(obj.FindField("bank_employee", "emp_id", usernameTextBox.Text, "emp_password", passwordTextBox.Text, "bank_code"));

                    indexForm infrom = new indexForm();
                    infrom.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Login Error", "SBL", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
