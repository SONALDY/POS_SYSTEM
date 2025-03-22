using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore_Pos_system
{
    public class ReportDetails 
    {
        public int No { get; set; }
        public string product_name { get; set; }
        public int qty { get; set; }
        public float price { get; set; }
        public float total_amount { get { return price * qty; } }

        public ReportDetails() { }

        public ReportDetails(int no, string product_name, int qty, float price)
        {
            No = no;
            this.product_name = product_name;
            this.qty = qty;
            this.price = price;
        }
    }
}
