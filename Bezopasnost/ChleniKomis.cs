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
    public partial class ChleniKomis : Form
    {
        public ChleniKomis()
        {
            InitializeComponent();
        }

        public void Chlini_Kom() {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_k," +
                  "fio AS 'ФИО' " +
                  ", organizaciya AS 'Организация' " +
                  ", otdel AS 'Отдел' " +
                  ", dolzhnost AS 'Должность' " +
               "FROM Chleni_komissii "
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 35;
            }
        }

        private void ChleniKomis_Activated(object sender, EventArgs e)
        {
            Chlini_Kom();
        }

        private void ChleniKomis_Load(object sender, EventArgs e)
        {
            Chlini_Kom();
        }
    }
}
