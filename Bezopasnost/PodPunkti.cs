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
    public partial class PodPunkti : Form
    {
        public PodPunkti()
        {
            InitializeComponent();
        }

        private void PodPunkti_Load(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_pp," +
                  "podpunkti AS 'Подпункты' " +
                  "soderzh AS 'Содержание' " +
               "FROM PodPunkti " +
               "WHERE kod_p = " + Dannie.KodPunkt;
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PodPunkti formPodPunkti = new PodPunkti();
            formPodPunkti.MdiParent = this.MdiParent;
            formPodPunkti.Show();
        }
    }
}
