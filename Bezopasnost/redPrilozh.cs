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
    public partial class redPrilozh : Form
    {
        public redPrilozh()
        {
            InitializeComponent();
            textBox1.Text = Dannie.Prilog;
        }

        private void redPril()
        {
            if (textBox1.Text == "") MessageBox.Show("Заполните поле!");
            else
            {
                Form1 f1 = new Form1();
                SqlConnection sc = new SqlConnection(f1.connect);
                SqlCommand cmd;
                sc.Open();

                cmd = new SqlCommand("UPDATE Prilozheniya SET prilozh = " + "'" + textBox1.Text + "'" + " Where kod_pr=" + "'" + Dannie.KodPrilog + "'", sc);

                cmd.ExecuteNonQuery();
                sc.Close();
                //Синхронизация с базой -------------------------------------------------
                LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                //-----------------------------------------------------------------------
                this.Close();

            }
        }

        private void redPrilozh_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            redPril();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Documents|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
                textBox1.Text = ofd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
