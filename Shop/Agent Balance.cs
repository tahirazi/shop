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
    public partial class Agent_Balance : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader rdr;
        public Agent_Balance()
        {
            InitializeComponent();
        }

        private void Agent_Balance_Load(object sender, EventArgs e)
        {

        }
        public void sum()
        {
            decimal Total = 0;
            decimal debit_OR_Credit = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Amount"].Value);
                debit_OR_Credit += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Balance"].Value);
            }
            txtGrossAmount.Text = Total.ToString();
            txtCreditORDebit.Text = debit_OR_Credit.ToString();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "")
            {

            }
            else
            {
                try
                {
                    con.Open();
                    String sql = "SELECT transaction_no AS [Transaction No], invoice_no AS [Invoice No], invoice_date AS Date, amount AS Amount, balance AS Balance FROM agentbalances WHERE id like '" + Int32.Parse(txtCustomerName.Text) + "%'";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                    }
                    rdr.Close();
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                sum();
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

        private void Agent_Balance_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.agentBalanceRecord = 0;
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            Global.agentBalanceRecordReport++;
            if (Global.agentBalanceRecordReport == 1)
            {
                Agent_Balance_Report frm = new Agent_Balance_Report();
                frm.MdiParent = Main.ActiveForm;
                frm.Show();
            }
        }
    }
}
