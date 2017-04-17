using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Bezopasnost
{
    public partial class Uvedomleniya : Form
    {
        public Uvedomleniya()
        {
            InitializeComponent();
        }

        public string email, pass;

        public void up()
        {
            string q;

            Form1 f1 = new Form1();
            SqlConnection conn = new SqlConnection(f1.connect);

            q = " Select " +
                " kod_r  " +
                " , fio as 'Работник' " +
                " , email as 'E-mail' " +
                " , otmetka as 'Отметка'  " +
            " from Rabotni "
            ;

            SqlDataAdapter ad = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            ad.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void Uvedomleniya_Load(object sender, EventArgs e)
        {
            up();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = dataGridView1.CurrentCell.RowIndex;
            string d = dataGridView1.Rows[s].Cells[0].Value.ToString();

            Form1 f1 = new Form1();
            SqlConnection sc = new SqlConnection(f1.connect);
            SqlCommand cmd;
            sc.Open();
            cmd = new SqlCommand("UPDATE Rabotni SET otmetka='true' Where kod_r=" + d, sc);
            cmd.ExecuteNonQuery();
            sc.Close();
            //Синхронизация с базой -------------------------------------------------
            LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
            Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
            //-----------------------------------------------------------------------
            up();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int s = dataGridView1.CurrentCell.RowIndex;
            string d = dataGridView1.Rows[s].Cells[0].Value.ToString();

            Form1 f1 = new Form1();
            SqlConnection sc = new SqlConnection(f1.connect);
            SqlCommand cmd;
            sc.Open();
            cmd = new SqlCommand("UPDATE Rabotni SET otmetka='false' Where kod_r=" + d, sc);
            cmd.ExecuteNonQuery();
            sc.Close();
            //Синхронизация с базой -------------------------------------------------
            LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
            Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
            //-----------------------------------------------------------------------
            up();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Otpravk o = new Otpravk();

            o.email = email;
            o.pass = pass;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                o.comboBox1.Items.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                // MessageBox.Show(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }

            o.Show();
        }
    }
}
