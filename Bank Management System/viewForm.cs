using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BankManagementSystem
{
    public partial class viewForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6VH2RJD;Initial Catalog=BMS;Integrated Security=True");
        int button;
        int selectedcell;
        DB db = new DB();
        public viewForm(string procname,int height)
        {
            InitializeComponent();

            
            button = height;
            empDataGridView.DataSource = db.GetData(procname);

            if (button == 0)
            {
                updateButton.Visible = false;
                
            }
        }

        private void empDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button == 1)
            {
                int select = Convert.ToInt16(empDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected));
                selectedcell = Convert.ToInt16(empDataGridView.Rows[select].Cells["CustomerNumber"].Value);
            }

            else if (button == 2)
            {
                int select = Convert.ToInt16(empDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected));
                selectedcell = Convert.ToInt16(empDataGridView.Rows[select].Cells["CustomerNumber"].Value);
            }
            else if (button == 3)
            {
                int select = Convert.ToInt16(empDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected));
                selectedcell = Convert.ToInt16(empDataGridView.Rows[select].Cells["EmployeeID"].Value);
                MessageBox.Show(""+selectedcell);
            }
            else if (button == 4)
            {
                int select = Convert.ToInt16(empDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected));
                selectedcell = Convert.ToInt16(empDataGridView.Rows[select].Cells["EmployeeID"].Value);
            }
            else if (button == 0)
            {
                int select = Convert.ToInt16(empDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected));
                selectedcell = Convert.ToInt16(empDataGridView.Rows[select].Cells["LoanNumber"].Value);
            }


        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            if (button == 1)
	        {
                db.DeleteMthod("GET_DELCUS",selectedcell);
		 
	        }
            else if (button == 2)
            {
                db.DeleteMthod("GET_DELCRD", selectedcell);
            }
            else if (button == 3)
            {
                db.DeleteMthod("GET_DELEMP", selectedcell);
            }
            else if (button == 0)
            {
                db.DeleteMthod("GET_DELLOAN", selectedcell);
            }
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (button == 1)
            {
                UpdateForm up = new UpdateForm(1);
                up.ShowDialog();
            }

            if (button == 2)
            {
                UpdateForm up = new UpdateForm(3);
                up.ShowDialog();
            }
            if (button == 3)
            {
                UpdateForm up = new UpdateForm(4);
                up.ShowDialog();
            }
            
        }

        private void empDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button == 1)
            {
                UpdateForm up = new UpdateForm(1);
                up.ShowDialog();
            }
            if (button == 0)
            {
                
            }

            if (button == 2)
            {
                UpdateForm up = new UpdateForm(3);
                up.ShowDialog();
            }
            if (button == 3)
            {
                UpdateForm up = new UpdateForm(4);
                up.ShowDialog();
            }

            
        }
      

        
    }
}
