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
    public partial class dobPrilozh : Form
    {
        public dobPrilozh()
        {
            InitializeComponent();
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

        private void dobPril()
        {

            if (textBox1.Text == "") MessageBox.Show("Заполните поле!");
            else
            {
                Form1 formGlavn = new Form1();
                SqlConnection sc = new SqlConnection(formGlavn.connect);
                SqlCommand cmd;
                sc.Open();
                cmd = new SqlCommand("INSERT INTO Prilozheniya(prilozh, kod_p) VALUES ('" + textBox1.Text + "', " + Dannie.KodPunkt + " )", sc);
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
            dobPril();
        }
    }
}
