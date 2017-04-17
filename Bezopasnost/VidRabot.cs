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
    public partial class VidRabot : Form
    {
        public VidRabot()
        {
            InitializeComponent();
        }

        private void VidRabot_Activated(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_v," +
                  "vid_rabot AS 'Вид работы' " +
               "FROM Vidi_rabot "
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

        private void VidRabot_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dobVidRabot formVidRabot = new dobVidRabot();
            formVidRabot.MdiParent = this.MdiParent;
            formVidRabot.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            redVidRabot formVidRabot = new redVidRabot();
            formVidRabot.MdiParent = this.MdiParent;
            formVidRabot.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ud u = new ud();
            u.MdiParent = this.MdiParent;
            Dannie.Ud = "3";
            u.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.Value = dataGridView1.Rows[nomStr].Cells[1].Value.ToString();
            Dannie.Id = dataGridView1.Rows[nomStr].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Instrikcii formRabot = new Instrikcii();
            formRabot.MdiParent = this.MdiParent;
            formRabot.Show();
        }
    }
}
