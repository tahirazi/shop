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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(Connection_Properties.GetConnectionString());
        //SqlDataAdapter da;
        //DataTable dt;

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please Enter Username !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter Password !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            else
            {
                try
                {
                    con.Open();
                    string qurey = "select role, username, password from users where username='" + txtUserName.Text + "' AND password='" + txtPassword.Text + "'";
                    SqlCommand cmd = new SqlCommand(qurey, con);
                    string UserRole = cmd.ExecuteScalar().ToString();
                    if (UserRole == "Admin")
                    {
                        Global.username = txtUserName.Text;
                        con.Close();
                        Main mn = new Main();
                        mn.Show();
                        txtPassword.Clear();
                        txtUserName.Clear();
                        this.Hide();
                        
                    }
                    else if (UserRole == "Sale Man")
                    {
                        Global.username = txtUserName.Text;
                        con.Close();
                        Main_2 mn2 = new Main_2();
                        mn2.Show();
                        txtPassword.Clear();
                        txtUserName.Clear();
                        this.Hide();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Valid Username !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+"Invalid Username OR Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
            }
            //----------------------------------------------------Model Method ------------------------------------------
            //if (string.IsNullOrEmpty(txtUserName.Text))
            //{
            //    MessageBox.Show("Please Enter Username !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtUserName.Focus();
            //    return;
            //}
            //else
            //{
            //    try
            //    {
            //        using (shopEntities1 sp=new shopEntities1())
            //        {
            //            var query = from o in sp.users
            //                        where o.username==txtUserName.Text && o.password==txtPassword.Text
            //                        select o;
            //            if (query.SingleOrDefault() != null)
            //            {
            //                this.Hide();
            //                Main mn = new Main();
            //                mn.Show();
            //            }
            //            else
            //            {
            //                MessageBox.Show("s");
            //            }
            //        }
                    
            //    }
            //    catch (Exception ex)
            //    {
            //      MessageBox.Show(ex.Message, "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //-----------------------------------------Method 1 ----------------------------------------------------------------------
            //con.Open();
            //da = new SqlDataAdapter("select username, password, role from users where username='" + txtUserName.Text + "' AND password='" + txtPassword.Text + "'", con);
            //dt = new DataTable();
            //da.Fill(dt);
            //try
            //{
            //    if (dt.Rows[0][3].ToString() == "Admin")
            //    {
            //            this.Hide();
            //            Main frm = new Main();
            //            frm.Show();
            //            con.Close();
            //    }
            //    else if (dt.Rows[0][3].ToString() == "Sale Man")
            //    {
            //        this.Hide();
            //        Main_2 frm = new Main_2();
            //        frm.Show();
            //        con.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        con.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Login is Failed...Try again !" + ex.ToString(), "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    con.Close();
            //}

            //con.Close();

            //--------------------------------------Simple-------------------------------------------
            //if (txtUserName.Text == "")
            //{
            //    MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtUserName.Focus();
            //    return;
            //}
            //if (txtPassword.Text == "")
            //{
            //    MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtPassword.Focus();
            //    return;
            //}
            //try
            //{
            //    if(txtUserName.Text=="admin" && txtPassword.Text=="admin")
            //    {
            //        this.Hide();
            //        Main frm = new Main();
            //        frm.Show();
            //    }
            //    else if (txtUserName.Text == "abc" && txtPassword.Text == "abc")
            //    {
            //        this.Hide();
            //        Main_2 frm = new Main_2();
            //        frm.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please enter valid user name or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}

            //-------------------------------------------------Method 2 --------------------------------------------------------
            //con.Open();
            //da = new SqlDataAdapter("select username, password, role from users where username='" + txtUserName.Text + "' AND password='" + txtPassword.Text + "'", con);
            //dt = new DataTable();
            //da.Fill(dt);
            //try
            //{
            //    if (dt.Rows[0][3].ToString() == "Admin")
            //    {
            //        if (txtUserName.Text == dt.Rows[0][0].ToString() && txtPassword.Text == dt.Rows[0][2].ToString())
            //        {
            //            this.Hide();
            //            Main frm = new Main();
            //            frm.Show();
            //            con.Close();
            //        }
            //        else if (dt.Rows[0][3].ToString() == "Sale Man")
            //        {
            //            this.Hide();
            //            Main_2 frm = new Main_2();
            //            frm.Show();
            //            con.Close();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            txtUserName.Clear();
            //            txtPassword.Clear();
            //            txtUserName.Focus();
            //            con.Close();
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        con.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Login is Failed...Try again !"+ex.ToString(), "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    con.Close();
            //}

            //con.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
