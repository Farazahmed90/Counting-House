using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagementSystem
{
    public partial class indexForm : Form
    {
        static string ConnString = ConfigurationManager.ConnectionStrings["BMS"].ConnectionString;
        DB db = new DB();

        public indexForm()
        {
            InitializeComponent();
            sidepanel_movement(homeButton);
            homePanel.BringToFront();
            AccDataGridView.DataSource = null;
            AccDataGridView.DataSource = db.GetData("GET_ACCOUNTS");
            db.loadBranchCodes(branchIDComboBox, branCodeLoanComboBox);
            db.loadCUSNOloan(cusnumloanComboBox, cusnumaccComboBox);
            db.loadbankcode(bnkNoempComboBox);
            db.LoadAccoutNumber(cussnumcrdComboBox);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {


            db.Updatenew();
           
            sidepanel_movement(homeButton);
            AccDataGridView.DataSource = db.GetData("GET_ACCOUNTS");
            homePanel.BringToFront();

            
        }

        

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            loginForm lgfrom = new loginForm();
            lgfrom.Show();
            this.Hide();
        }

        private void sidepanel_movement(Button button)
        {
            SidePanel.Height = button.Height;
            SidePanel.Top = button.Top;
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            sidepanel_movement(customersButton);
            CusPanel.BringToFront();
        }

        private void cussaveButton_Click(object sender, EventArgs e)
        {
            db.SaveCustomerMethod(cusnameTextBox, cusstreetTextBox, cuscityTextBox,cusprovinceTextBox);
        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            sidepanel_movement(AccountButton);
            AccountPanel.BringToFront();
        }

        private void createaccButton_Click(object sender, EventArgs e)
        {
            db.CreateAccountMethod(branchIDComboBox, cusnumaccComboBox, accbalTextBox, acctypeComboBox);
        }

        private void LoanButton_Click(object sender, EventArgs e)
        {
            sidepanel_movement(LoanButton);
            LoanPanel.BringToFront();
        }

        private void giveLoanButton_Click(object sender, EventArgs e)
        {
            db.GiveLoanMethod(branCodeLoanComboBox, LoanamTextBox, LoanTypeComboBox, cusnumloanComboBox);
        }

        

        private void crdcardButton_Click(object sender, EventArgs e)
        {
            db.InsertCreditCardMethod(cussnumcrdComboBox, dateTextBox);
        }

        private void crdcancelButton_Click(object sender, EventArgs e)
        {

        }

        private void EmpButton_Click(object sender, EventArgs e)
        {
            sidepanel_movement(EmpButton);
            EmpPanel.BringToFront();
        }

        private void ViewCreditCardButton_Click(object sender, EventArgs e)
        {
            viewForm emp = new viewForm("GET_CARD",2);
            emp.ShowDialog();
        }

        private void ViewEmpButton_Click(object sender, EventArgs e)
        {
            viewForm emp = new viewForm("GET_EMP",3);
            emp.ShowDialog();
        }

        private void AddEmployeebutton_Click(object sender, EventArgs e)
        {
            db.InsertEmpMethod(bnkNoempComboBox, EmpPassTextBox, EmpNameTextBox, EmpstrNoTextBox, EmpCityTextBox, EmpProvenceTextBox);
            ClearTextBox();
        }

        private void ClearTextBox()
        {
            bnkNoempComboBox.Text = "";
            EmpPassTextBox.Text = "";
            EmpNameTextBox.Text = "";
            EmpstrNoTextBox.Text = "";
            EmpCityTextBox.Text = "";
            EmpProvenceTextBox.Text = "";
        }

        private void ViewCustomersButton_Click(object sender, EventArgs e)
        {
            viewForm emp = new viewForm("GET_CUS",1);
            emp.ShowDialog();

        }

        private void AccDataGridView_KeyDown(object sender, KeyEventArgs e)
        {

            int select = Convert.ToInt16(AccDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected));
            int selectedcell = Convert.ToInt16(AccDataGridView.Rows[select].Cells["AccountNumber"].Value);
            if (e.KeyCode == Keys.Delete)
            {
                MessageBox.Show(""+selectedcell);
                db.DeleteMthod("GET_DELACC", selectedcell);

            }
        }

        private void ViewLoanButton_Click(object sender, EventArgs e)
        {
            viewForm emp = new viewForm("GET_LOANINFO", 0);
            emp.ShowDialog();
        }

        private void AccDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateForm up = new UpdateForm(0);
            up.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sidepanel_movement(button1);
            System.Diagnostics.Process.Start("https://www.hbl.com");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sidepanel_movement(button2);
            CreditCardPanel.BringToFront();
        }

        private void canelempbutton_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

    }
}
