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
    public partial class Returns : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataAdapter da;
        SqlCommand cmd = null;
        public Returns()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO returns VALUES ('"+Convert.ToInt32(txtConfigID.Text)+"','"+Convert.ToDecimal(txtQty.Text)+"','"+Convert.ToDecimal(txtAmount.Text)+"')";
                con.Open();
                
                cmd = new SqlCommand(query);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
                MessageBox.Show("Successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Returns_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                da = new SqlDataAdapter("SELECT returnid as [Return ID],config_id as [Product Code],quantity as Quantity,amount as Amount FROM returns", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
