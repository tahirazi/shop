using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Shop
{
    public partial class Config : Form
    {
        decimal price, profit, sum;
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            FillCombo();
            
        }
        public void GetData()
        {
            try
            {
                con.Open();
                string query = "SELECT category.category_name, product.product_name, config.config_id, config.product_name AS Expr1, config.features, config.price, config.sale_price, config.agentprice FROM category INNER JOIN product ON category.category_name = product.category_name INNER JOIN config ON product.product_name = config.product_name WHERE category.category_name = '"+textBox1.Text+"'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[2], rdr[3], rdr[4], rdr[5], rdr[6],rdr[7]);
                }
                rdr.Close();
                con.Close();
                //ds = new DataSet();
                //da = new SqlDataAdapter(query, con);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //da.Fill(ds, "stdBasic");
                //dataGridView1.DataSource = dt;
                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }
        public void FillCombo()
        {
            try
            {
                con.Open();
                string ct = "select RTRIM(product_name) from product order by product_name";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cmbProductName.Items.Add(rdr[0]);
                }
                rdr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }
        private void Reset()
        {
            txtPrice.Text = "";
            txtFeatures.Text = "";
            cmbProductName.Text = "";
            txtSalesPrice.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            cmbProductName.Focus();
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con.Open();
                string cq = "delete from Config where config_id=" + txtConfigID.Text + "";
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
                string cb = "update config set product_name='" + cmbProductName.Text + "',features='" + txtFeatures.Text + "',price='" + Convert.ToDecimal(txtPrice.Text) + "',sale_price='" + Convert.ToDecimal(txtSalesPrice.Text) + "',agentprice='" + Convert.ToDecimal(txtAgentPrice.Text) + "' where config_id=" + txtConfigID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
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
            this.Hide();
            Config_Record frm = new Config_Record();
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
            frm.GetData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbProductName.Text == "")
            {
                MessageBox.Show("Please select product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProductName.Focus();
                return;
            }
            if (txtPrice.Text == "")
            {
                MessageBox.Show("Please enter price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }
            try
            {
                con.Open();
                string cb = "insert into config VALUES ('" + cmbProductName.Text + "','" + txtFeatures.Text + "'," + Convert.ToDecimal(txtPrice.Text) + ",'" + Convert.ToDecimal(txtSalesPrice.Text) + "','" + Convert.ToDecimal(txtAgentPrice.Text) + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter("select config_id from config where product_name='"+cmbProductName.Text+"'",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            label5.Text = "Your newly added Config ID is: "+dt.Rows[0][0].ToString();
            label5.Visible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                //Config obj = new Config();
                // or simply use column name instead of index
                //dr.Cells["id"].Value.ToString();
                //obj.txtConfigID.Text = dr.Cells[0].Value.ToString();
                //obj.cmbProductName.Text = dr.Cells[1].Value.ToString();
                //obj.txtFeatures.Text = dr.Cells[2].Value.ToString();
                //obj.txtPrice.Text = dr.Cells[3].Value.ToString();
                //obj.txtSalesPrice.Text = dr.Cells[4].Value.ToString();
                //obj.btnUpdate.Enabled = true;
                //obj.btnDelete.Enabled = true;
                //obj.btnSave.Enabled = false;
                //obj.cmbProductName.Focus();
                txtConfigID.Text = dr.Cells[0].Value.ToString();
                cmbProductName.Text = dr.Cells[1].Value.ToString();
                txtFeatures.Text = dr.Cells[2].Value.ToString();
                txtPrice.Text = dr.Cells[3].Value.ToString();
                txtSalesPrice.Text = dr.Cells[4].Value.ToString();
                txtAgentPrice.Text = dr.Cells[5].Value.ToString();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                cmbProductName.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtProfit_TextChanged(object sender, EventArgs e)
        {
            if (txtProfit.Text == "")
            {
                txtProfit.Focus();
            }
            else
            {
                price = Convert.ToDecimal(txtPrice.Text);
                profit = Convert.ToDecimal(txtProfit.Text);
                sum = (price * profit / 100) + price;
                txtSalesPrice.Text = sum.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void Config_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.config = 0;
        }
    }
}
