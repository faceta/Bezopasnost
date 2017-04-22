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
    public partial class Dolzhn : Form
    {
        public Dolzhn()
        {
            InitializeComponent();
        }
        public int kursorVeaw = 0;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           
            dobDolzhn formDobDolzhn = new dobDolzhn();
            formDobDolzhn.MdiParent = this.MdiParent;
            formDobDolzhn.Show();
           
        }

        public void Dolzh()
        {
            Form1 formGlavn = new Form1();

            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_d, " +
                  "dolzhn AS 'Должность' " +
               "FROM Dolzhnost "
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.RowHeadersVisible = false;

        }

        private void Dolzhn_Activated(object sender, EventArgs e)
        {
            Dolzh();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {        
            redDolzhn formDobRabotn = new redDolzhn();
            formDobRabotn.MdiParent = this.MdiParent;
            formDobRabotn.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ud u = new ud();
            u.MdiParent = this.MdiParent;
            Dannie.Ud = "1";
            u.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.Value = dataGridView1.Rows[nomStr].Cells[1].Value.ToString();
            Dannie.Id = dataGridView1.Rows[nomStr].Cells[0].Value.ToString();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Dolzhn_Load(object sender, EventArgs e)
        {
            
        }
    }
}
