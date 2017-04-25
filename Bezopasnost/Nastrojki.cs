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
    public partial class Nastrojki : Form
    {
        public Nastrojki()
        {
            InitializeComponent();
        }

        private void Nastrojki_Load(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kol_vop," +
                  "kol_dop " +
               "FROM Nastrojki "
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];

            textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") MessageBox.Show("Заполните поля!");
            else
            {
                int prcV = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value.ToString());
                int prcDV = Convert.ToInt32(dataGridView1.Rows[0].Cells[1].Value.ToString());
                if ((prcV + prcDV) > 100) MessageBox.Show("Сумма процентов должна быть не более 100!");
                else
                {
                    Form1 f1 = new Form1();
                    SqlConnection sc = new SqlConnection(f1.connect);
                    SqlCommand cmd;
                    sc.Open();

                    cmd = new SqlCommand("UPDATE Nastrojki SET kol_vop = " + Convert.ToInt32(textBox1.Text) + ", kol_dop = " + Convert.ToInt32(textBox2.Text), sc);

                    cmd.ExecuteNonQuery();
                    sc.Close();
                    //Синхронизация с базой -------------------------------------------------
                    LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                    Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                    //-----------------------------------------------------------------------
                    this.Close();
                }

            }
        }
    }
}
