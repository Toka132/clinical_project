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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string login = "SELECT * FROM signup3 WHERE UserName=  '" + textBox1.Text + "' and Password_ = '" + textBox2.Text +"'";
            MySqlCommand cmd = new MySqlCommand(login, cnn);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                Form19 form = new Form19();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Sign_up form = new Sign_up();
            form.Show();
            this.Hide();
        }
    }
}
