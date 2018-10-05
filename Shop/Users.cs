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
    public partial class Users : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        SqlCommand cmd = null;
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            GetData();
        }
        #region Functions and methods
        public void GetData()
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [username] as [User Name],[display_name] as [Name],[password] as [Password] ,[role] as [Role] FROM [Shop].[dbo].[users]", con);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }
        public void clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtDisplayName.Clear();
            cmbRole.Text = "";
        }
        public void delete_records()
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Nothing to Delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM users WHERE username='" + lblUserID.Text + "'";
                    cmd = new SqlCommand(query);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    con.Close();
                    MessageBox.Show("Successfully Deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion
        #region abc
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDisplayName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Please Enter User name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                }
                else if (txtDisplayName.Text == "")
                {
                    MessageBox.Show("Please Enter Display Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDisplayName.Focus();
                }
                else if (cmbRole.Text == "")
                {
                    MessageBox.Show("Please Select Role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbRole.Focus();
                }
                else
                {
                    con.Open();
                    string query = "INSERT INTO users VALUES ('" + txtUsername.Text.Trim() + "','" + txtDisplayName.Text.Trim() + "','" + txtPassword.Text.Trim() + "','" + cmbRole.Text.Trim() + "')";
                    cmd = new SqlCommand(query);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    con.Close();
                    MessageBox.Show("Successfully Added.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    GetData();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("User Name Already exists OR "+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Nothing to Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "UPDATE [shop].[dbo].[users] SET [username] ='" + txtUsername.Text + "',[display_name] ='" + txtDisplayName.Text + "',[password] ='" + txtPassword.Text + "',[role] ='" + cmbRole.Text + "' WHERE username='" + lblUserID.Text + "'";
                    cmd = new SqlCommand(query);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    con.Close();
                    MessageBox.Show("Successfully Updated.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    GetData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
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
                lblUserID.Text = dr.Cells[0].Value.ToString();
                txtUsername.Text = dr.Cells[0].Value.ToString();
                txtDisplayName.Text = dr.Cells[1].Value.ToString();
                txtPassword.Text = dr.Cells[2].Value.ToString();
                cmbRole.Text = dr.Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete_records();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Users_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.users = 0;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Index == 2 && e.Value != null)
            {
                dataGridView1.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

    }
}
