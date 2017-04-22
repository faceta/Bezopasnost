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
    public partial class Punkti : Form
    {
        public Punkti()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dopPunkti formDopPunkti = new dopPunkti();
            formDopPunkti.MdiParent = this.MdiParent;
            formDopPunkti.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.Punkt = dataGridView1.Rows[nomStr].Cells[1].Value.ToString();
            Dannie.SoderzhP = dataGridView1.Rows[nomStr].Cells[2].Value.ToString();
            Dannie.KodPunkt = Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ud u = new ud();
            u.MdiParent = this.MdiParent;
            Dannie.Ud = "8";
            u.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            redPunkti formRedPunkti = new redPunkti();
            formRedPunkti.MdiParent = this.MdiParent;
            formRedPunkti.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PodPunkti formPodPunkti = new PodPunkti();
            formPodPunkti.MdiParent = this.MdiParent;
            formPodPunkti.Show();
        }

        private void Punkti_Load(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               " SELECT kod_p," +
                  " punkt AS 'Пункт' " +
                  " soderzh AS 'Содержание' " +
               " FROM Podtemi " +
               " WHERE kod_tm = " + Dannie.KodTem +
               " OR kod_ptm = " + Dannie.KodPodTem
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false; 
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
