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
    public partial class Stock_Record : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd = null;
        SqlDataReader rdr;
        public Stock_Record()
        {
            InitializeComponent();
        }

        private void Stock_Record_Load(object sender, EventArgs e)
        {
            GetData();
            sum();
            label3.Visible = false;
            label4.Visible = false;
            sum_price_total();
            sum_price_purchase();
            sum_price_sales();
            sum_price_total_purchase();
        }
        public void sum_price_total_purchase()
        {
            decimal Total = 0;
            decimal quantity = 0;
            decimal sum=0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Column4"].Value);
            }
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                quantity += Convert.ToDecimal(dataGridView1.Rows[j].Cells["Column5"].Value);
            }
            sum = Total + quantity;

            label6.Text = "The Purchase Price Total is: " + sum.ToString();
        }
        public void sum_price_total()
        {
            decimal Total = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Column6"].Value);
            }

            label5.Text = "The Total Price is: " + Total.ToString();
        }
        public void sum()
        {
            decimal Total = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Column5"].Value);
            }

            label2.Text ="The total stock is: "+ Total.ToString();
        }
        public void sum_price_sales()
        {
            decimal Total = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Column5"].Value);
            }

            label3.Text = "The Sales Price Total is: " + Total.ToString();
        }
        public void sum_price_purchase()
        {
            decimal Total = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Column4"].Value);
            }

            label4.Text = "The Purchase Price Total is: " + Total.ToString();
        }
        public void GetData()
        {
            try
            {
                con.Open();
                String sql = "SELECT stock_id,config.config_id,product_name,features,price,sale_price,quantity,total_price,stock_date from stock,config where stock.config_id=config.config_id order by product_name";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7],rdr[8]);
                }
                rdr.Close();
                con.Close();
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

        private void txtProductname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String sql = "SELECT stock_id,config.config_id,product_name,features,price,sale_price,quantity,total_price,stock_date from stock,config where stock.config_id=config.config_id and product_name like '" + txtProductname.Text + "%' order by product_name";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7],rdr[8]);
                }
                rdr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                Stock frm = new Stock();
                frm.MdiParent = Main.ActiveForm;
                frm.Show();
                frm.txtStockID.Text = dr.Cells[0].Value.ToString();
                frm.txtConfigID.Text = dr.Cells[1].Value.ToString();
                frm.txtProductname.Text = dr.Cells[2].Value.ToString();
                frm.txtFeatures.Text = dr.Cells[3].Value.ToString();
                frm.txtPrice.Text = dr.Cells[4].Value.ToString();
                frm.txtSalesPrice.Text = dr.Cells[5].Value.ToString();
                frm.txtQty.Text = dr.Cells[6].Value.ToString();
                frm.txtTotalPrice.Text = dr.Cells[7].Value.ToString();
                frm.dtpStockDate.Text = dr.Cells[8].Value.ToString();
                frm.btnUpdate.Enabled = true;
                frm.btnDelete.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.label8.Text = label1.Text;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String sql = "SELECT stock_id,Config.Config_id,Product_Name,Features,Price,sale_price,Quantity,Total_price,Stock_date from Stock,Config where Stock.Config_id=Config.Config_id and Quantity <= 0 order by Product_Name";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7],rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Stock_Record_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Stock frm = new Stock();
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
            frm.GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtProductname.Text = "";
            GetData();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            if (txtProductCode.Text == "")
            {

            }
            else
            {
                try
                {
                    con.Open();
                    String sql = "SELECT stock_id,config.config_id,product_name,features,price,sale_price,quantity,total_price,stock_date from stock,config where stock.config_id=config.config_id and stock.config_id like '" + Int32.Parse(txtProductCode.Text) + "%' order by product_name";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8]);
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
        }
    }
}
