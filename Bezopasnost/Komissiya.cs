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
    public partial class Komissiya : Form
    {
        public Komissiya()
        {
            InitializeComponent();
        }

        private void вопросыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EkzamVoprosi ek = new EkzamVoprosi();
            ek.ShowDialog();
        }

        public void up() {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               " SELECT " +
                  " fio as 'ФИО' " +
                  " , balli as 'Баллы' " +
                  " , dopolnit as 'Дополнительный вопрос' " +
                  " , ocenka as 'Оценка' " +
               " FROM Rabotni r " +
               " LEFT JOIN Soderzhanie so ON r.kod_r = so.kod_r " +
               " LEFT JOIN Ekzamen ek ON ek.kod_ek = so.kod_ek ";
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           
        }

        private void Komissiya_Load(object sender, EventArgs e)
        {
            up();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            up();
        }
    }
}
