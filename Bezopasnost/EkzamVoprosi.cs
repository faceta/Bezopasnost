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
    public partial class EkzamVoprosi : Form
    {
        public EkzamVoprosi()
        {
            InitializeComponent();
        }

        private void EkzamVoprosi_Load(object sender, EventArgs e)
        {
            VopTest();
        }

        public void VopTest()
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               " SELECT kod_vop," +
                  " vopros AS 'Вопросы' " +
               " FROM Voprosi "
               ;
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            EkzVop();
        }

        public void EkzVop()
        {

            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               " SELECT kod_vop," +
                  " vopros AS 'Вопросы' " +
               " FROM Voprosi " +
               " WHERE ek = 'True' "
               ;
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;

            Form1 f1 = new Form1();
            SqlConnection sc = new SqlConnection(f1.connect);
            SqlCommand cmd;
            sc.Open();

            cmd = new SqlCommand("UPDATE Voprosi SET ek = 'True' Where kod_vop  = " + Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString()), sc);

            cmd.ExecuteNonQuery();
            sc.Close();
            //Синхронизация с базой -------------------------------------------------
            LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
            Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
            //-----------------------------------------------------------------------
            EkzVop();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Form1 f1 = new Form1();
            SqlConnection sc = new SqlConnection(f1.connect);
            SqlCommand cmd;
            sc.Open();

            cmd = new SqlCommand("UPDATE Voprosi SET ek = 'False' Where kod_vop  = " + Convert.ToInt32(dataGridView2.Rows[nomStr].Cells[0].Value.ToString()), sc);

            cmd.ExecuteNonQuery();
            sc.Close();
            //Синхронизация с базой -------------------------------------------------
            LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
            Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
            //-----------------------------------------------------------------------
            EkzVop();
        }

        private void dobVop()
        {

            if (textBox1.Text == "") MessageBox.Show("Заполните поле!");
            else
            {
                Form1 formGlavn = new Form1();
                SqlConnection sc = new SqlConnection(formGlavn.connect);
                SqlCommand cmd;
                sc.Open();
                cmd = new SqlCommand("INSERT INTO Voprosi(vopros, ek) VALUES ('" + textBox1.Text + "', 'True' )", sc);
                cmd.ExecuteNonQuery();
                sc.Close();
                //Синхронизация с базой -------------------------------------------------
                LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                //-----------------------------------------------------------------------
                EkzVop();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dobVop();
        }

        private void EkzamVoprosi_Activated(object sender, EventArgs e)
        {
            VopTest();
        }

    }
}

