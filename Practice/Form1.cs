using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L53AQMT\SQLEXPRESS;Initial Catalog=RAH_Shoe_Shop;Integrated Security=True;");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string username = textBox1.Text;
                string password = textBox2.Text;

                string query = "SELECT * FROM admin_login WHERE username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader row = cmd.ExecuteReader();

                if (row.HasRows)
                {
                    row.Read();
                    string storedPassword = row["password"].ToString();
                    if (storedPassword == password)
                    {
                        MessageBox.Show("Login Succesful", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dashboard manage = new Dashboard();
                        manage.Show();
                        this.Hide();
                    }
                    else
                    {
                        var msg = MessageBox.Show("Password Incorrect", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        if (msg.ToString() == "Retry")
                        {
                            textBox2.Clear();
                            textBox2.Focus();
                        }

                    }
                }
                else
                {
                    var msg = MessageBox.Show("Username does not exist!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (msg.ToString() == "Retry")
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
