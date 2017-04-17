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
    public partial class redRabotn : Form
    {
        public redRabotn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void redR()
        {
            Form1 f1 = new Form1();
            SqlConnection conn = new SqlConnection(f1.connect);



            /*----------------------------------------Для квалификации---------------------------------------------------*/
            string queryKvalif =
               " SELECT " +
                   " gb.kod_kv " +
                   " , kvalif " +
               " FROM Grup_bez gb join Razdelenie r on gb.kod_kv = r.kod_kv join Vidi_rabot vr on r.kod_v = vr.kod_v " +
               " WHERE vr.kod_v = " + Dannie.KodVid;

            SqlDataAdapter adapterKvalif = new SqlDataAdapter(queryKvalif, conn);
            DataSet dsKvalif = new DataSet();
            conn.Open();
            adapterKvalif.Fill(dsKvalif);
            conn.Close();

            comboBox1.DataSource = dsKvalif.Tables[0];
            comboBox1.DisplayMember = "kvalif";
            comboBox1.ValueMember = "kod_kv";

            /*----------------------------------------Для вида работ---------------------------------------------------*/
            string queryVidRaboti =
               " SELECT " +
                  " kod_v " +
                  " , vid_rabot " +
               " FROM Vidi_rabot where kod_v = " + Dannie.KodVid;

            SqlDataAdapter adapterVidRabot = new SqlDataAdapter(queryVidRaboti, conn);
            DataSet dsVidRabot = new DataSet();
            conn.Open();
            adapterVidRabot.Fill(dsVidRabot);
            conn.Close();

            comboBox2.DataSource = dsVidRabot.Tables[0];
            comboBox2.DisplayMember = "vid_rabot";
            comboBox2.ValueMember = "kod_v";

            /*----------------------------------------Для должности---------------------------------------------------*/
            string queryDolzhn =
                " SELECT kod_d, " +
                  " dolzhn " +
               " FROM Dolzhnost ";

            SqlDataAdapter ad = new SqlDataAdapter(queryDolzhn, conn);
            DataSet ds = new DataSet();
            conn.Open();
            ad.Fill(ds);
            conn.Close();
            comboBox3.DataSource = ds.Tables[0];

            comboBox3.DisplayMember = "dolzhn";
            comboBox3.ValueMember = "kod_d";
        }

        private void redRabotn_Load(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT r.kod_r, " +
                  " fio " +
                  ", nom_ud " +
                  ", otm_o_sdch " +
                  ", email " +
                  ", Password1 " +
               "FROM Rabotni r " +
               " Where r.kod_r = " + Dannie.KodR           
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];

            textBox1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            redR();
        }

        private void redDolzh()
        {
            if (textBox1.Text == "") MessageBox.Show("Заполните поле!");
            else
            {
                Form1 f1 = new Form1();
                SqlConnection sc = new SqlConnection(f1.connect);
                SqlCommand cmd;
                sc.Open();

                cmd = new SqlCommand("UPDATE Rabotni SET fio=" + "'" + textBox1.Text + "', nom_ud='" + textBox2.Text + "', kod_dolzh ='" + comboBox3.SelectedValue + "', kod_kv ='" + comboBox1.SelectedValue + "', kod_vd ='" + comboBox2.SelectedValue + "', email ='" + textBox4.Text + "', Password1 ='" + textBox5.Text + "' Where kod_r=" + "'" + Dannie.KodR + "'", sc);

                cmd.ExecuteNonQuery();
                sc.Close();
                //Синхронизация с базой -------------------------------------------------
                LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                //-----------------------------------------------------------------------
                this.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            redDolzh();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
