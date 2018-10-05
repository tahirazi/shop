using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Shop
{
    public partial class Sales_Update : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd = new SqlCommand();
        public Sales_Update()
        {
            InitializeComponent();
        }

        private void Sales_Update_Load(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {

                ds = new DataSet();
                da = new SqlDataAdapter("SELECT * from sales WHERE invoice_no='"+txtInvoiceNo.Text+"'", con);
                da.Fill(ds, "sales");
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
                da.Update(ds, "sales");
                MessageBox.Show("Updated Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
