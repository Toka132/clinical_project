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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form19 form = new Form19();
            form.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "select * from patientrefferalform";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader = cmd.ExecuteReader();
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, cnn);
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM clinical_project.patientrefferalform WHERE Patient_ID =" + textBox2.Text, cnn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "INSERT INTO patientrefferalform (Patient_ID,ReferralDate,PatientPhoneNumber,DOB,Address_,Complaint,PatientDiagnosis,Medicine,ReasonsForReferral,ReferringDoctorComments) VALUES('" + textBox2.Text + "','" + dateTimePicker1.Value.Date + "','" + textBox4.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox3.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox5.Text + "')";
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "update clinical_project.patientrefferalform set  Address_='" + textBox6.Text + "',PatientPhoneNumber='" + textBox4.Text + " ' where Patient_ID= '" + textBox2.Text + "'";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
