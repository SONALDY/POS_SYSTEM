using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingStore_Pos_system
{
    internal class DataConnection
    {
        public static string Seller { get; set; }
        public static SqlConnection DataCon { get; set; }
        public static SqlConnection GetConnection()
        {
            // Replace with your actual connection string
            string connectionString = "Data Source=SONALDY;Initial Catalog=Pos_database;Integrated Security=True"; // Corrected Connection String
            return new SqlConnection(connectionString);
        }
        public static void ConnectionDB(string ip, string dbName, string user, string password)
        {
            ip = "SONALDY";
            string connectionString = "Server= " + ip + "; Database= " + dbName + "; User ID= " + user + "; Password= " + password + ";";
            DataCon = new SqlConnection(connectionString);
            DataCon.Open();
            Seller = user;

        }
    }
}
