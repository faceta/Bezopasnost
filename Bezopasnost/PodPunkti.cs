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
    public partial class PodPunkti : Form
    {
        public PodPunkti()
        {
            InitializeComponent();
        }

        public void PodPunk() {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               " SELECT kod_pp " +
                  " ,podpunkti AS 'Подпункты' " +
                  " ,soderzh AS 'Содержание' " +
               " FROM PodPunkti " +
               " WHERE kod_p = " + Dannie.KodPunkt;
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 35;
            }
        }

        private void PodPunkti_Load(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PodPunkti formPodPunkti = new PodPunkti();
            formPodPunkti.MdiParent = this.MdiParent;
            formPodPunkti.Show();
        }

        private void PodPunkti_Activated(object sender, EventArgs e)
        {
            PodPunk();
        }
    }
}
