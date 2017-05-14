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
            DobVop dVop = new DobVop();
            dVop.Show();
        }

        public void up() {

            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               " SELECT so.kod_r," +
                  " fio as 'ФИО' " +
                  " , balli as 'Баллы' " +
                  " , dopolnit as 'Дополнительный вопрос' " +
                  " , ocenka as 'Оценка' " +
               " FROM Rabotni r " +
               " LEFT JOIN Soderzhanie so ON r.kod_r = so.kod_r " +
               " LEFT JOIN Ekzamen ek ON ek.kod_ek = so.kod_ek " +
               " WHERE so.kod_ek = " + Dannie.KodEk +
               " ORDER BY fio"
               ;
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 580;
            dataGridView1.Columns[4].Width = 30;
            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

           // for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            //{
            //    dataGridView1.Rows[i].Height = 35;
           // } 
        }

        private void Komissiya_Load(object sender, EventArgs e)
        {
            up();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            up();
        }

        private void Komissiya_Activated(object sender, EventArgs e)
        {
            up();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            if (textBox1.Text == "") MessageBox.Show("Ввидите вопрос!");
            else
            {
                Form1 f1 = new Form1();
                SqlConnection sc = new SqlConnection(f1.connect);
                SqlCommand cmd;
                sc.Open();

                cmd = new SqlCommand("UPDATE Soderzhanie SET dopolnit = " + "'" + textBox1.Text + "'" + " Where kod_ek  = " + Dannie.KodEk + " AND kod_r = " + Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString()), sc);

                cmd.ExecuteNonQuery();
                sc.Close();
                //Синхронизация с базой -------------------------------------------------
                LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                //-----------------------------------------------------------------------
                up();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.BackColor == SystemColors.Window)
            {
                int nomStr = dataGridView1.CurrentCell.RowIndex;
                if (textBox2.Text == "") MessageBox.Show("Ввидите вопрос!");
                else
                {
                    Form1 f1 = new Form1();
                    SqlConnection sc = new SqlConnection(f1.connect);
                    SqlCommand cmd;
                    sc.Open();

                    cmd = new SqlCommand("UPDATE Soderzhanie SET ocenka = " + "'" + textBox2.Text + "'" + " Where kod_ek  = " + Dannie.KodEk + " AND kod_r = " + Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString()), sc);

                    cmd.ExecuteNonQuery();
                    sc.Close();
                    //Синхронизация с базой -------------------------------------------------
                    LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                    Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                    //-----------------------------------------------------------------------
                    up();

                }
            }
            else {
                MessageBox.Show("Некорректный ввод оценки", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox2.Text) > 1 && Convert.ToInt32(textBox2.Text) < 6)
            {
                textBox2.BackColor = SystemColors.Window;
            }
            else {
                textBox2.BackColor = Color.Salmon;
            }
        }
    }
}
