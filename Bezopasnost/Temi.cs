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
               "WHERE kod_inst = " + Dannie.Instr;
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
    }
}
  