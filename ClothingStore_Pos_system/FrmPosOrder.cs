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
using System.Drawing.Imaging;
using Guna.UI2.WinForms;
using System.IO;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace ClothingStore_Pos_system
{
    public partial class FrmPosOrder : Form
    {
        public FrmPosOrder()
        {
            InitializeComponent();
            Viewdataorder();
        }
        public DataGridViewRowCollection Getdata()
        {
            return OrderGird.Rows;
        }
        private void Viewdataorder()
        {
            string sqlstring = $"SELECT * FROM tblProduct";
            using (SqlCommand cmd = new SqlCommand(sqlstring, DataConnection.DataCon))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                int col = 1, row = 0;
                while (reader.Read())
                {
                    OrderCard item = new OrderCard();
                    item.Pro_Name = reader["ProductName"].ToString();
                    item.Price = reader["Price"].ToString();

                    if (reader["Photo"] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])reader["Photo"];
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                           item.Photo = Image.FromStream(ms);
                        }
                    }
                    Table_laoutpanel.Controls.Add(item, col, row);
                    col++;
                    if (col == 4)
                    {
                        col = 1;
                        row++;
                    }
                }
                reader.Close();
                cmd.Dispose();
            }
            OrderCard.Rows = Getdata(); 
        }

        public void Totalamount()
        {
            float Total_Amount = 0;
            for (int i = 0; i < OrderGird.Rows.Count; i++)
            {
                if (OrderGird.Rows[i].Cells[1].Value != null)
                {
                    float price = float.Parse(OrderGird.Rows[i].Cells[4].Value.ToString());
                    Total_Amount += price;
                }
            }
        }

        private void OrderGird_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderCard item = new OrderCard();
            if (e.ColumnIndex == 5)
            {
                if (MessageBox.Show("Cancel order?", "Cancel order", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    OrderGird.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void OrderGird_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            float Amount = 0;
            for (int i = 0; i < OrderGird.Rows.Count; i++)
            {
                if (OrderGird.Rows[i].Cells[1].Value != null)
                {
                    Amount += float.Parse(OrderGird.Rows[i].Cells[4].Value.ToString());
                }
            }
            TotalAmounts.Text = Amount.ToString("$#,##0.00");
        }

        private void OrderGird_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            float Amount = 0;
            for (int i = 0; i < OrderGird.Rows.Count; i++)
            {
                if (OrderGird.Rows[i].Cells[1].Value != null)
                {
                    Amount += float.Parse(OrderGird.Rows[i].Cells[4].Value.ToString());
                }
            }
            TotalAmounts.Text = Amount.ToString("$#,##0.00");
        }

        private void OrderGird_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            float Amount = 0;
            for (int i = 0; i < OrderGird.Rows.Count; i++)
            {
                if (OrderGird.Rows[i].Cells[1].Value != null)
                {
                    Amount += float.Parse(OrderGird.Rows[i].Cells[4].Value.ToString());
                }
            }
            TotalAmounts.Text = Amount.ToString("$#,##0.00");
        }

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            List<int> Product_ID = new List<int>();
            List<string> Pro_Name = new List<string>();
            List<float> Pro_Price = new List<float>();
            List<int> Qty = new List<int>();
            List<float> Amount = new List<float>();

            for (int i = 0; i < OrderGird.Rows.Count; i++)
            {
                if (OrderGird.Rows[i].Cells[1].Value != null)
                {
                    string Name = OrderGird.Rows[i].Cells[1].Value.ToString();
                    int Quanaity = int.Parse(OrderGird.Rows[i].Cells[2].Value.ToString());
                    float Price = float.Parse(OrderGird.Rows[i].Cells[3].Value.ToString());
                    float amount = float.Parse(OrderGird.Rows[i].Cells[4].Value.ToString());
                    Pro_Name.Add(Name);
                    Qty.Add(Quanaity);
                    Pro_Price.Add(Price);
                    Amount.Add(amount);

                    string sql = $"SELECT * FROM tblProduct WHERE ProductName = '{Name}'; ";
                    using (SqlCommand command = new SqlCommand(sql, DataConnection.DataCon))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            int ID = int.Parse(reader["ProductID"].ToString());
                            Product_ID.Add(ID);
                        }
                        reader.Close();
                        command.Dispose();
                    }
                }
            }
            float Total_Amount = float.Parse(TotalAmounts.Text.Replace("$", "").Replace(",", ""));
            FrmPayment payment = new FrmPayment(Total_Amount, Product_ID, Pro_Name, Qty, Pro_Price, Amount);
            payment.PaymentCompleted += Payment_PaymentCompleted;
            payment.ShowDialog();
        }

        private void Payment_PaymentCompleted(object sender, EventArgs e)
        {
            OrderGird.Rows.Clear();
            TotalAmounts.Text = "$0.00";
        }

        private void FrmPosOrder_Load(object sender, EventArgs e)
        {
            string sql_string = $"SELECT CategoryName FROM tblCategory;";
            using (SqlCommand command = new SqlCommand(sql_string, DataConnection.DataCon))
            {
                SqlDataReader reader_data = command.ExecuteReader();
                while (reader_data.Read())
                {
                    string category = reader_data[0].ToString();
                    combocat.Items.Add(category);
                }
                reader_data.Close();
                command.Dispose();
            }
        }

        private void combocat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlcommand;
            int cat_id = combocat.SelectedIndex + 1;
            if (combocat.SelectedIndex == 6)
            {
                sqlcommand = $"SELECT * FROM tblProduct ; ";
            }
            else
            {
                sqlcommand = $"SELECT * FROM tblProduct WHERE CategoryID ='{cat_id}' ; ";
            }
            using (SqlCommand cmd = new SqlCommand(sqlcommand, DataConnection.DataCon))
            {
                Table_laoutpanel.Controls.Clear();
                SqlDataReader reader = cmd.ExecuteReader();
                int col = 1, row = 0;
                while (reader.Read())
                {
                    OrderCard item = new OrderCard();
                    item.Pro_Name = reader["ProductName"].ToString();
                    item.Price = reader["Price"].ToString();
                    if (reader["Photo"] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])reader["Photo"];
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            item.Photo = Image.FromStream(ms);
                        }
                    }
                    Table_laoutpanel.Controls.Add(item, col, row);
                    col++;
                    if (col == 4)
                    {
                        col = 1;
                        row++;
                    }
                }
                reader.Close();
                cmd.Dispose();
            }

        }
    }
}
