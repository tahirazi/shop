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
    public partial class Bulk_Data_Insertion : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd = new SqlCommand();
        public Bulk_Data_Insertion()
        {
            InitializeComponent();
        }

        private void Bulk_Data_Insertion_Load(object sender, EventArgs e)
        {

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

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.IsCurrentRowDirty)
            {
                try
                {
                    string category_name = dataGridView1[0, e.RowIndex].EditedFormattedValue.ToString();
                    con.Open();
                    string query = "INSERT INTO category values ('" + category_name + "')";
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    con.Close();

                    string company_name = dataGridView1[1, e.RowIndex].EditedFormattedValue.ToString();
                    con.Open();
                    string query1 = "INSERT INTO company values ('" + company_name + "')";
                    cmd.Connection = con;
                    cmd.CommandText = query1;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    con.Close();

                    string product_name = dataGridView1[2, e.RowIndex].EditedFormattedValue.ToString();
                    con.Open();
                    string query2 = "INSERT INTO product values ('" + product_name + "','" + category_name + "','" + company_name + "')";
                    cmd.Connection = con;
                    cmd.CommandText = query2;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    con.Close();

                    string features = dataGridView1[3, e.RowIndex].EditedFormattedValue.ToString();
                    string price = dataGridView1[4, e.RowIndex].EditedFormattedValue.ToString();
                    string sale_price = dataGridView1[5, e.RowIndex].EditedFormattedValue.ToString();
                    con.Open();
                    string query3 = "INSERT INTO config values ('" + product_name + "','" + features + "','" + Convert.ToDecimal(price) + "','" + Convert.ToDecimal(sale_price) + "')";
                    cmd.Connection = con;
                    cmd.CommandText = query3;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                
            }
        }

        private void Bulk_Data_Insertion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.bulk_data_insertion = 0;
        }
    }
}
