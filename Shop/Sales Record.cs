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
    public partial class Sales_Record : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataAdapter da = null;
        DataSet ds;
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        DataTable dt = new DataTable();
        public static string from = "";
        public static string to = "";
        public Sales_Record()
        {
            InitializeComponent();
        }

        private void Sales_Record_Load(object sender, EventArgs e)
        {
            //dtpInvoiceDateFrom.CustomFormat = "dd/MMM/yyyy";
            //dtpInvoiceDateTo.CustomFormat = "dd/MMM/yyyy";

            dtpInvoiceDateFrom.CustomFormat = "M/d/yyyy h':'m tt";
            dtpInvoiceDateTo.CustomFormat = "M/d/yyyy h':'m tt";
            FillCombo();
        }
        public void FillCombo()
        {
            try
            {
                con.Open();
                string ct = "select RTRIM(username) from users order by username";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbUsers.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }
        public void sum()
        {
            decimal Total = 0;

            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(DataGridView1.Rows[i].Cells["Total"].Value);
            }
            txtTotal.Text = Total.ToString();

            //label2.Text = "The total stock is: " + Total.ToString();
        }
        public void sum_discount()
        {
            decimal Total = 0;

            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(DataGridView1.Rows[i].Cells["Discount"].Value);
            }
           txtDiscount.Text = Total.ToString();

            //label2.Text = "The total stock is: " + Total.ToString();
        }
        public void sum_Received()
        {
            decimal Total = 0;

            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(DataGridView1.Rows[i].Cells["Received"].Value);
            }
            txtReceived.Text = Total.ToString();

            //label2.Text = "The total stock is: " + Total.ToString();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT invoice_no AS [Invoice No], invoice_date AS [Invoice Date], customer_name AS [Customer Name], total AS Total, discount AS Discount, received AS Received, remarks AS Remarks, soleby AS [Sale By] FROM sales WHERE invoice_date BETWEEN '"+dtpInvoiceDateFrom.Text+"' AND '"+dtpInvoiceDateTo.Text+"' ORDER BY invoice_date DESC";
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds,"sales");
            DataGridView1.DataSource = ds.Tables["sales"].DefaultView;
            con.Close();
            sum();
            sum_discount();
            sum_Received();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            from = dtpInvoiceDateFrom.Text;
            to = dtpInvoiceDateTo.Text;
            Sales_Record_Report frm = new Sales_Record_Report();
            frm.MdiParent = Main.ActiveForm;
            frm.Show();
        }

        private void Sales_Record_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.sales_record = 0;
        }

        private void btnSoldProducts_Click(object sender, EventArgs e)
        {
            Sold_Products_Category_Wise frm = new Sold_Products_Category_Wise();
            frm.Show();
            //Sold_Products_Record frm = new Sold_Products_Record();
            //frm.Show();
        }

        private void ntnsalesrecordwithstock_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void btnBySaleMan_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT invoice_no AS [Invoice No], invoice_date AS [Invoice Date], customer_name AS [Customer Name], total AS Total, discount AS Discount, received AS Received, remarks AS Remarks, soleby AS [Sale By] FROM sales WHERE soleby = '"+Global.username+"' AND invoice_date BETWEEN '" + dtpInvoiceDateFrom.Text + "' AND '" + dtpInvoiceDateTo.Text + "' ORDER BY invoice_date DESC";
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "sales");
            DataGridView1.DataSource = ds.Tables["sales"].DefaultView;
            con.Close();
            sum();
            sum_discount();
            sum_Received();
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT invoice_no AS [Invoice No], invoice_date AS [Invoice Date], customer_name AS [Customer Name], total AS Total, discount AS Discount, received AS Received, remarks AS Remarks, soleby AS [Sale By] FROM sales WHERE soleby = '" + cmbUsers.Text + "' AND invoice_date BETWEEN '" + dtpInvoiceDateFrom.Text + "' AND '" + dtpInvoiceDateTo.Text + "' ORDER BY invoice_date DESC";
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "sales");
            DataGridView1.DataSource = ds.Tables["sales"].DefaultView;
            con.Close();
            sum();
            sum_discount();
            sum_Received();
        }
        
    }
}
