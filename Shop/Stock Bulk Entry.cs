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
    public partial class Stock_Bulk_Entry : Form
    {
        decimal price, profit, salesprices, Qty1, totalPrice, sum;
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataReader rdr;
        DataTable dt = new DataTable();
        SqlCommand cmd;
        public Stock_Bulk_Entry()
        {
            InitializeComponent();
        }

        private void Stock_Bulk_Entry_Load(object sender, EventArgs e)
        {
            fillcombo();
        }
        public void clear_boxes()
        {
            txtConfigID.Clear();
            txtFeatures.Clear();
            txtPrice.Clear();
            txtProfit.Clear();
            txtQty.Clear();
            txtSalesPrice.Clear();
            txtTotalPrice.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cmbCategory.Text=="")
            {
                MessageBox.Show("Please enter Category name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategory.Focus();
            }
            try
            {
                con.Open();
                string ct = "select category_name from category where category_name='" + cmbCategory.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                        con.Close();
                    }
                    rdr.Close();
                    con.Close();
                }
                    

                else
                {
                    con.Close();
                    con.Open();
                    string cb = "insert into category VALUES ('" + cmbCategory.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            if (cmbCompany.Text == "")
            {
                MessageBox.Show("Please enter company name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCompany.Focus();
            }
            try
            {
                con.Open();
                string ct = "select company_name from company where company_name='" + cmbCompany.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    rdr.Close();
                    con.Close();
                }
                else
                {
                    con.Close();
                    con.Open();
                    string cb = "insert into company(company_name) VALUES ('" + cmbCompany.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            if (cmbProduct.Text == "")
            {
                MessageBox.Show("Please enter product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProduct.Focus();
            }
            if (cmbCategory.Text == "")
            {
                MessageBox.Show("Please select category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategory.Focus();
            }
            if (cmbCompany.Text == "")
            {
                MessageBox.Show("Please select company", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCompany.Focus();
            }
            try
            {
                con.Open();
                string ct = "select product_name from product where product_name='" + cmbProduct.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    rdr.Close();
                    con.Close();
                }
                else
                {
                    con.Close();
                    con.Open();
                    string cb = "insert into product(product_name,category_name,company_name) VALUES ('" + cmbProduct.Text + "','" + cmbCategory.Text + "','" + cmbCompany.Text + "')";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                    con.Close();
                    cmbProduct.Focus();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            if (cmbProduct.Text == "")
            {
                MessageBox.Show("Please select product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProduct.Focus();
            }
            if (txtPrice.Text == "")
            {
                MessageBox.Show("Please enter price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
            }
            try
            {
                con.Open();
                string cb = "insert into config(product_name,features,price,sale_price) VALUES ('" + cmbProduct.Text + "','" + txtFeatures.Text + "'," + Convert.ToDecimal(txtPrice.Text) + ",'" + Convert.ToDecimal(txtSalesPrice.Text) + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter("select config_id from config where product_name='" + cmbProduct.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            label11.Text = "The Product ID is: ";
            label11.Visible = true;
            lblConfigID.Text = dt.Rows[0][0].ToString();
            //label11.Visible = true;
            if (cmbProduct.Text == "")
            {
                MessageBox.Show("Please retrieve product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProduct.Focus();
            }
            if (txtQty.Text == "")
            {
                MessageBox.Show("Please enter quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
            }

            try
            {
                con.Open();
                String ct = "select config_id  from stock where config_id=" +lblConfigID.Text+ "";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    rdr.Close();
                    con.Close();
                }
                
                else
                {
                    con.Close();
                con.Open();
                string cb = "insert into stock values ('" + Convert.ToInt32(lblConfigID.Text) + "','" + Convert.ToDecimal(txtQty.Text) + "','" + Convert.ToDecimal(txtTotalPrice.Text) + "','" + dtpDate.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            clear_boxes();

        }
        public void fillcombo()
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
                con.Open();
                string ct2 = "select RTRIM(product_name) from product WHERE company_name='"+cmbCompany.Text+"' order by product_name";
                cmd = new SqlCommand(ct2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbProduct.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
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

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.Text == "")
            {

            }

            SqlDataAdapter da = new SqlDataAdapter("select * from config where product_name='" + cmbProduct.Text + "'", con);
            DataTable dtt = new DataTable();
            da.Fill(dtt);
            con.Open();
            string ct = "select * from config where product_name='" + cmbProduct.Text + "'";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;

            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                if(rdr.HasRows)
                {
                    txtFeatures.Text = dtt.Rows[0][2].ToString();
                    txtPrice.Text = dtt.Rows[0][3].ToString();
                    txtSalesPrice.Text = dtt.Rows[0][4].ToString();
                }
                else if ((rdr == null))
                {
                    //SqlDataAdapter da = new SqlDataAdapter("select * from config where product_name='" + cmbProduct.Text + "'", con);
                    //DataTable dtt = new DataTable();
                    //da.Fill(dtt);
                    //txtFeatures.Text = dt.Rows[0][2].ToString();
                    //txtPrice.Text = dt.Rows[0][3].ToString();
                    //txtSalesPrice.Text = dt.Rows[0][4].ToString();
                    txtFeatures.Text = "";
                    txtPrice.Text = "";
                    txtSalesPrice.Text = "";
                    rdr.Close();
                }
                
            }
            con.Close();
                
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProduct.Items.Clear();
            con.Open();
            string ct2 = "select RTRIM(product_name) from product WHERE company_name='" + cmbCompany.Text + "' order by product_name";
            cmd = new SqlCommand(ct2);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                cmbProduct.Items.Add(rdr[0]);
            }
            rdr.Close();
            con.Close();
        }

        private void txtProfit_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
            {

            }
            else
            {
                salesprices = Convert.ToDecimal(txtSalesPrice.Text);
                Qty1 = Convert.ToDecimal(txtQty.Text);
                totalPrice = salesprices * Qty1;
                txtTotalPrice.Text = totalPrice.ToString();
            }
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

        private void Stock_Bulk_Entry_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.stock_bulk_entry = 0;
        }

    }
}
