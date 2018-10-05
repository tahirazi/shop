using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace Shop
{
    public partial class Invoice_for_Agents : Form
    {
        public decimal txCreditDebit = 0;
        public decimal txBalance = 0;
        public decimal txRes = 0;
        public int customerid;
        public decimal amountpaid;

        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd = null;
        SqlDataReader rdr;
        public Invoice_for_Agents()
        {
            InitializeComponent();
        }

        private void Invoice_for_Agents_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.invoiceForAgents = 0;
        }

        private void Invoice_for_Agents_Load(object sender, EventArgs e)
        {
            dtpInvoiceDate.CustomFormat = "M/d/yyyy h':'m tt";
            GetData();
            listView1.Columns.Add("Config ID");
            listView1.Columns.Add("Product Name");
            listView1.Columns.Add("Unit Price");
            listView1.Columns.Add("Quantity");
            listView1.Columns.Add("Total Amount");
            listView1.View = View.Details;
            cmbFill();
        }
        public void subtot()
        {
            decimal sum = 0;
            foreach (ListViewItem o in listView1.Items)
            {
                decimal value;
                if (decimal.TryParse(o.SubItems[4].Text, out value))
                    sum += value;
            }
            txtTotal.Text = sum.ToString();
        }
        public void cmbFill()
        {
            try
            {
                SqlDataReader rdr;
                con.Open();
                string ct = "select (id) from agents order by id";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbCustomerID.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }
        public void GetData()
        {
            try
            {
                con.Open();
                String sql = "SELECT stock_id,config.config_id,product_name,features,agentprice,sum(quantity) from stock,config where stock.config_id=config.config_id group by stock_id,product_name,agentprice,features,config.config_id order by product_name";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
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
        private void auto()
        {
            txtInvoiceNo.Text = "INV-" + GetUniqueKey(8);

        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private void cmbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select id,agent_name from agents where id='" + Convert.ToInt32(cmbCustomerID.Text) + "'";
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable("agents");
            dt.Load(rdr);
            if (dt.Rows.Count > 0)
            {
                txtCustomerID.Text = dt.Rows[0]["id"].ToString();
                con.Close();
            }
            if (dt.Rows.Count > 0)
            {
                txtCustomerName.Text = dt.Rows[0]["agent_name"].ToString();
                con.Close();
            }
            con.Close();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(new[] { txtConfig.Text, txtProductName.Text, txtPrice.Text, txtSaleQty.Text, txtTotalAmount.Text });
            listView1.Items.Add(item);
            decimal sum = 0;
            foreach (ListViewItem o in listView1.Items)
            {
                decimal value;
                if (decimal.TryParse(o.SubItems[4].Text, out value))
                    sum += value;
            }
            txtTotal.Text = sum.ToString();
            txtTotalAmount.Clear();
            txtSaleQty.Clear();
            txtAvailableQty.Clear();
            txtPrice.Clear();
            txtProductName.Clear();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                txtConfigID.Text = dr.Cells[1].Value.ToString();
                txtConfig.Text = dr.Cells[1].Value.ToString();
                txtProductName.Text = dr.Cells[2].Value.ToString();
                txtPrice.Text = dr.Cells[4].Value.ToString();
                txtAvailableQty.Text = dr.Cells[5].Value.ToString();
                txtSaleQty.Focus();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String sql = "SELECT Stock_ID,Config.Config_ID,Product_Name,Features,agentprice,sum(Quantity) from Stock,Config where Stock.Config_ID=Config.Config_ID and Product_name like '" + textBox1.Text + "%' group by Stock_ID,product_name,agentprice,Features,Config.Config_ID order by Product_Name";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void txtSaleQty_TextChanged(object sender, EventArgs e)
        {
            decimal val1 = 0;
            decimal val2 = 0;
            decimal.TryParse(txtPrice.Text, out val1);
            decimal.TryParse(txtSaleQty.Text, out val2);
            decimal I = (val1 * val2);
            txtTotalAmount.Text = I.ToString();
        }

        private void txtDiscountRS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal received = 0;
                decimal total, discount;
                if (txtDiscountRS.Text == "")
                {
                    txtReceived.Text = txtTotal.Text;
                }
                else
                {
                    total = Convert.ToDecimal(txtTotal.Text);
                    discount = Convert.ToDecimal(txtDiscountRS.Text);
                    received = total - discount;
                    label8.Text = received.ToString();
                    txtReceived.Text = received.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("No items to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    listView1.FocusedItem.Remove();
                    itmCnt = listView1.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        t = t + 1;
                    }
                    subtot();
                    decimal val1 = 0;
                    decimal val2 = 0;
                    decimal.TryParse(txtTotal.Text, out val1);
                    decimal.TryParse(txtDiscountRS.Text, out val2);
                    decimal I = (val1 - val2);
                    txtReceived.Text = I.ToString();
                }

                if (listView1.Items.Count == 0)
                {
                    txtTotal.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void debitCreditCalculation()
        {
            try
            {
                txCreditDebit = Convert.ToDecimal(lblCreditDebit.Text);
                txBalance = Convert.ToDecimal(txtBalance.Text);
                txRes = txCreditDebit - txBalance;
                txtCreditDebit.Text = txRes.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }
        private void txtReceivedAmount_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0;
            decimal b = 0;
            decimal c = 0;
            if (txtReceivedAmount.Text == "")
            {

            }
            else
            {
                a = Convert.ToDecimal(txtReceived.Text);
                b = Convert.ToDecimal(txtReceivedAmount.Text);
                c = a - b;
                txtBalance.Text = c.ToString();
            }
            debitCredit();
        }
        public void debitCredit()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select sum(balance) as ABC from agentbalances where id='" + Convert.ToInt32(txtCustomerID.Text) + "'";
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable("agentbalances");
                dt.Load(rdr);
                if (dt.Rows.Count > 0)
                {
                    //lblCreditDebit.Text = dt.Rows[0]["ABC"].ToString();
                    txtCreditDebit.Text = dt.Rows[0]["ABC"].ToString();
                    con.Close();
                }
                else
                {
                    lblCreditDebit.Text = "0";
                    con.Close();
                }
                con.Close();
                debitCreditCalculation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }
        public void updateBalance()
        {
            try
            {
                con.Open();
                string query = "INSERT INTO agentbalances VALUES ('" + Convert.ToInt32(txtCustomerID.Text) + "','" + txtInvoiceNo.Text + "','" + dtpInvoiceDate.Text + "','" + Convert.ToDecimal(txtTotal.Text) + "','" + Convert.ToDecimal(txtCreditDebit.Text) + "')";
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Clone();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }
        private void reset1()
        {
            dtpInvoiceDate.Text = DateTime.Today.ToString();
            txtAvailableQty.Text = "";
            txtConfig.Text = "";
            txtConfigID.Text = "";
            txtCustomerName.Text = "";
            txtDiscount.Text = "";
            txtPrice.Text = "";
            txtProductName.Text = "";
            txtReceived.Text = "";
            txtRem.Text = "";
            txtRemarks.Text = "";
            txtSaleQty.Text = "";
            txtTotal.Text = "";
            txtTotalAmount.Text = "";
            listView1.Items.Clear();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text == "")
            {
                MessageBox.Show("Please enter total payment", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotal.Focus();
                return;

            }
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("sorry no product added", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            auto();
            con.Open();
            string query = "INSERT INTO salesa VALUES ('" + txtInvoiceNo.Text + "','" + dtpInvoiceDate.Text + "','" + Convert.ToInt32(txtCustomerID.Text) + "','" + txtCustomerName.Text + "','" + Convert.ToDecimal(txtTotal.Text) + "','" + Convert.ToDecimal(txtDiscountRS.Text) + "','" + Convert.ToDecimal(txtReceived.Text) + "','" + Convert.ToDecimal(txtReceivedAmount.Text) + "','" + Convert.ToDecimal(txtBalance.Text) + "','" + Convert.ToDecimal(txtCreditDebit.Text) + "','" + txtRemarks.Text + "','" + Global.username + "')";
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            cmd.Clone();
            con.Close();

            for (int i = 0; i <= listView1.Items.Count - 1; i++)
            {
                string cd = "insert Into solda(Invoice_No,Config_ID,Quantity,Price,Total,soldby) VALUES (@InvoiceNo,@ConfigID,@Quantity,@Price,@Totalamount,@soldby)";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("InvoiceNo", txtInvoiceNo.Text);
                cmd.Parameters.AddWithValue("ConfigID", listView1.Items[i].SubItems[0].Text);
                cmd.Parameters.AddWithValue("Quantity", listView1.Items[i].SubItems[3].Text);
                cmd.Parameters.AddWithValue("Price", listView1.Items[i].SubItems[2].Text);
                cmd.Parameters.AddWithValue("TotalAmount", listView1.Items[i].SubItems[4].Text);
                cmd.Parameters.AddWithValue("soldby", Global.username);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            for (int i = 0; i <= listView1.Items.Count - 1; i++)
            {
                con.Open();
                string cb1 = "update stock set Quantity = Quantity - " + listView1.Items[i].SubItems[3].Text + " where Config_ID= " + listView1.Items[i].SubItems[0].Text + "";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            //for (int i = 0; i <= listView1.Items.Count - 1; i++)
            //{
            //    con.Open();

            //    string cb2 = "update stock set Total_Price = Total_price - '" + listView1.Items[i].SubItems[4].Text + "' where Config_ID= " + listView1.Items[i].SubItems[0].Text + "";
            //    cmd = new SqlCommand(cb2);
            //    cmd.Connection = con;
            //    cmd.ExecuteReader();
            //    con.Close();
            //}
            updateBalance();
            reset1();
            btnPrint.Enabled = true;
            GetData();
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            debitCredit();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                String sql = "SELECT Stock_ID,Config.Config_ID,Product_Name,Features,agentprice,sum(Quantity) from Stock,Config where Stock.Config_ID=Config.Config_ID and stock.config_id like '" + Int32.Parse(txtProductCode.Text) + "%' group by Stock_ID,product_name,agentprice,Features,Config.Config_ID order by Product_Name";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                if (txtProductCode.Text == "")
                {
                    con.Open();
                    String sql = "SELECT Stock_ID,Config.Config_ID,Product_Name,Features,agentprice,sum(Quantity) from Stock,Config where Stock.Config_ID=Config.Config_ID and Product_name like '" + textBox1.Text + "%' group by Stock_ID,product_name,agentprice,Features,Config.Config_ID order by Product_Name";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    dataGridView1.Rows.Clear();
                    while (rdr.Read() == true)
                    {
                        dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                    }
                    con.Close();
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }
        private void reset()
        {
            dtpInvoiceDate.Text = DateTime.Today.ToString();
            txtAvailableQty.Text = "";
            txtConfig.Text = "";
            txtConfigID.Text = "";
            txtCustomerName.Text = "";
            txtDiscount.Text = "";
            txtInvoiceNo.Text = "";
            txtPrice.Text = "";
            txtProductName.Text = "";
            txtReceived.Text = "";
            txtRem.Text = "";
            txtRemarks.Text = "";
            txtSaleQty.Text = "";
            txtTotal.Text = "";
            txtTotalAmount.Text = "";
            listView1.Items.Clear();
        }
        private void NewRecord_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            decimal a, b, d, I = 0;
            decimal val1 = 0;
            //decimal val2 = 0;
            string op = txtDiscount.Text;
            switch (op)
            {
                case "":
                    txtDiscountRS.Text = I.ToString();
                    break;
                case "1":
                    b = 0.01m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "2":
                    b = 0.02m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "3":
                    b = 0.03m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "4":
                    b = 0.04m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "5":
                    b = 0.05m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "6":
                    b = 0.06m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "7":
                    b = 0.07m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "8":
                    b = 0.08m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "9":
                    b = 0.09m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "10":
                    b = 0.10m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "11":
                    b = 0.11m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "12":
                    b = 0.12m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "13":
                    b = 0.13m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "14":
                    b = 0.14m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "15":
                    b = 0.15m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "16":
                    b = 0.16m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "17":
                    b = 0.17m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "18":
                    b = 0.18m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "19":
                    b = 0.19m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "20":
                    b = 0.20m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "21":
                    b = 0.21m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "22":
                    b = 0.22m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "23":
                    b = 0.23m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "24":
                    b = 0.24m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "25":
                    b = 0.25m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "26":
                    b = 0.26m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "27":
                    b = 0.27m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "28":
                    b = 0.28m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "29":
                    b = 0.29m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                case "30":
                    b = 0.30m;
                    decimal.TryParse(txtTotal.Text, out a);
                    d = (b * a);
                    decimal.TryParse(txtTotal.Text, out val1);
                    I = (val1 - d);
                    txtReceived.Text = I.ToString();
                    txtDiscountRS.Text = d.ToString();
                    break;
                default:
                    MessageBox.Show("You are not allowed to give the discount more than 30%. Or you selected invalid discount type.");
                    break;
            } 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Global.agentInvoicePrint++;
            if (Global.agentInvoicePrint == 1)
            {
                Agent_Invoice_Print frm = new Agent_Invoice_Print();
                Agent_Invoice_Print.abc = txtInvoiceNo.Text;
                frm.MdiParent = Main.ActiveForm;
                frm.Show();
            }
        }
    }
}
