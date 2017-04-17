using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bezopasnost
{
    public partial class Vhod : Form
    {
        public Vhod()
        {
            InitializeComponent();
        }

        private void Vhod_Load(object sender, EventArgs e)
        {
            Dannie.Polzovatel = 0;

            if (Dannie.Polzovatel == 0) {
                comboBox1.Text = "Гость";
            }
        }

        public void vh1(){

            /*-------------------Для гостя---------------------------------------------------------------------------------*/
            if (Dannie.Polzovatel == 0) {
                Dannie.login = comboBox1.Text;
                this.Close();
            }

            /*-------------------Для админа---------------------------------------------------------------------------------*/
            if (Dannie.Polzovatel == 1) {
                if (textBox2.Text == "1234") {
                    Dannie.login = comboBox1.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка ввода пароля", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /*-------------------Для работников---------------------------------------------------------------------------------*/
            if (Dannie.Polzovatel == 2)
            {
                if (textBox2.Text == dataGridView1.Rows[0].Cells[1].Value.ToString())
                {
                    Dannie.login = comboBox1.Text;
                    this.Close();
                }
                else {
                    MessageBox.Show("Ошибка ввода пароля", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            /*-------------------Для комиссии---------------------------------------------------------------------------------*/
            if (Dannie.Polzovatel == 3)
            {
                if (textBox2.Text == dataGridView1.Rows[0].Cells[1].Value.ToString())
                {
                    Dannie.login = comboBox1.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка ввода пароля", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vh1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dannie.Polzovatel = 1;
            comboBox1.Text = "Администратор";

        }

        private void Vhod_Activated(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dannie.Polzovatel = 2;
            Form1 f1 = new Form1();
            SqlConnection conn = new SqlConnection(f1.connect);
            string q = "Select kod_r, fio from Rabotni";
            SqlDataAdapter ad = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            ad.Fill(ds);
            conn.Close();
            comboBox1.DataSource = ds.Tables[0];

            comboBox1.DisplayMember = "fio";
            comboBox1.ValueMember = "kod_r";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
         
            
        }

        private void comboBox1_DisplayMemberChanged(object sender, EventArgs e)
        {
         
        }

        private void comboBox1_ValueMemberChanged(object sender, EventArgs e)
        {
            if (Dannie.Polzovatel == 2)
            {
                Form1 f1 = new Form1();
                SqlConnection conn = new SqlConnection(f1.connect);
                string q = "Select kod_r, Password1 from Rabotni Where kod_r = " + comboBox1.ValueMember.ToString();
                SqlDataAdapter ad = new SqlDataAdapter(q, conn);
                DataSet ds = new DataSet();
                conn.Open();
                ad.Fill(ds);
                conn.Close();
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (Dannie.Polzovatel == 3)
            {
                Form1 f1 = new Form1();
                SqlConnection conn = new SqlConnection(f1.connect);
                string q = "Select kod_k, password1 from Chleni_komissii Where kod_k = " + comboBox1.ValueMember.ToString();
                SqlDataAdapter ad = new SqlDataAdapter(q, conn);
                DataSet ds = new DataSet();
                conn.Open();
                ad.Fill(ds);
                conn.Close();
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dannie.Polzovatel = 3;
            Form1 f1 = new Form1();
            SqlConnection conn = new SqlConnection(f1.connect);
            string q = "Select kod_k, fio from Chleni_komissii";
            SqlDataAdapter ad = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            ad.Fill(ds);
            conn.Close();
            comboBox1.DataSource = ds.Tables[0];

            comboBox1.DisplayMember = "fio";
            comboBox1.ValueMember = "kod_k";
        }
    }
}
