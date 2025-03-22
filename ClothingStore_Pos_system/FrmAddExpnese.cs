using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingStore_Pos_system
{
    public partial class FrmAddExpnese : Form
    {
        private int? _expenseId;
        public FrmAddExpnese(int? expenseId = null)
        {
            InitializeComponent();
            _expenseId = expenseId;
            if (_expenseId.HasValue)
            {
                btnUpdate.Visible = true;
                BtnaddExpense.Visible = false;
            }
            else
            {
                btnUpdate.Visible = false;
                BtnaddExpense.Visible = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void FrmAddExpnese_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnaddExpense_Click_1(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tblExpense (ExpenseType, ExpensesAmount, ExpenseDate, ExDescription) VALUES (@ExpenseType, @ExpenseAmount, @ExpenseDate, @ExDescription)";

            using (SqlCommand cmd = new SqlCommand(sql, DataConnection.DataCon))
            {
                try
                {
                    
                    if (DataConnection.DataCon.State != ConnectionState.Open)
                    {
                        DataConnection.DataCon.Open();
                    }
                    cmd.Parameters.AddWithValue("@ExpenseType", txtType.Text);
                    cmd.Parameters.AddWithValue("@ExpenseAmount", Convert.ToDecimal(txtAmount.Text)); 
                    cmd.Parameters.AddWithValue("@ExpenseDate", dtpExpenDate.Value);
                    cmd.Parameters.AddWithValue("@ExDescription", txtDesctiption.Text); 

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expense has been added successfully!");
                    FrmExpenseView frmExpenseView = (FrmExpenseView)Application.OpenForms["FrmExpenseView"];
                    if (frmExpenseView != null)
                    {
                        frmExpenseView.ExpenseData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_expenseId.HasValue) 
            {
                string query = "UPDATE tblExpense SET ExpenseType =@ExpenseType, ExpensesAmount=@ExpenseAmount, ExpenseDate=@ExpenseDate, ExDescription=@ExDescription " +
                                "WHERE ExpenseID=@ExpenseID;";
                using (SqlCommand cmd = new SqlCommand(query, DataConnection.DataCon))
                {
                    try
                    {
                        if (DataConnection.DataCon.State != ConnectionState.Open)
                        {
                            DataConnection.DataCon.Open();
                        }
                        cmd.Parameters.AddWithValue("@ExpenseType", txtType.Text);
                        cmd.Parameters.AddWithValue("@ExpenseAmount", Convert.ToDecimal(txtAmount.Text));
                        cmd.Parameters.AddWithValue("@ExpenseDate", dtpExpenDate.Value);
                        cmd.Parameters.AddWithValue("@ExDescription", txtDesctiption.Text);
                        cmd.Parameters.AddWithValue("@ExpenseID", _expenseId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Expense has been Updated successfully!");
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
 }

