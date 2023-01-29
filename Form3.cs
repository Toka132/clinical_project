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
using System.ComponentModel.DataAnnotations;

namespace Clinical_project_
{
    public partial class Form3 : Form
    {
        

        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            {
               
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PatientInfo patient = new PatientInfo();
            patient.Patient_Name = textBox1.Text;
            patient.Patient_ID = textBox2.Text;
            patient.Patient_Address = textBox4.Text;
            patient.Phone_number = textBox5.Text;
            patient.Gender = textBox6.Text;
            //patient validation
            ValidationContext validationContext = new ValidationContext(patient);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(patient, validationContext, errors, true))
            {
                foreach (var item in errors)
                {
                    switch (item.MemberNames.First())
                    {
                        case "Patient_Name":
                            label4.Text = item.ErrorMessage;
                            break;
                        case "Patient_ID":
                            label3.Text = item.ErrorMessage;
                            break;
                        case "Patient_Address":
                            label5.Text = item.ErrorMessage;
                            break;
                        case "Phone_number":
                            label7.Text = item.ErrorMessage;
                            break;
                        case "Gender":
                            label6.Text = item.ErrorMessage;
                            break;
                        default:
                            MessageBox.Show(item.ErrorMessage);
                            break;

                    }
                }
            }
            else
            {




                string connetionString = null;
                MySqlConnection cnn;
                connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();

                string query = "INSERT INTO patientinfo ( Patient_ID,Patient_Name,Patient_Address,DOB,Phone_number,Gender,Blood_Group,Allergy,Chronic) VALUES('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + checkedListBox2.SelectedItem.ToString() +"', '" + checkedListBox1.SelectedItem.ToString() +"')";
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();



            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "select * from patientinfo";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader = cmd.ExecuteReader();
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, cnn);
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgv.DataSource = dt;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "update clinical_project.patientinfo set  Phone_number='" + textBox5.Text + "',Patient_Address='" + textBox4.Text + "' where Patient_ID= '" + textBox2.Text + "'";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM clinical_project.patientinfo WHERE Patient_ID =" + textBox2.Text, cnn);
                DataTable search = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(search);
                }
                dgv.DataSource = search;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message));
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }


    }
    

