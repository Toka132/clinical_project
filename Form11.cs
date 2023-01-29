﻿using System;
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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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
            string query = "select * from patientprogresssheet";
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
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM clinical_project.patientprogresssheet WHERE Patient_ID =" + textBox2.Text, cnn);
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=clinical_project;uid=root;pwd=20youmna;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "INSERT INTO patientprogresssheet (Patient_Name,Doctor_Name,Patient_ID,Date_,Current_Diagnosis,NewSymptomsObserved,PatientOverallConditionSeems,MedicationsAddedd,MedicationsStopped,BloodTestsOrXrayOrProcedureResults,ReceivedBloodTests,findings) VALUES('" + textBox14 + "','" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.Date + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox9.Text + "', '" + textBox7.Text + "','" + textBox13.Text + "')";
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}