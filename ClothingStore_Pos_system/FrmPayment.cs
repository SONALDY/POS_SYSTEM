using Guna.UI2.WinForms.Suite;
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

namespace ClothingStore_Pos_system
{
    public partial class FrmPayment : Form
    {
        public event EventHandler PaymentCompleted;
        float Total_Amount;
        List<string> New_name;
        List<int> New_Qty;
        List<float> new_Price;
        List<float> new_Amount;
        List<int> New_pro_ID;
        public FrmPayment(float totalamount, List<int> Pro_ID, List<string> Pro_Name, List<int> Qty, List<float> Pro_Price, List<float> Amount)
        {
            New_pro_ID = Pro_ID;
            Total_Amount = totalamount;
            New_name = Pro_Name;
            New_Qty = Qty;
            new_Price = Pro_Price;
            new_Amount = Amount;
            InitializeComponent();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            txtTotalAmount.Text = Total_Amount.ToString("$##0.00");
            txtPayment.Text = Total_Amount.ToString("$##0.00");
            txtDiscountPrice.Text = "$ 0.00";
            if (comboDiscount.Items.Count > 0) 
            {
                comboDiscount.SelectedIndex = 0;
            }
        }

        private void btncloseapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            float discountprice, total_payment;
            int indext_cmbdiscount = comboDiscount.SelectedIndex;
            if (indext_cmbdiscount == 0)
            {
                txtPayment.Text = Total_Amount.ToString("$##0.00");
                txtDiscountPrice.Text = "$0.00";
                txtCashReturned.Text = "$0.00";
                btnpay.Enabled = false;
            }
            else if (indext_cmbdiscount == 1)
            {
                discountprice = (Total_Amount * 5) / 100;
                total_payment = Total_Amount - discountprice;
                txtDiscountPrice.Text = discountprice.ToString("$##0.00");
                txtPayment.Text = total_payment.ToString("$##0.00");
                txtCashReturned.Text = "$0.00";
                btnpay.Enabled = false;
            }
            else if (indext_cmbdiscount == 2)
            {
                discountprice = (Total_Amount * 10) / 100;
                total_payment = Total_Amount - discountprice;
                txtDiscountPrice.Text = discountprice.ToString("$##0.00");
                txtPayment.Text = total_payment.ToString("$##0.00");
                txtCashReturned.Text = "$0.00";
                btnpay.Enabled = false;
            }
            else if (indext_cmbdiscount == 3)
            {
                discountprice = (Total_Amount * 20) / 100;
                total_payment = Total_Amount - discountprice;
                txtDiscountPrice.Text = discountprice.ToString("$##0.00");
                txtPayment.Text = total_payment.ToString("$##0.00");
                txtCashReturned.Text = "$0.00";
                btnpay.Enabled = false;
            }
            else
            {
                discountprice = (Total_Amount * 50) / 100;
                total_payment = Total_Amount - discountprice;
                txtDiscountPrice.Text = discountprice.ToString("$##0.00");
                txtPayment.Text = total_payment.ToString("$##0.00");
                txtCashReturned.Text = "$0.00";
                btnpay.Enabled = false;
            }
        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            double discount;
            int index = comboDiscount.SelectedIndex;
            float cashrecived = float.Parse(txtCashReceived.Text);
            if (index == 0) { discount = 0; }
            else if (index == 1) { discount = 5; }
            else if (index == 2) { discount = 10; }
            else if (index == 3) { discount = 20; }
            else { discount = 50; }
            float payment = float.Parse(txtPayment.Text.Substring(1));
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss");
            string seller = DataConnection.Seller;
            string sqlcommand = "INSERT into tblOrder(OrderDate,OrderTime,Total,Discount,SellerName) values(@OrdDate, @OrdTime, @Total, @Discount, @SellerName)";
            int order_id = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlcommand, DataConnection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@OrdDate", date);
                    cmd.Parameters.AddWithValue("@OrdTime", time);
                    cmd.Parameters.AddWithValue("@Total", payment);
                    cmd.Parameters.AddWithValue("Discount", discount);
                    cmd.Parameters.AddWithValue("@SellerName", seller);
                    cmd.ExecuteNonQuery();
                }

                string sqlstetment = "SELECT MAX(OrderID) FROM tblOrder;";
                using (SqlCommand sql = new SqlCommand(sqlstetment, DataConnection.DataCon))
                {
                    SqlDataReader reader = sql.ExecuteReader();
                    if (reader.Read())
                    {
                        order_id = int.Parse(reader[0].ToString());
                    }
                    reader.Close();
                    sql.Dispose();
                }
                List<ReportDetails> list = new List<ReportDetails>();
                for (int i = 0; i < New_Qty.Count; i++)
                {
                    int ID = New_pro_ID[i];
                    string pro_name = New_name[i];
                    float price = new_Price[i];
                    int Quanitity = New_Qty[i];
                    int no = i + 1;
                    string sqlstring = $"INSERT INTO tblOrderDetail (OrderID, ProductID , QTY) " +
                    $"VALUES (@Order_ID, @Product_ID, @Quantity) ; ";
                    using (SqlCommand sqlCommand1 = new SqlCommand(sqlstring, DataConnection.DataCon))
                    {
                        sqlCommand1.Parameters.AddWithValue("@Order_ID", order_id);
                        sqlCommand1.Parameters.AddWithValue("@Product_ID", ID);
                        sqlCommand1.Parameters.AddWithValue("@Quantity", Quanitity);
                        sqlCommand1.ExecuteNonQuery();
                    }

                    string updatestock = $"UPDATE tblProduct SET QTY = QTY-{Quanitity} WHERE ProductID={ID} ;";
                    using (SqlCommand sqlCommand1 = new SqlCommand(updatestock, DataConnection.DataCon))
                    {
                        sqlCommand1.ExecuteNonQuery();
                    }
                    ReportDetails data = new ReportDetails(no, pro_name, Quanitity, price);
                    list.Add(data);

                    

                }
                Boolean condition = true;
                FrmPrint Print = new FrmPrint();
                Print.setSource(list);
                Print.setparamater(0, order_id);
                Print.setparamater(1, DataConnection.Seller);
                Print.setparamater(2, discount);
                Print.setparamater(3, cashrecived);
                if (checkbox.Checked)
                {
                    Print.ShowDialog();
                    condition = false;
                }
                else
                {
                    Print.Print(1, condition, 1, -1);
                    this.Close();
                }
                DialogResult = DialogResult.OK;
                this.Close();
                PaymentCompleted?.Invoke(this, EventArgs.Empty);
                this.Close();
                InsertIncome(order_id, payment);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertIncome(int order_id, float amount)
        {
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM tblIncome WHERE OrderID = @OrderID";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, DataConnection.DataCon))
                {
                    checkCmd.Parameters.AddWithValue("@OrderID", order_id);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0) // Only insert if no existing income
                    {
                        string insertQuery = "INSERT INTO tblIncome (Amount, IncomeDate, OrderID) VALUES (@Amount, @IncomeDate, @OrderID)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, DataConnection.DataCon))
                        {
                            insertCmd.Parameters.AddWithValue("@Amount", amount);
                            insertCmd.Parameters.AddWithValue("@IncomeDate", DateTime.Now.ToString("yyyy-MM-dd"));
                            insertCmd.Parameters.AddWithValue("@OrderID", order_id);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Income already exists for OrderID: {order_id}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert income: " + ex.Message);
            }
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            float cashrecive = float.Parse(txtCashReceived.Text);
            float cashpayment = float.Parse(txtPayment.Text.Substring(1));
            if (cashrecive < cashpayment)
            {
                btnpay.Enabled = false;
                txtCashReturned.Text = "$ 0.00";
            }
            else
            {
                float cashreturn = cashrecive - cashpayment;
                txtCashReturned.Text = cashreturn.ToString();
                btnpay.Enabled = true;
            }
        }
    }
}
