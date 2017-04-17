﻿using System;
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
    public partial class redKvalif : Form
    {
        public redKvalif()
        {
            InitializeComponent();
            textBox1.Text = Dannie.Value;
        }

        private void redKval() {
            if (textBox1.Text == "") MessageBox.Show("Заполните поле!");
            else
            {
                Form1 f1 = new Form1();
                SqlConnection sc = new SqlConnection(f1.connect);
                SqlCommand cmd;
                sc.Open();

                cmd = new SqlCommand("UPDATE Grup_bez SET kvalif=" + "'" + textBox1.Text + "'" + "Where kod_kv=" + "'" + Dannie.Id + "'", sc);

                cmd.ExecuteNonQuery();
                sc.Close();
                //Синхронизация с базой -------------------------------------------------
                LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                //-----------------------------------------------------------------------
                this.Close();
            }
        }
        private void redKvalif_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            redKval();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                redKval();
            }
        }
    }
}
