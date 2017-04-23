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
    public partial class Prilozh : Form
    {
        public Prilozh()
        {
            InitializeComponent();
        }

        public void Prilo()
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               " SELECT kod_pr " +
                  " ,prilozh AS 'Ссылка на приожение' " +
               " FROM Prilozheniya " +
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
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 35;
            }
        }

        private void Prilozh_Load(object sender, EventArgs e)
        {
            Prilo();
        }

        private void Prilozh_Activated(object sender, EventArgs e)
        {
            Prilo();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dobPrilozh formDobPrilozh = new dobPrilozh();
            formDobPrilozh.MdiParent = this.MdiParent;
            formDobPrilozh.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.Prilog = dataGridView1.Rows[nomStr].Cells[1].Value.ToString();
            Dannie.KodPrilog = Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            redPrilozh formRedPrilozh = new redPrilozh();
            formRedPrilozh.MdiParent = this.MdiParent;
            formRedPrilozh.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ud u = new ud();
            u.MdiParent = this.MdiParent;
            Dannie.Ud = "10";
            u.Show();
        }
    }
}
