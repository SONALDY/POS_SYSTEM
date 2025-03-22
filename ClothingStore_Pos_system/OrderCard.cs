using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingStore_Pos_system
{
    public partial class OrderCard : UserControl
    {
        public OrderCard()
        {
            InitializeComponent();
        }

        private void OrderCard_Load(object sender, EventArgs e)
        {

        }
        public static DataGridViewRowCollection Rows { get; set; }
        bool find = false;
        private void Updateqty(string name)
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                if (Rows[i].Cells[1].Value != null && Rows[i].Cells[1].Value.ToString() == name)
                {
                    int currentqty = int.Parse(Rows[i].Cells[2].Value.ToString());
                    float price = float.Parse(Rows[i].Cells[3].Value.ToString());
                    currentqty++;
                    Rows[i].Cells[2].Value = currentqty;
                    Rows[i].Cells[4].Value = currentqty * price;
                    find = true;
                }
            }
        }
        private void Totalamount()
        {
            float Amount = 0;
            for (int i = 0; i < Rows.Count; i++)
            {
                if (Rows[i].Cells[1].Value != null)
                {
                    Amount += float.Parse(Rows[i].Cells[4].Value.ToString());
                }
            }
            TotalAmount = Amount;
        }
        int qty = 1, no = 1;

        private void BtnaddItem_Click(object sender, EventArgs e)
        {
            Updateqty(Pro_Name);
            if (find == false)
            {
                float new_price = float.Parse(Price);
                Rows.Add(Rows.Count + 1, Pro_Name, qty, Price, new_price * qty);
                no = 1;
            }
            BtnaddItem.Text = $"Order {no++}";
            Totalamount();
        }
    }
}
