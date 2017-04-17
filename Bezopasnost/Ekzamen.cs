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
    public partial class Ekzamen : Form
    {
        public Ekzamen()
        {
            InitializeComponent();
        }

        public int schetchik, schetchik2;


        public void testik()
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);

            string sql =
               " SELECT kod_tm " +
                  " , tema " +
               " FROM Temi " +
               " Where kod_inst = " + Dannie.KodInst
            ;

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            string sql2 =
                " SELECT TOP 3 vopros, kod_vop " +
                " FROM Voprosi " +
                " WHERE kod_tm = " + Convert.ToInt32(dataGridView2.Rows[schetchik2].Cells[0].Value.ToString()) +
                " ORDER BY NEWID() "
            ;

            SqlDataAdapter adapter1 = new SqlDataAdapter(sql2, conn);
            DataSet ds1 = new DataSet();
            conn.Open();
            adapter1.Fill(ds1);
            conn.Close();
            dataGridView1.DataSource = ds1.Tables[0];
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }
        public void testik2()
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string sql3 =
                            " SELECT otvet, kod_otv, otmetka " +
                            " FROM Otveti " +
                            " WHERE kod_vop = " + Convert.ToInt32(dataGridView1.Rows[schetchik - 1].Cells[1].Value.ToString()) +
                            " ORDER BY NEWID() "
                        ;

            SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
            DataSet ds3 = new DataSet();
            conn.Open();
            adapter3.Fill(ds3);
            conn.Close();
            dataGridView3.DataSource = ds3.Tables[0];
            //dataGridView3.Columns[1].Visible = false;
            //dataGridView3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            int kol1 = 1;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            //kol1 = dataGridView3.Rows.Count;
            //textBox2.Text = dataGridView3.Rows.Count.ToString();
            if (dataGridView3.Rows.Count >= kol1)
            {
                checkBox1.Text = dataGridView3.Rows[0].Cells[0].Value.ToString();
                kol1 += 1;
                checkBox1.Visible = true;

                if (dataGridView3.Rows.Count >= kol1)
                {
                    checkBox2.Text = dataGridView3.Rows[1].Cells[0].Value.ToString();
                    kol1 += 1;
                    checkBox2.Visible = true;

                    if (dataGridView3.Rows.Count >= kol1)
                    {
                        checkBox3.Text = dataGridView3.Rows[2].Cells[0].Value.ToString();
                        kol1 += 1;
                        checkBox3.Visible = true;

                        if (dataGridView3.Rows.Count >= kol1)
                        {
                            checkBox4.Text = dataGridView3.Rows[3].Cells[0].Value.ToString();
                            kol1 += 1;
                            checkBox4.Visible = true;

                            if (dataGridView3.Rows.Count >= kol1)
                            {
                                checkBox5.Text = dataGridView3.Rows[4].Cells[0].Value.ToString();
                                checkBox5.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        private void Ekzamen_Load(object sender, EventArgs e)
        {
            testik();
            schetchik = 0;
            schetchik2 = 0;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Text = "Далее >> ";
            textBox1.Text = dataGridView1.Rows[schetchik].Cells[0].Value.ToString();
            //textBox2.Text = schetchik.ToString();
            schetchik += 1;
            if (dataGridView1.Rows.Count == schetchik)
            {
                button1.Visible = false;
                button2.Visible = true;
            }
            testik2();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            schetchik2 += 1;
            if (dataGridView2.Rows.Count - 1 == schetchik2)
            {
                button1.Visible = false;
                button2.Visible = true;
                //button2.Text = "Завершить";
                button2.Enabled = false;

                textBox1.Text = "Вы прошли тест на столько-то процентов. Если меньше 90% рекомендуется повторить материал.";

            }
            else
            {
                testik();
                schetchik = 0;
                button1.Visible = true;
                button2.Visible = false;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
