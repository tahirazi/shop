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
    public partial class Products : Form
    {
        public static string category;
        public static string company;
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlCommand cmd=null;
        DataTable dt = new DataTable();
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            FillCombo();
        }
        private void Reset()
        {
            txtProductName.Text = "";
            cmbCompany.Text = "";
            cmbCategory.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtProductName.Focus();
        }
        public void FillCombo()
        {
            try
            {
                con.Open();
                string ct = "select RTRIM(category_name) from category order by category_name";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCategory.Items.Add(rdr[0]);
                }
                con.Close();
                con.Open();
                string ct1 = "select RTRIM(company_name) from Company order by company_name";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCompany.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text == "")
            {
                MessageBox.Show("Please enter product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductName.Focus();
                return;
            }
            if (cmbCategory.Text == "")
            {
                MessageBox.Show("Please select category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategory.Focus();
                return;
            }
            if (cmbCompany.Text == "")
            {
                MessageBox.Show("Please select company", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCompany.Focus();
                return;
            }
            try
            {
                con.Open();
                string ct = "select product_name from product where product_name='" + txtProductName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Product Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProductName.Text = "";
                    txtProductName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                        con.Close();
                    }
                    return;
                }
                rdr.Close();
                string cb = "insert into product(product_name,category_name,company_name) VALUES ('" + txtProductName.Text + "','" + cmbCategory.Text + "','" + cmbCompany.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProductName.Text = "";
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            category = cmbCategory.Text;
            Product_Record frm = new Product_Record();
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
            //frm.GetData();
            this.Hide();
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con.Open();
                string cq = "delete from product where product_name='" + txtProductName.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string cb = "update product set product_name='" + txtProductName.Text + "',category_name='" + cmbCategory.Text + "', company_name='" + cmbCompany.Text + "' where product_name='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void Products_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.products = 0;
        }
    }
}
