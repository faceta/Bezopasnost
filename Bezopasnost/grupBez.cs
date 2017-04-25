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
    public partial class grupBez : Form
    {
        public grupBez()
        {
            InitializeComponent();
        }

        private void grupBez_Activated(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_kv," +
                  "kvalif AS 'Квалификация' " +
               "FROM Grup_bez "
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            //dataGridView1.Columns[1].Width = dataGridView1.Size.Width - 45;
        
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            //{
            //    dataGridView1.Rows[i].Height = 35;
            //}

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dobKvalif formDobKvalif = new dobKvalif();
            formDobKvalif.MdiParent = this.MdiParent;
            formDobKvalif.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.Value = dataGridView1.Rows[nomStr].Cells[1].Value.ToString();
            Dannie.Id = dataGridView1.Rows[nomStr].Cells[0].Value.ToString();
       
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            redKvalif formDobKvalif = new redKvalif();
            formDobKvalif.MdiParent = this.MdiParent;
            formDobKvalif.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ud u = new ud();
            u.MdiParent = this.MdiParent;
            Dannie.Ud = "2";
            u.Show();
        }

        private void grupBez_Load(object sender, EventArgs e)
        {

        }

       
    }
}
