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
    public partial class Category : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataReader dr;
        DataTable dt = new DataTable();
        SqlCommand cmd;
        public Category()
        {
            InitializeComponent();
        }
        private void Category_Load(object sender, EventArgs e)
        {
            
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Please enter Category name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCategoryName.Focus();
                return;
            }
            try
            {
                con.Open();
                string ct = "select category_name from category where category_name='" + txtCategoryName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Category Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCategoryName.Text = "";
                    txtCategoryName.Focus();
                    if ((dr != null))
                    {
                        dr.Close();
                    }
                    return; 
                }
                dr.Close();
                string cb = "insert into category VALUES ('" + txtCategoryName.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete_records();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string cb = "update category set category_name='" + txtCategoryName.Text + "' where category_name='" + textBox1.Text + "'";
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
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Hide();
            Category_Record frm = new Category_Record();
            frm.Show();
            frm.GetData();
        }
        private void Reset()
        {
            txtCategoryName.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            txtCategoryName.Focus();
        }

        private void Category_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con.Open();
                string cq = "delete from category where category_name='" + txtCategoryName.Text + "'";
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

        private void Category_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.category = 0;
        }
    }
}
