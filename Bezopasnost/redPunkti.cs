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
    public partial class redPunkti : Form
    {
        public redPunkti()
        {
            InitializeComponent();
            textBox1.Text = Dannie.Punkt;
            textBox2.Text = Dannie.SoderzhP;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void redPunkt()
        {
            if (textBox1.Text == "") MessageBox.Show("Заполните поле!");
            else
            {
                Form1 f1 = new Form1();
                SqlConnection sc = new SqlConnection(f1.connect);
                SqlCommand cmd;
                sc.Open();

                cmd = new SqlCommand("UPDATE Punkti SET punkt = " + "'" + textBox1.Text + "', soderzh = '" + textBox2.Text + "'" + " Where kod_p = " + "'" + Dannie.KodPunkt + "'", sc);

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
            redPunkt();
        }

        private void redPunkti_Load(object sender, EventArgs e)
        {

        }
    }
}
