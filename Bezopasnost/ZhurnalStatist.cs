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
    public partial class ZhurnalStatist : Form
    {
        public ZhurnalStatist()
        {
            InitializeComponent();
        }

        private void ZhurnalStatist_Load(object sender, EventArgs e)
        {


       
        }

        private void ZhurnalStatist_Activated(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);

           
            string q1 =
               " SELECT kod_inst," +
                  " instrukc " +
               " FROM Instrukcii ";
            ;

            SqlDataAdapter ad1 = new SqlDataAdapter(q1, conn);
            DataSet ds1 = new DataSet();
            conn.Open();
            ad1.Fill(ds1);
            conn.Close();
            comboBox1.DataSource = ds1.Tables[0];

            comboBox1.DisplayMember = "instrukc";
            comboBox1.ValueMember = "kod_inst";
        }

        public void tm() {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);

            textBox3.Text = comboBox1.SelectedValue.ToString();
            string q1 =
               " SELECT kod_tm," +
                  " tema " +
               " FROM Temi t join Instrukcii i on t.kod_inst = i.kod_inst " +
               " WHERE t.kod_inst = " + Convert.ToInt32(textBox3.Text)
               ;
            ;

            SqlDataAdapter ad1 = new SqlDataAdapter(q1, conn);
            DataSet ds1 = new DataSet();
            conn.Open();
            ad1.Fill(ds1);
            conn.Close();
            comboBox2.DataSource = ds1.Tables[0];

            comboBox2.DisplayMember = "tema";
            comboBox2.ValueMember = "kod_tm";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);

            string q =
            " SELECT kod_tm," +
               " kol_n AS 'Количество НС' " +
               " , kol_s AS 'Количество СНС' " +
               ",data AS 'Дата' " +
            " FROM dbo.Neschastn_sluch " +
            " WHERE kod_tm = " + comboBox2.SelectedValue;
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {



            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
               chart1.Series["Series1"].Points.AddXY(i, Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()));
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                chart2.Series["Series1"].Points.AddXY(i, Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString()));
            }
        }
    }
}
