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
    public partial class dobRabotn : Form
    {
        public dobRabotn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void redR() {
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
        private void dobRabotn_Activated(object sender, EventArgs e)
        {
            redR();
        }

        private void dobRabotn_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }

        public void dobRabotni()
        {

            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "") MessageBox.Show("Заполните все поле!");
            else
            {
                Form1 formGlavn = new Form1();
                SqlConnection sc = new SqlConnection(formGlavn.connect);
                SqlCommand cmd;
                sc.Open();
                cmd = new SqlCommand("INSERT INTO Rabotni(fio, nom_ud, otm_o_sdch, kod_dolzh, kod_kv, kod_vd, email, otmetka, Password1) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox3.SelectedValue + "', '" + comboBox1.SelectedValue + "', '" + comboBox2.SelectedValue + "', '" + textBox4.Text + "', 'False', '" + textBox5.Text + "' )", sc);
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
            dobRabotni();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
