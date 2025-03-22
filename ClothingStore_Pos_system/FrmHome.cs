using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace ClothingStore_Pos_system
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            string countTotalEmp = "SELECT COUNT(*) FROM tblStaff;";
            SqlCommand s = new SqlCommand(countTotalEmp, DataConnection.DataCon);
            SqlDataReader r = s.ExecuteReader();
            while (r.Read())
            {
                string total = r[0] + "";
                label_staff.Text = total;
            }
            r.Close();
            s.Dispose();
            string countCat = "SELECT COUNT(*) FROM tblCategory;";
            SqlCommand s1 = new SqlCommand(countCat, DataConnection.DataCon);
            SqlDataReader r1 = s1.ExecuteReader();
            while (r1.Read())
            {
                string total = r1[0] + "";
                Label_cat.Text = total;
            }
            r1.Close();
            s1.Dispose();
            string countPro = "SELECT COUNT(*) FROM tblProduct;";
            SqlCommand s2 = new SqlCommand(countPro, DataConnection.DataCon);
            SqlDataReader r2 = s2.ExecuteReader();
            while (r2.Read())
            {
                string total = r2[0] + "";
                label_pro.Text = total;
            }
            r2.Close();
            s2.Dispose();
            string countCus = "SELECT COUNT(*) FROM tblCustomers;";
            SqlCommand s3 = new SqlCommand( countCus, DataConnection.DataCon);
            SqlDataReader r3 = s3.ExecuteReader();
            while (r3.Read())
            {
                string table = r3[0] + "";
                label_cus.Text = table;
            }
            r3.Close();
            s3.Dispose();

            float total_income = 0;
            string sql_income = $"SELECT SUM(Total) FROM tblOrder; ";
            using (SqlCommand command = new SqlCommand(sql_income, DataConnection.DataCon))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    total_income = float.Parse(reader[0].ToString()+"");
                    label_income.Text = total_income.ToString("$##0.00");
                }
                reader.Close();
                command.Dispose();
            }

            float total_exspense = 0;
            string sql_exspense = $"SELECT SUM(ExpensesAmount) FROM tblExpense;";
            using (SqlCommand command = new SqlCommand(sql_exspense, DataConnection.DataCon))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    total_exspense = float.Parse(reader[0].ToString());
                    label_exp.Text = total_exspense.ToString("$##0.00");
                }
                reader.Close();
                command.Dispose();
            }
            

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cmb_typereport_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime stat_date = dtp_start.Value;
            DateTime end_date = dtp_end.Value;
            if (cmb_typereport.SelectedIndex == 1)
            {
                string sqlstring = "SELECT * FROM tblExpense " +
                                   $"WHERE ExpenseDate BETWEEN '{stat_date}' AND '{end_date}';";
                using (SqlCommand cmd = new SqlCommand(sqlstring, DataConnection.DataCon))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    reportgird.ColumnHeadersVisible = true;
                    reportgird.ColumnHeadersHeight = 30;
                    reportgird.RowTemplate.Height = 30;
                    reportgird.DataSource = dt;
                    
                }
            }
            else
            {
                string sqlstring = "SELECT o.OrderID, p.ProductName, od.Qty, p.Price, o.OrderDate, o.Discount, " +
                             "((od.Qty * p.Price) * (1 - (o.Discount / 100.0))) AS Total_Payment " +
                             "FROM tblOrderDetail od " +
                             "JOIN tblProduct p ON od.ProductID = p.ProductID " +
                             "JOIN tblOrder o ON od.OrderID = o.OrderID " +
                             $"WHERE o.OrderDate BETWEEN '{stat_date}' AND '{end_date}';";
                using (SqlCommand cmd = new SqlCommand(sqlstring, DataConnection.DataCon))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    reportgird.ColumnHeadersVisible = true;
                    reportgird.ColumnHeadersHeight = 30;
                    reportgird.RowTemplate.Height = 30;
                    reportgird.DataSource = dt;
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dtp_start_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            DateTime stat_date = dtp_start.Value;
            DateTime end_date = dtp_end.Value;
            if (cmb_typereport.SelectedIndex == 1)
            {
                string sqlstring = "SELECT * FROM tblExpense " +
                                   $"WHERE ExpenseDate BETWEEN '{stat_date}' AND '{end_date}';";
                using (SqlCommand cmd = new SqlCommand(sqlstring, DataConnection.DataCon))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    reportgird.ColumnHeadersVisible = true;
                    reportgird.ColumnHeadersHeight = 30;
                    reportgird.RowTemplate.Height = 30;
                    reportgird.DataSource = dt;

                }
            }
            else
            {
                string sqlstring = "SELECT o.OrderID, p.ProductName, od.Qty, p.Price, o.OrderDate, o.Discount, " +
                             "((od.Qty * p.Price) * (1 - (o.Discount / 100.0))) AS Total_Payment " +
                             "FROM tblOrderDetail od " +
                             "JOIN tblProduct p ON od.ProductID = p.ProductID " +
                             "JOIN tblOrder o ON od.OrderID = o.OrderID " +
                             $"WHERE o.OrderDate BETWEEN '{stat_date}' AND '{end_date}';";
                using (SqlCommand cmd = new SqlCommand(sqlstring, DataConnection.DataCon))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    reportgird.ColumnHeadersVisible = true;
                    reportgird.ColumnHeadersHeight = 30;
                    reportgird.RowTemplate.Height = 30;
                    reportgird.DataSource = dt;
                }
            }

        }

        private void ExportToExcel(DataGridView dgv)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                // Title header based on combo box
                string reportTitle = cmb_typereport.SelectedIndex == 1 ? "Expense Report" : "Income Report";

                // Set title in first row
                worksheet.Cells[1, 1] = reportTitle;
                Excel.Range titleRange = worksheet.get_Range("A1", "E1");
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 18;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titleRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                titleRange.RowHeight = 30;

                // Add column headers
                for (int i = 0; i < reportgird.Columns.Count; i++)
                {
                    worksheet.Cells[2, i + 1] = reportgird.Columns[i].HeaderText;
                    Excel.Range headerCell = worksheet.Cells[2, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                }

                // Add data rows
                for (int i = 0; i < reportgird.Rows.Count; i++)
                {
                    for (int j = 0; j < reportgird.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 3, j + 1] = reportgird.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Auto-fit columns
                worksheet.Columns.AutoFit();

                // Save dialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = $"{reportTitle}_{DateTime.Now:yyyyMMdd}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Exported Successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cleanup
                workbook.Close(false);
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (reportgird.Rows.Count > 0)
            {
                ExportToExcel(reportgird);
            }
            else
            {
                MessageBox.Show("No data to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
