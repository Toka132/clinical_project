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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form19 form = new Form19();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "select * from patientoverview";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader = cmd.ExecuteReader();
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, cnn);
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "INSERT INTO patientoverview (Patient_ID,Symptoms,Disease,Prescription,Radiology_Tests,Lab_Tests,Medicine) VALUES('" + textBox2.Text + "','" + checkedListBox2.SelectedItem.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox3.Text + "','" + checkedListBox3.SelectedItem.ToString() + "','" + checkedListBox1.SelectedItem.ToString() + "','" + checkedListBox4.SelectedItem.ToString() + "')";
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM clinical_project.patientoverview WHERE Patient_ID =" + textBox2.Text, cnn);
                DataTable search = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(search);
                }
                dataGridView1.DataSource = search;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message));
            }
        }
    }
}
