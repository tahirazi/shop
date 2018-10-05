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
    public partial class Product_Record : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataReader rdr = null;
        SqlCommand cmd = null;
        //DataTable dt;
        public Product_Record()
        {
            InitializeComponent();
        }

        private void Product_Record_Load(object sender, EventArgs e)
        {
            GetDataOnLoad();
        }
        public void GetDataOnLoad()
        {
            
            if (Products.category == "")
            {
                GetData();
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("SELECT (product_name) as [Product Name],category_name as [Category],company_name as [Company] from product where category_name='"+Products.category+"' order by product_name", con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
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
        public void GetData()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT (product_name) as [Product Name],category_name as [Category],company_name as [company_name] from Product order by product_name", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
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

        private void Product_Record_FormClosing(object sender, FormClosingEventArgs e)
        {
            Products frm = new Products();
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
            this.Hide();
        }

        private void txtProductname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT (product_name) as [Product Name],category_name as [Category],company_name as [Company] from product where product_name like '" + txtProductname.Text + "%' order by product_name", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
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

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT (product_name) as [Product Name],category_name as [Category],company_name as [Company] from product where category_name like '" + txtCategory.Text + "%' order by product_name", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
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

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT (product_name) as [Product Name],category_name as [Category],company_name as [Company] from product where company_name like '" +txtCompany.Text + "%' order by product_name", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                Products frm = new Products();
                frm.MdiParent = Main.ActiveForm;
                frm.Show();
                frm.txtProductName.Text = dr.Cells[0].Value.ToString();
                frm.textBox1.Text = dr.Cells[0].Value.ToString();
                frm.cmbCategory.Text = dr.Cells[1].Value.ToString();
                frm.cmbCompany.Text = dr.Cells[2].Value.ToString();
                frm.btnUpdate.Enabled = true;
                frm.btnDelete.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.txtProductName.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
