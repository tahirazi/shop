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
    public partial class Company : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataReader rdr;
        SqlCommand cmd;
        //DataTable dt;
        public Company()
        {
            InitializeComponent();
        }
        private void Company_Load(object sender, EventArgs e)
        {

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "")
            {
                MessageBox.Show("Please enter company name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompanyName.Focus();
                return;
            }
            try
            {
                con.Open();
                string ct = "select company_name from company where company_name='" + txtCompanyName.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Company Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCompanyName.Text = "";
                    txtCompanyName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                rdr.Close();
                string cb = "insert into company(company_name) VALUES ('" + txtCompanyName.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string cb = "update company set company_name='" + txtCompanyName.Text + "' where company_name='" + textBox1.Text + "'";
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            Company_Record frm = new Company_Record();
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
            this.Hide();
        }
        private void Reset()
        {
            txtCompanyName.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            txtCompanyName.Focus();
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con.Open();
                string cq = "delete from company where company_name='" + txtCompanyName.Text + "'";
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

        private void Company_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.company = 0;
        }
    }
}
