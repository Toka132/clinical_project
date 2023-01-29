using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Clinical_project_
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }

        private void Sign_up_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox5.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("UserName and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == textBox3.Text)
            {
                string connetionString = null;
                MySqlConnection cnn;
                connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();

                string query = "INSERT INTO signup3 (FirstName,LastName,UserName,Password_,ConfirmPassword) VALUES('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                MySqlCommand cmd = new MySqlCommand(query, cnn);

                cmd.ExecuteNonQuery();
                cnn.Close();
                textBox5.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Password does not match Please Re-Enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';

            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Focus();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}

