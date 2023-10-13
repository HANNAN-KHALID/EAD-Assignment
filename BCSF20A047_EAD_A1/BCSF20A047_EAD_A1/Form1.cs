using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCSF20A047
{
    public partial class Form1 : Form
    {
        private List<string> list_Subjects = new List<string>();
        private ArrayList list_Name = new ArrayList();
        public Form1()
        {
            InitializeComponent();
            //comboBox1.Items.Add("EAD");
            //comboBox1.Items.Add("Computer");
            //comboBox1.Items.Add("Chemistry");
            //comboBox1.Items.Add("Science");
            //comboBox1.Items.Add("Math");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string subjects = textBox3.Text;

            if (!string.IsNullOrEmpty(subjects))
            {
                if (!list_Subjects.Contains(subjects))
                {
                    list_Subjects.Add(subjects);
                    UpdateLabel();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("Subject already present in the list.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a subject.");
            }

        }

        private void UpdateLabel()
        {
            string name = textBox1.Text;
            string lastname = textBox2.Text;
            bool preReq = checkBox1.Checked;

            string fullName = "";
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastname))
            {
                fullName = $"{name} {lastname}";
                list_Name.Add(fullName);
                UpdateLabel1();
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Please enter both first name and last name.");
            }

            string text = $"Name: {name}\nLastname: {lastname}\nPre-requisite: {preReq}\nSubjects:\n{string.Join("\n", list_Subjects)}";
            label5.Text = text;
        }

        private void UpdateLabel1()
        {
            string text = "Names:\n";

            foreach (string firstname in list_Name)
            {
                text += firstname + "\n";
            }

            label5.Text = text;
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
