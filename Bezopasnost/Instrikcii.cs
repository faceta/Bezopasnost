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
    public partial class Instrikcii : Form
    {
        public Instrikcii()
        {
            InitializeComponent();
        }

        private void Instrikcii_Load(object sender, EventArgs e)
        {

        }

        private void Instrikcii_Activated(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_inst," +
                  "instrukc AS 'Инструкция' " +
               "FROM Instrukcii " +
               "WHERE kod_v = " + Dannie.KodVid;
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.Instr = dataGridView1.Rows[nomStr].Cells[1].Value.ToString();
            Dannie.KodInst = Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Temi formTemi = new Temi();
            formTemi.MdiParent = this.MdiParent;
            formTemi.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dobInstr formDobInstr = new dobInstr();
            formDobInstr.MdiParent = this.MdiParent;
            formDobInstr.Show();
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            redInstr formRedInstr = new redInstr();
            formRedInstr.MdiParent = this.MdiParent;
            formRedInstr.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ud u = new ud();
            u.MdiParent = this.MdiParent;
            Dannie.Ud = "5";
            u.Show();
        }
    }
}
