using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

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
            /*
            chart1.Series["Series1"].Points.AddXY(1, 3); 
            chart1.Series["Series1"].Points.AddXY(2, 5); 
            chart1.Series["Series1"].Points.AddXY(3, 7); 
            chart1.Series["Series1"].Points.AddXY(4, 9); 
            chart1.Series["Series1"].Points.AddXY(5, 11); 
            chart1.Series["Series1"].Points.AddXY(6, 11); 
            chart1.Series["Series1"].Points.AddXY(7.5, 9);

            chart1.Series["Series1"].ChartType = SeriesChartType.Spline;
            chart1.Series["Series1"].IsValueShownAsLabel = true;
             */

            /*
            this.chart1.Series.Clear();



            Series series = this.chart1.Series.Add("Total Income");
            series.ChartType = SeriesChartType.Spline;

            series.Points.AddXY("Декабрь", 12);
            series.Points.AddXY("Январь", 1);
            series.Points.AddXY("Февраль", 2);

            series.Points.AddXY("Март", 3);
            series.Points.AddXY("Апрель", 4);
            series.Points.AddXY("Май", 5);

            series.Points.AddXY("Июнь", 6);
            series.Points.AddXY("Июль", 7);
            series.Points.AddXY("Август", 8);

            series.Points.AddXY("Сентябрь", 9);
            series.Points.AddXY("Октябрь", 10);
            series.Points.AddXY("Ноябрь", 11);
             * */
            
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
               " , data AS 'Дата' " +
               " , MONTH(data) Month1 " +
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
            //dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        public string k;
        private void button1_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
               
               if(i == 0) k = "Декабрь".ToString(); {
               if(i == 1) k = "Январь".ToString(); {
               if(i == 2) k = "Февраль".ToString(); {
               if(i == 3) k = "Март".ToString(); {
               if(i == 4) k = "Апрель".ToString(); {
               if(i == 5) k = "Май".ToString(); {
               if(i == 6) k = "Июнь".ToString(); {
               if(i == 7) k = "Июль".ToString(); {
               if(i == 8) k = "Август".ToString(); {
               if(i == 9) k = "Сентябрь".ToString(); {
               if(i == 10) k = "Октябрь".ToString(); {
               if(i == 11) k = "Ноябрь".ToString(); {
                   if (i == 12) k = "Декабрь".ToString();
                   {
                       chart1.Series["Несчастные случаи"].Points.AddXY(k, Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()));
                       chart1.Series["Несчастные случаи"].ChartType = SeriesChartType.Spline;
                       chart1.Series["Несчастные случаи"].IsValueShownAsLabel = true;
                       //chart1.Series["Несчастные случаи"].Points.DataBindXY(dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
                   }
               }
               }
               }
               }
               }
               }
               }
               }
               }
               }
               }
               }
           }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if(i == 0) k = "Декабрь".ToString(); {
               if(i == 1) k = "Январь".ToString(); {
               if(i == 2) k = "Февраль".ToString(); {
               if(i == 3) k = "Март".ToString(); {
               if(i == 4) k = "Апрель".ToString(); {
               if(i == 5) k = "Май".ToString(); {
               if(i == 6) k = "Июнь".ToString(); {
               if(i == 7) k = "Июль".ToString(); {
               if(i == 8) k = "Август".ToString(); {
               if(i == 9) k = "Сентябрь".ToString(); {
               if(i == 10) k = "Октябрь".ToString(); {
               if(i == 11) k = "Ноябрь".ToString(); {
                   if (i == 12) k = "Декабрь".ToString();
                   {
                chart1.Series["Смертельные несчастные случаи"].Points.AddXY(k, Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                chart1.Series["Смертельные несчастные случаи"].ChartType = SeriesChartType.Spline;
                chart1.Series["Смертельные несчастные случаи"].IsValueShownAsLabel = true;
                //chart1.Series["Смертельные несчастные случаи"].Points.DataBindXY(i.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                         }
               }
               }
               }
               }
               }
               }
               }
               }
               }
               }
               }
               }
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if(i == 0) k = "Декабрь".ToString(); {
               if(i == 1) k = "Январь".ToString(); {
               if(i == 2) k = "Февраль".ToString(); {
               if(i == 3) k = "Март".ToString(); {
               if(i == 4) k = "Апрель".ToString(); {
               if(i == 5) k = "Май".ToString(); {
               if(i == 6) k = "Июнь".ToString(); {
               if(i == 7) k = "Июль".ToString(); {
               if(i == 8) k = "Август".ToString(); {
               if(i == 9) k = "Сентябрь".ToString(); {
               if(i == 10) k = "Октябрь".ToString(); {
               if(i == 11) k = "Ноябрь".ToString(); {
                   if (i == 12) k = "Декабрь".ToString();
                   {
                chart1.Series["Общее количество несчастных случаев"].Points.AddXY(k, Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()) + Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                chart1.Series["Общее количество несчастных случаев"].ChartType = SeriesChartType.Spline;
                chart1.Series["Общее количество несчастных случаев"].IsValueShownAsLabel = true;
                //chart1.Series["Смертельные несчастные случаи"].Points.DataBindXY(i.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                   }
               }
               }
               }
               }
               }
               }
               }
               }
               }
               }
               }
                }
            }
            
        }
    }
}
