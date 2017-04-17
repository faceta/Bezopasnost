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
    public partial class Vid_r : Form
    {
        public Vid_r()
        {
            InitializeComponent();
        }

        private void Vid_r_Load(object sender, EventArgs e)
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
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.KodVid = Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString());
            Close();
            

        }
    }
}
