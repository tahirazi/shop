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
    public partial class Stock : Form
    {
        decimal price, profit, salesprices, Qty1, totalPrice, sum;
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataReader rdr;
        SqlCommand cmd = null;
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void Reset()
        {
            txtPrice.Text = "";
            txtFeatures.Text = "";
            txtSalesPrice.Text = "";
            txtProductname.Text = "";
            txtQty.Text = "";
            txtTotalPrice.Text = "";
            txtStockID.Text = "";
            dtpStockDate.Text = DateTime.Today.ToString();
            txtProduct.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
        }
        public void GetData()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT stock_id as [Stock ID], (product_name) as [Product Name],features,sum(quantity) as [Quantity],price as [Purchase Price],sale_price as [Sales Price],sum(total_price) as [Total Price] from config,stock where config.config_id=stock.config_id group by stock_id, product_name,features,price,sale_price order by product_name", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "stock");
                myDA.Fill(myDataSet, "config");
                dataGridView1.DataSource = myDataSet.Tables["stock"].DefaultView;
                dataGridView1.DataSource = myDataSet.Tables["config"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductname.Text == "")
            {
                MessageBox.Show("Please retrieve product name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductname.Focus();
                return;
            }
            if (txtQty.Text == "")
            {
                MessageBox.Show("Please enter quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
                return;
            }
            //try
            //{
            //    con.Open();
            //    string cb1 = "insert into stock_1 values ('" + Convert.ToInt32(txtConfigID.Text) + "','" + Convert.ToDecimal(txtQty.Text) + "','" + Convert.ToDecimal(txtTotalPrice.Text) + "','" + dtpStockDate.Text + "')";
            //    cmd = new SqlCommand(cb1);
            //    cmd.Connection = con;
            //    cmd.ExecuteReader();
            //    con.Close();
            //    MessageBox.Show("Successfully saved to Date wise stock.", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    con.Close();
            //}
            try
            {
                con.Open();
                String ct = "select config_id  from stock where config_id=" + txtConfigID.Text + "";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read() == true)
                {
                    MessageBox.Show("Record already exists" + "\n" + "please update the stock of product", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                rdr.Close();
                con.Close();
                con.Open();
                string cb = "insert into stock values ('" + Convert.ToInt32(txtConfigID.Text) + "','" + Convert.ToDecimal(txtQty.Text) + "','" + Convert.ToDecimal(txtTotalPrice.Text) + "','" + dtpStockDate.Text + "')";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                GetData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock_Record frm = new Stock_Record();
            frm.label1.Text = label8.Text;
            frm.Show();
            frm.GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Config_Record1 frm = new Config_Record1();
            frm.label1.Text = label8.Text;
            frm.Show();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            //decimal val1;
            //decimal val2; ;
            //decimal.TryParse(txtSalesPrice.Text, out val1);
            //decimal.TryParse(txtQty.Text, out val2);
            //decimal I = (val1 * val2);
            //txtTotalPrice.Text = I.ToString();
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

        private void txtQty_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
        private void delete_records()
        {

            try
            {
                int RowsAffected = 0;
                con.Open();
                string cq = "delete from Stock where stock_id='" + txtStockID.Text + "'";
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string cb = "Update Stock set config_id=" + txtConfigID.Text + ",quantity='" +Convert.ToDecimal(txtQty.Text) + "',total_price='" +Convert.ToDecimal(txtTotalPrice.Text) + "',stock_date= '" + dtpStockDate.Text + "' where stock_id='" +Convert.ToInt32(txtStockID.Text) + "'";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetData();
                //frmMainMenu frm = new frmMainMenu();
                //frm.GetData();
               
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
            Stock_Record frm = new Stock_Record();
            frm.label1.Text = label8.Text;
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
            frm.GetData();
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Stock_Id as [Stock ID], (product_name) as [Product Name],Features,sum(Quantity) as [Quantity],Price, sale_price as [Sale Price],sum(total_price) as [Total Price] from config,stock where Config.config_id=Stock.config_id and product_name like '" + txtProduct.Text + "%' group by stock_id, product_name,features,price,sale_price order by product_name", con);
                SqlDataAdapter myDA = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                myDA.Fill(myDataSet, "stock");
                myDA.Fill(myDataSet, "config");
                dataGridView1.DataSource = myDataSet.Tables["stock"].DefaultView;
                dataGridView1.DataSource = myDataSet.Tables["config"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Stock_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.stock = 0;
        }
    }
}
