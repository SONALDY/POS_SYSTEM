using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClothingStore_Pos_system
{
    public partial class FrmExpenseView : Form
    {
        public FrmExpenseView()
        {
            InitializeComponent();
        }

        private void btnOpenExpense_Click(object sender, EventArgs e)
        {
            FrmAddExpnese frmAddExpnese = new FrmAddExpnese();
            frmAddExpnese.ShowDialog(); 
        }

        public void ExpenseData()
        {
            try
            {
                using (SqlCommand s = new SqlCommand("SELECT * FROM tblExpense", DataConnection.DataCon))
                {
                    if (DataConnection.DataCon.State != ConnectionState.Open)
                    {
                        DataConnection.DataCon.Open();
                    }
                    using (SqlDataReader r = s.ExecuteReader())
                    {
                        ExpenseDataGridView.RowTemplate.Height = 40;
                        ExpenseDataGridView.Rows.Clear();

                        while (r.Read())
                        {
                            int ExpenseID = Convert.ToInt32(r["ExpenseID"].ToString());
                            string ExpenseType = r["ExpenseType"].ToString() + "";
                            string Description = r["ExDescription"].ToString()+"";
                            float Amount = Convert.ToSingle(r["ExpensesAmount"].ToString());
                            DateTime Date = r["ExpenseDate"] != DBNull.Value ? Convert.ToDateTime(r["ExpenseDate"]) : DateTime.MinValue;
                            ExpenseDataGridView.Rows.Add(ExpenseID, ExpenseType, Description, Amount, Date.ToString("MM-dd-yyyy"));
                        }
                    }
                }


            }
            catch { }
        }
        private void RetrieveExpenseData(int expenseId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblExpense WHERE ExpenseID = @ExpenseID", DataConnection.DataCon))
                {
                    if (DataConnection.DataCon.State != ConnectionState.Open)
                    {
                        DataConnection.DataCon.Open();
                    }

                    cmd.Parameters.AddWithValue("@ExpenseID", expenseId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FrmAddExpnese frmAddExpnese = new FrmAddExpnese(expenseId);

                            frmAddExpnese.txtType.Text = reader["ExpenseType"].ToString();
                            frmAddExpnese.txtAmount.Text = reader["ExpensesAmount"].ToString();
                            frmAddExpnese.dtpExpenDate.Value = Convert.ToDateTime(reader["ExpenseDate"]);
                            frmAddExpnese.txtDesctiption.Text = reader["ExDescription"].ToString();
                            reader.Close();

                            frmAddExpnese.ShowDialog();
                            
                        }
                    }
                }
                ExpenseData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving expense data: " + ex.Message);
            }
        }
        private void DeleteExpense(int expenseId)
        {
            string query = "DELETE FROM tblExpense WHERE ExpenseID = @ExpenseID";

            using (SqlCommand cmd = new SqlCommand(query, DataConnection.DataCon))
            {
                try
                {
                    if (DataConnection.DataCon.State != ConnectionState.Open)
                    {
                        DataConnection.DataCon.Open();
                    }
                    cmd.Parameters.AddWithValue("@ExpenseID", expenseId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expense has been deleted successfully!");
                    ExpenseData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void FrmExpenseView_Load(object sender, EventArgs e)
        {
            ExpenseData();
        }
        private void ExpenseDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ExpenseDataGridView.Columns[e.ColumnIndex].Name == "ExpenseEdit")
            {
                int expenseId = Convert.ToInt32(ExpenseDataGridView.Rows[e.RowIndex].Cells[0].Value);
                RetrieveExpenseData(expenseId);
            }
            if (e.RowIndex >= 0 && ExpenseDataGridView.Columns[e.ColumnIndex].Name == "ExpenseRemove")
            {
                int expenseId = Convert.ToInt32(ExpenseDataGridView.Rows[e.RowIndex].Cells[0].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this expense?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteExpense(expenseId);
                }
            }


        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            DateTime start_date = dtp_start.Value;
            DateTime end_date = dtp_end.Value;
            try
            {
                string sqlquery = "SELECT * FROM tblExpense WHERE ExpenseDate BETWEEN @startDate AND @endDate;";
                using (SqlCommand s = new SqlCommand(sqlquery, DataConnection.DataCon))
                {
                    s.Parameters.AddWithValue("@startDate", start_date);
                    s.Parameters.AddWithValue("@endDate", end_date);

                    if (DataConnection.DataCon.State != ConnectionState.Open)
                    {
                        DataConnection.DataCon.Open();
                    }

                    using (SqlDataReader r = s.ExecuteReader())
                    {
                        ExpenseDataGridView.RowTemplate.Height = 40;
                        ExpenseDataGridView.Rows.Clear();

                        while (r.Read())
                        {
                            int ExpenseID = Convert.ToInt32(r["ExpenseID"].ToString());
                            string ExpenseType = r["ExpenseType"].ToString() + "";
                            string Description = r["ExDescription"].ToString() + "";
                            float Amount = Convert.ToSingle(r["ExpensesAmount"].ToString());
                            DateTime Date = r["ExpenseDate"] != DBNull.Value ? Convert.ToDateTime(r["ExpenseDate"]) : DateTime.MinValue;
                            ExpenseDataGridView.Rows.Add(ExpenseID, ExpenseType, Description, Amount, Date.ToString("MM-dd-yyyy"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

