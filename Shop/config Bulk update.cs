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
    public partial class config_Bulk_update : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd = null;
        SqlDataReader rdr;
        public config_Bulk_update()
        {
            InitializeComponent();
        }
        
        private void config_Bulk_update_Load(object sender, EventArgs e)
        {
            GetData();
            DataAdp();
        }
        public void GetData()
        {
            try
            {
                con.Open();
                string query = "SELECT category.category_name, product.product_name, config.config_id, config.product_name AS Expr1, config.features, config.price, config.sale_price FROM category INNER JOIN product ON category.category_name = product.category_name INNER JOIN config ON product.product_name = config.product_name WHERE category.category_name = 'cosmetics'";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
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
        public void DataAdp()
        {
            try
            {
                con.Open();
                ds = new DataSet();
                da = new SqlDataAdapter("SELECT * from config where config_id='"+Convert.ToInt32(textBox1.Text)+"'", con);
                da.Fill(ds, "config");
                dataGridView2.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if(dataGridView1.IsCurrentRowDirty)
                {
                    string query;
                    string config_id = dataGridView1[1, e.RowIndex].EditedFormattedValue.ToString();
                    string product_name = dataGridView1[2, e.RowIndex].EditedFormattedValue.ToString();
                    string features = dataGridView1[3, e.RowIndex].EditedFormattedValue.ToString();
                    string price = dataGridView1[4, e.RowIndex].EditedFormattedValue.ToString();
                    string sales_price = dataGridView1[5, e.RowIndex].EditedFormattedValue.ToString();
                    con.Open();
                    cmd.Connection = con;
                    query = "update config set product_name='" + product_name + "',features='" + features + "',price='" + Convert.ToDecimal(price) + "',sale_price='" + Convert.ToDecimal(sales_price) + "' where config_id=" + Convert.ToInt32(config_id) + "";
                    cmd.CommandText = query;
                    da.SelectCommand = cmd;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string valueA = row.Cells[Price.Index].Value.ToString();
                string valueB = row.Cells[SalesPrice.Index].Value.ToString();
                string valueC = row.Cells[Percentage.Index].Value.ToString();
                decimal result;

                //row.Cells[columnTotal.Index].Value = result.ToString();
                if (decimal.TryParse(valueA, out result)
                    && decimal.TryParse(valueB, out result))
                {
                    
                    result = (Convert.ToDecimal(valueA) *Convert.ToDecimal(valueC) / 100);
                    row.Cells[SalesPrice.Index].Value = result;
                }
            }
        }
    }
}
