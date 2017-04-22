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
    public partial class Podtemi : Form
    {
        public Podtemi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Punkti formPunkti = new Punkti();
            formPunkti.MdiParent = this.MdiParent;
            formPunkti.Show();
        }

        private void Podtemi_Load(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_ptm," +
                  "podtema AS 'Подтема' " +
               "FROM Podtemi " +
               "WHERE kod_tm = " + Dannie.KodTem;
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
            dopPodtem formDopPodtem = new dopPodtem();
            formDopPodtem.MdiParent = this.MdiParent;
            formDopPodtem.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.PodTem = dataGridView1.Rows[nomStr].Cells[1].Value.ToString();
            Dannie.KodPodTem = Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ud u = new ud();
            u.MdiParent = this.MdiParent;
            Dannie.Ud = "7";
            u.Show();
        }
    }
}
