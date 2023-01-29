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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            {
             
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "select * from comperhensivepatienthistory";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader = cmd.ExecuteReader();
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, cnn);
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "INSERT INTO comperhensivepatienthistory (Date_,Past_Medical_history,OtherDiseaseNotlistedAbove,HospitalizationOrSiginificantInjuries,Patient_ID,OtherSurgeryNotListedAbove,PreviousReactionToAnesthesia,ListNamesOfOtherPractitionersYouAreCurrentlySeeing,SurgeryOrproceduresHistory) VALUES('" + textBox7.Text + "','" + checkedListBox1.SelectedItem.ToString() + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + checkedListBox1.SelectedItem.ToString() + "')";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM clinical_project.comperhensivepatienthistory WHERE Patient_ID =" + textBox1.Text, cnn);
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