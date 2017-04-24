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
    public partial class TestTemi : Form
    {
        public TestTemi()
        {
            InitializeComponent();
        }

        public int schetchik, schetchik2, schetchik3, kolPO = 0, schP = 0, schN = 0, kolP = 0, kolN = 0;
        public int itog;
        public int[] k = {0,0,0,0,0};

        
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
            //dataGridView2.Columns[0].Visible = false;
            //dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            string sql2 =
                " SELECT TOP 3 vopros, vop.kod_vop, COUNT(otvet) " +
                " FROM Voprosi vop " +
                " LEFT JOIN Otveti ot ON vop.kod_vop = ot.kod_vop " +
                " WHERE kod_tm = " + Convert.ToInt32(dataGridView2.Rows[schetchik2].Cells[0].Value.ToString()) + 
                   " AND otmetka = 1 " +
                " GROUP BY vopros, vop.kod_vop " +
                " ORDER BY NEWID() "
            ;

            SqlDataAdapter adapter1 = new SqlDataAdapter(sql2, conn);
            DataSet ds1 = new DataSet();
            conn.Open();
            adapter1.Fill(ds1);
            conn.Close();
            dataGridView1.DataSource = ds1.Tables[0];
            //dataGridView1.Columns[1].Visible = false;
            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            

              }
        public void testik2()
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string sql3 =
                            " SELECT otvet, kod_otv, otmetka " +
                            " FROM Otveti " +
                            " WHERE kod_vop = " + Convert.ToInt32(dataGridView1.Rows[schetchik-1].Cells[1].Value.ToString()) +
                            " ORDER BY NEWID() "
                        ;

            SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
            DataSet ds3 = new DataSet();
            conn.Open();
            adapter3.Fill(ds3);
            conn.Close();
            dataGridView3.DataSource = ds3.Tables[0];
            
            int kol1 = 1;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            
            if (dataGridView3.Rows.Count >= kol1)
            {
                button3.Text = dataGridView3.Rows[0].Cells[0].Value.ToString();
                kol1 += 1;
                button3.Enabled = true;

                if (dataGridView3.Rows.Count >= kol1)
                {
                    button4.Text = dataGridView3.Rows[1].Cells[0].Value.ToString();
                    kol1 += 1;
                    button4.Enabled = true;

                    if (dataGridView3.Rows.Count >= kol1)
                    {
                        button5.Text = dataGridView3.Rows[2].Cells[0].Value.ToString();
                        kol1 += 1;
                        button5.Enabled = true;

                        if (dataGridView3.Rows.Count >= kol1)
                        {
                            button6.Text = dataGridView3.Rows[3].Cells[0].Value.ToString();
                            kol1 += 1;
                            button6.Enabled = true;

                            if (dataGridView3.Rows.Count >= kol1)
                            {
                                button7.Text = dataGridView3.Rows[4].Cells[0].Value.ToString();
                                button7.Enabled = true;
                            }
                        }
                    }
                }
            }
        }
        private void TestTemi_Load(object sender, EventArgs e)
        {
            testik();
            schetchik = 0;
            schetchik2 = 0;
            schetchik3 = 0;
            button2.Enabled = false;
            
           

            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            schP = 0; 
            schN = 0;

            button1.Enabled = false;
            button2.Enabled = true;
            if (dataGridView1.Rows.Count == schetchik)
            {
                schetchik2 += 1;
                //textBox7.Text = schetchik2.ToString();
                if (dataGridView2.Rows.Count == schetchik2)
                {
                    //button1.Visible = false;
                    //button2.Visible = true;
                    //button2.Text = "Завершить";
                    button1.Enabled = false;
                    itog = (kolP * 100) / (kolP + kolN);
                    textBox1.Text = "Вы прошли тест на " + itog.ToString() + "%. Если меньше 90% рекомендуется повторить материал.";
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button3.Text = "";
                    button4.Text = "";
                    button5.Text = "";
                    button6.Text = "";
                    button7.Text = "";
                    button2.Enabled = false;
                }
                else
                {
                    testik();
                    schetchik = 0;
                    // button1.Visible = true;
                    // button2.Visible = false;
                    button1.Text = "Далее >> ";
                    textBox1.Text = dataGridView1.Rows[schetchik].Cells[0].Value.ToString();
                    //textBox2.Text = schetchik.ToString();
                    schetchik += 1;
                    //-------------------Загрузка ответов------------------
                    testik2();
                    
                    //kolPO = Convert.ToInt32(dataGridView1.Rows[schetchik].Cells[2].Value.ToString());
                    
                }
            }
            else
            {
                button1.Text = "Далее >> ";
                textBox1.Text = dataGridView1.Rows[schetchik].Cells[0].Value.ToString();
                //textBox2.Text = schetchik.ToString();
                schetchik += 1;
                //-------------------Загрузка ответов------------------
                testik2();
               // kolPO = Convert.ToInt32(dataGridView1.Rows[schetchik].Cells[2].Value.ToString());
                //textBox2.Text = kolPO.ToString();
                //textBox7.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            }

           

                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int l=0, l1=0;

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                l = Convert.ToInt32(dataGridView3.Rows[i].Cells[2].Value.ToString());
                l1 =  k[i];
                if (l == l1)
                {
                    schP += 1;
                    //textBox3.Text = schP.ToString();
                }
                else
                {
                    schN += 1;
                    //textBox4.Text = schN.ToString();
                }
            }
            if (schN == 0)
            {
                kolP += 1;
                textBox5.Text = kolP.ToString();
            }
            else
            {
                kolN += 1;
                textBox6.Text = kolN.ToString();
            }
            if (dataGridView2.Rows.Count == schetchik2)
            {
                button1.Enabled = false;
                itog = (kolP * 100) / (kolP + kolN);
            }
            else button1.Enabled = true;
            button3.BackColor = SystemColors.Control;
            button4.BackColor = SystemColors.Control;
            button5.BackColor = SystemColors.Control;
            button6.BackColor = SystemColors.Control;
            button7.BackColor = SystemColors.Control;
            for (int j = 0; j <= 4; j++) {
                k[j] = 0;
            }
            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == SystemColors.Control)
            {
                button3.BackColor = SystemColors.GradientInactiveCaption;
                k[0] = 1;
            }
            else 
            {
                button3.BackColor = SystemColors.Control;
                k[0] = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == SystemColors.Control)
            {
                button4.BackColor = SystemColors.GradientInactiveCaption;
                k[1] = 1;
            }
            else
            {
                button4.BackColor = SystemColors.Control;
                k[1] = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == SystemColors.Control)
            {
                button5.BackColor = SystemColors.GradientInactiveCaption;
                k[2] = 1;
            }
            else
            {
                button5.BackColor = SystemColors.Control;
                k[2] = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == SystemColors.Control)
            {
                button6.BackColor = SystemColors.GradientInactiveCaption;
                k[3] = 1;
            }
            else
            {
                button6.BackColor = SystemColors.Control;
                k[3] = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == SystemColors.Control)
            {
                button7.BackColor = SystemColors.GradientInactiveCaption;
                k[4] = 1;
            }
            else
            {
                button7.BackColor = SystemColors.Control;
                k[4] = 0;
            }
        }
    }
}
