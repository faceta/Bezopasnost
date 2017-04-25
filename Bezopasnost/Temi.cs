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
    public partial class Temi : Form
    {
        public Temi()
        {
            InitializeComponent();
        }

        private void Temi_Activated(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_tm," +
                  "tema AS 'Тема' " +
               "FROM Temi " +
               "WHERE kod_inst = " + Dannie.KodInst;
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
            //for (int i = 0; i <= dataGridView1.Rows.Count; i++)
           // {
            //    dataGridView1.Rows[i].Height = 35;
          //  }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Podtemi formPodtem = new Podtemi();
            formPodtem.MdiParent = this.MdiParent;
            formPodtem.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Punkti formPunkti = new Punkti();
            formPunkti.MdiParent = this.MdiParent;
            formPunkti.Show();
        }

        private void Temi_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dobTemi formDobTemi = new dobTemi();
            formDobTemi.MdiParent = this.MdiParent;
            formDobTemi.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            redTemi formRedTemi = new redTemi();
            formRedTemi.MdiParent = this.MdiParent;
            formRedTemi.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.Tem = dataGridView1.Rows[nomStr].Cells[1].Value.ToString();
            Dannie.KodTem = Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ud u = new ud();
            u.MdiParent = this.MdiParent;
            Dannie.Ud = "6";
            u.Show();
        }
    }
}
  