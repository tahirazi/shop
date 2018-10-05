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
    public partial class CashBook : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd = null;
        SqlDataAdapter da;
        public CashBook()
        {
            InitializeComponent();
        }

        private void CashBook_Load(object sender, EventArgs e)
        {
            GetData();
            FillCombo();
        }
        public void GetData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("SELECT date AS Date, customerid AS [Customer ID], name AS Name, receiptno AS [Receipt No.], amount AS Amount FROM cashbook", con);

                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        public void FillCombo()
        {
            try
            {
                SqlDataReader rdr;
                con.Open();
                string ct = "select (id) from customers order by id";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCustomerID.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into cashbook VALUES ('" + dtpDate.Text + "','" + Convert.ToInt32(cmbCustomerID.Text) + "','" + txtName.Text.Trim() + "','" + Convert.ToDecimal(txtAmount.Text) + "')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
                GetData();
                MessageBox.Show("Record Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void cmbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select (customer_name) from customers where id='" + Convert.ToInt32(cmbCustomerID.Text) + "'";
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable("customers");
            dt.Load(rdr);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["customer_name"].ToString();
            }
            con.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];

                dtpDate.Text = dr.Cells[0].Value.ToString();
                cmbCustomerID.Text = dr.Cells[1].Value.ToString();
                txtName.Text = dr.Cells[2].Value.ToString();
                lblReceipt.Text = dr.Cells[3].Value.ToString();
                txtReceiptNo.Text = dr.Cells[3].Value.ToString();
                txtAmount.Text = dr.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE cashbook SET date='" + dtpDate.Text + "',customerid='" + Convert.ToInt32(cmbCustomerID.Text) + "',[name]='" + txtName.Text.Trim() + "',amount='" + Convert.ToDecimal(txtAmount.Text) + "' WHERE receiptno='" + Convert.ToInt32(lblReceipt.Text) + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
                GetData();
                MessageBox.Show("Record Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM cashbook WHERE receiptno='" + Convert.ToInt32(lblReceipt.Text) + "'";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
                GetData();
                MessageBox.Show("Record Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }
    }
}
