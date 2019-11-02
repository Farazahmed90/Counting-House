using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagementSystem
{
    class DB
    {
        DataTable DT = new DataTable();
        static string ConnString = ConfigurationManager.ConnectionStrings["BMS"].ConnectionString;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6VH2RJD;Initial Catalog=BMS;Integrated Security=True");

        SqlDataAdapter da;
        DataSet ds;
        public static int user_id;
        String qry;


        public void update_cus(int cust_no, string name, int street_no, string city)
        {
            string s = "update customer set customer_name='" + name + "',customer_street_no='" + street_no + "',customer_city='" + city + "'where customer_id='" + cust_no + "'";
            SqlCommand com = new SqlCommand(s, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
       

        public bool Search(string tblName, string field1, string value1, string field2, string value2)
        {
            qry = "select * from " + tblName + " where " + field1 + "='" + value1 + "' and " + field2 + "='" + value2 + "'";
            da = new SqlDataAdapter(qry, con);
            ds = new DataSet();
            da.Fill(ds, "tab");
            if (ds.Tables["tab"].Rows.Count > 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FindField(string tblName, string field1, string value1, string field2, string value2, string RequiredField)
        {
            qry = "select * from " + tblName + " where " + field1 + "='" + value1 + "' and " + field2 + "='" + value2 + "'";
            da = new SqlDataAdapter(qry, con);
            ds = new DataSet();
            da.Fill(ds, "tab");
            if (ds.Tables["tab"].Rows.Count > 0)
            {
                return ds.Tables["tab"].Rows[0][RequiredField].ToString();
            }
            else
            {
                return "Not Found";
            }
        }

        public void update_acc(int acc_no, int acc_balance, string acc_type)
        {
            string s = "update account set account_balance='" + acc_balance + "',account_type='" + acc_type + "'where account_id='" + acc_no + "'";
            SqlCommand com = new SqlCommand(s, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public void update_credit(string expiry,int c_id)
        {
            string s = "update credit_card set credit_date='" + expiry + "'where credit_card_id='" + c_id + "'";
            SqlCommand com = new SqlCommand(s, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void update_emp(string name, string city,int e_id)
        {
            string s = "update bank_employee set emp_name='" + name + "',emp_city='" + city + "'where emp_id='" + e_id + "'";
            SqlCommand com = new SqlCommand(s, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
       

        public void loadbankcode(ComboBox cmb )
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("GET_BNKCODE", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmb.Items.Add(reader[0]);

                    }

                    reader.Close();
                }
            }
        }
        public DataTable GetData(string ProcName)
        {
            
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand(ProcName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DT.Load(reader);
                    
                }

            }

            return DT;
        }

        public void Updatenew()
        {
            DT.Clear();
            
        }

        public void loadBranchCodes(ComboBox cmb1 ,ComboBox cmb2)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("GET_BRANCCODE", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmb1.Items.Add(reader[0]);
                        cmb2.Items.Add(reader[0]);
                    }
                    reader.Close();
                }
            }
        }

        public void loadCUSNOloan(ComboBox cmb1 , ComboBox cmb2)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("GET_CUSNO", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmb1.Items.Add(reader[0]);
                        cmb2.Items.Add(reader[0]);
                    }
                    reader.Close();
                }
            }
        }

        public void LoadAccoutNumber(ComboBox cmb1)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("GET_AccNo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmb1.Items.Add(reader[0]);
                    }
                    reader.Close();
                }
            }
        }

        public void DeleteMthod(string method , int cell)
        {

            DialogResult question;
            question = MessageBox.Show("Confirm you want to delete this record?", "SBL Managment System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    using (SqlCommand cmd = new SqlCommand(method, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", cell);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted", "SBL Managment System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }       
        }


        public void SaveCustomerMethod(TextBox cmd1,TextBox cmd2,TextBox cmd3,TextBox cmd4)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT_CUS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", cmd1.Text);
                    cmd.Parameters.AddWithValue("@Street", cmd2.Text);
                    cmd.Parameters.AddWithValue("@City", cmd3.Text);
                    cmd.Parameters.AddWithValue("@Province", cmd4.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            MessageBox.Show("SBL Managments System", "Customer Added to DataBase Sucessfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        public void CreateAccountMethod(ComboBox cmb1 , ComboBox cmb2 , TextBox txt1, ComboBox cmb3)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT_ACCOUNT", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BranchCode", cmb1.Text);
                    cmd.Parameters.AddWithValue("@CusNum", cmb2.Text);
                    cmd.Parameters.AddWithValue("@bal", txt1.Text);
                    cmd.Parameters.AddWithValue("@acc_type", cmb3.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            MessageBox.Show("SBL Managments System", "Account create Sucessfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }

        public void GiveLoanMethod(ComboBox cmb1 ,TextBox txt1 , ComboBox cmb2 , ComboBox cmb3)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT_LOAN", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmb1.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@branchcode", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@branchcode", cmb1.Text);
                    }

                    cmd.Parameters.AddWithValue("@loanamm", txt1.Text);
                    cmd.Parameters.AddWithValue("@loantype", cmb2.Text);
                    cmd.Parameters.AddWithValue("@cusNo", cmb3.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            MessageBox.Show("SBL Managments System", "Account create Sucessfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }


        public void InsertCreditCardMethod(ComboBox cmb1 , TextBox text1)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("INSET_CCARD", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CusId", cmb1.Text);
                    cmd.Parameters.AddWithValue("@CrdData", text1.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            MessageBox.Show("SBL Managments System", "Account create Sucessfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }

        public void InsertEmpMethod(ComboBox cmb1 , TextBox txt1 , TextBox txt2 , TextBox txt3 , TextBox txt4, TextBox txt5)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT_EMP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bnkcode", cmb1.Text);
                    cmd.Parameters.AddWithValue("@pass", txt1.Text);
                    cmd.Parameters.AddWithValue("@name", txt2.Text);
                    cmd.Parameters.AddWithValue("@str", txt3.Text);
                    cmd.Parameters.AddWithValue("@city", txt4.Text);
                    cmd.Parameters.AddWithValue("@provience", txt5.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            MessageBox.Show("SBL Managments System", "Account create Sucessfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



        }


    }
}
