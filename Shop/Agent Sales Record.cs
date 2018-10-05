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
    public partial class Agent_Sales_Record : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlDataAdapter da = null;
        DataSet ds;
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        DataTable dt = new DataTable();
        public static string from = "";
        public static string to = "";
        public Agent_Sales_Record()
        {
            InitializeComponent();
        }

        private void Agent_Sales_Record_Load(object sender, EventArgs e)
        {
            dtpInvoiceDateFrom.CustomFormat = "M/d/yyyy h':'m tt";
            dtpInvoiceDateTo.CustomFormat = "M/d/yyyy h':'m tt";
            FillCombo();
        }
        public void sum()
        {
            decimal Total = 0;
            decimal creditdebit = 0;
            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(DataGridView1.Rows[i].Cells["Total"].Value);
                creditdebit += Convert.ToDecimal(DataGridView1.Rows[i].Cells["Debit/Credit"].Value);
            }
            txtTotal.Text = Total.ToString();
            txtCreditDebit.Text = creditdebit.ToString();
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT invoice_no AS [Invoice No], date AS [Invoice Date], agent_id AS [Customer ID], agent_name AS [Customer Name], total AS Total, discount AS Discount, netamount AS [Net Amount], received AS Received, balance AS Balance, debitcredit AS [Debit/Credit], remarks AS Remarks, saleby AS [Sale By] FROM salesa WHERE date BETWEEN '" + dtpInvoiceDateFrom.Text + "' AND '" + dtpInvoiceDateTo.Text + "' ORDER BY date DESC";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "salesa");
                DataGridView1.DataSource = ds.Tables["salesa"].DefaultView;
                con.Close();
                sum();
                sum_discount();
                sum_Received();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Invalid Selection", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnBySaleMan_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT invoice_no AS [Invoice No], date AS [Invoice Date], agent_id AS [Customer ID], agent_name AS [Customer Name], total AS Total, discount AS Discount, netamount AS [Net Amount], received AS Received, balance AS Balance, debitcredit AS [Debit/Credit], remarks AS Remarks, saleby AS [Sale By] FROM salesa WHERE saleby='" + Global.username + "' AND date BETWEEN '" + dtpInvoiceDateFrom.Text + "' AND '" + dtpInvoiceDateTo.Text + "' ORDER BY date DESC";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "salesa");
                DataGridView1.DataSource = ds.Tables["salesa"].DefaultView;
                con.Close();
                sum();
                sum_discount();
                sum_Received();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Invalid Selection", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT invoice_no AS [Invoice No], date AS [Invoice Date], agent_id AS [Customer ID], agent_name AS [Customer Name], total AS Total, discount AS Discount, netamount AS [Net Amount], received AS Received, balance AS Balance, debitcredit AS [Debit/Credit], remarks AS Remarks, saleby AS [Sale By] FROM salesa WHERE saleby='" + cmbUsers.Text + "' AND date BETWEEN '" + dtpInvoiceDateFrom.Text + "' AND '" + dtpInvoiceDateTo.Text + "' ORDER BY date DESC";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "salesa");
                DataGridView1.DataSource = ds.Tables["salesa"].DefaultView;
                con.Close();
                sum();
                sum_discount();
                sum_Received();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Invalid Selection", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            from = dtpInvoiceDateFrom.Text;
            to = dtpInvoiceDateTo.Text;
            Global.agentSalesRecordReport++;
            if (Global.agentSalesRecordReport == 1)
            {
                Agent_Sales_Record_Report frm = new Agent_Sales_Record_Report();
                frm.MdiParent = Main.ActiveForm;
                frm.Show();
            }
        }
    }
}
