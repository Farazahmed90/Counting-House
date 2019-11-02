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
    public partial class UpdateForm : Form 
    {
        DB db = new DB();

        int y;
        public UpdateForm(int x)
        {
            InitializeComponent();
            y = x;
            if (x == 0)
            {
                label5.Text = "Account No";
                label1.Text = "Balance";
                label2.Text = "Account Type";
                label3.Visible = false;
                textBox3.Visible = false;
            }

            if (x == 3)
            {
                label5.Text = "Credit Card No";
                label1.Text = "Credit Date";
                label2.Visible = false;
                label3.Visible = false;
                textBox3.Visible = false;
                textBox2.Visible = false;
                
            }
            if (x == 4)
            {
                label5.Text = "Employee id";
                label2.Text = "City";
                label3.Visible = false;
                textBox3.Visible = false;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (y == 0)
            {
                db.update_acc(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox1.Text), (textBox2.Text));
                MessageBox.Show("Record update successfully");
                
            }
            

            if (y == 3)
            {
                db.update_credit(textBox1.Text,Convert.ToInt32(textBox5.Text));
                MessageBox.Show("Record update successfully");
            }
            if (y == 4)
            {
                db.update_emp(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox5.Text));
                MessageBox.Show("Record update successfully");
            }

            else
            {
                try
                {
                    db.update_cus(Convert.ToInt32(textBox5.Text), textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text);
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Record update successfully");
                }
                
                
                
                
            }
            
        }



    }
}
