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
    public partial class redPudPunktics : Form
    {
        public redPudPunktics()
        {
            InitializeComponent();
            textBox1.Text = Dannie.Punkt;
            textBox2.Text = Dannie.SoderzhPP;
        }

        private void redPodPunkt()
        {
            if (textBox1.Text == "") MessageBox.Show("Заполните поле!");
            else
            {
                Form1 f1 = new Form1();
                SqlConnection sc = new SqlConnection(f1.connect);
                SqlCommand cmd;
                sc.Open();

                cmd = new SqlCommand("UPDATE PodPunkti SET podpunkti = " + "'" + textBox1.Text + "', soderzh = '" + textBox2.Text + "'" + " Where kod_pp = " + "'" + Dannie.KodPodPunkt + "'", sc);

                cmd.ExecuteNonQuery();
                sc.Close();
                //Синхронизация с базой -------------------------------------------------
                LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                //-----------------------------------------------------------------------
                this.Close();

            }
        }

        private void redPudPunktics_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            redPodPunkt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
