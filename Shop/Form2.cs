using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Shop
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd = null;
        //SqlDataReader rdr;
        //DataTable dt;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void auto()
        {
            txtInvoiceNo.Text = "INV-" + GetUniqueKey(8);

        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            auto();
            string query = "INSERT INTO sales VALUES ('"+txtInvoiceNo.Text+"','"+dtpInvoiceDate.Text+"','"+txtCustomerName.Text+"','"+Convert.ToDecimal(txtTotal.Text)+"','"+Convert.ToDecimal(txtDiscount.Text)+"','"+Convert.ToDecimal(txtReceived.Text)+"','"+txtRemarks.Text+"')";
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            con.Close();
            MessageBox.Show("added.");
        }
    }
}
