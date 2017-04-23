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
    public partial class Ekzam : Form
    {
        public Ekzam()
        {
            InitializeComponent();
        }

        public void Ekz()
        {

            Form1 formGlavn = new Form1();

            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_ek, " +
                  "data AS 'Должность' " +
               "FROM Ekzamen "
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
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 35;
            }

        }

        private void Ekzam_Load(object sender, EventArgs e)
        {
            Ekz();
            if (Dannie.Komiss == 0)
            {
                toolStripSplitButton1.Visible = true;
                toolStripButton1.Visible = false;
            }
            else
            {
                toolStripSplitButton1.Visible = false;
                toolStripButton1.Visible = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void комиссияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dobKom formDobKom = new dobKom();
            formDobKom.MdiParent = this.MdiParent;
            formDobKom.Show();
        }

        private void новыйЭкзаменToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dobEkzam formDobEkzam = new dobEkzam();
            formDobEkzam.MdiParent = this.MdiParent;
            formDobEkzam.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.DataEk = dataGridView1.Rows[nomStr].Cells[0].Value.ToString();
            Dannie.KodEk = Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString());
        }

        private void Ekzam_Activated(object sender, EventArgs e)
        {
            Ekz();
            if (Dannie.Komiss == 0)
            {
                toolStripSplitButton1.Visible = true;
                toolStripButton1.Visible = false;
            }
            else
            {
                toolStripSplitButton1.Visible = false;
                toolStripButton1.Visible = true;
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Komissiya formKomissiya = new Komissiya();
            formKomissiya.MdiParent = this.MdiParent;
            formKomissiya.Show();
        }
    }
}
