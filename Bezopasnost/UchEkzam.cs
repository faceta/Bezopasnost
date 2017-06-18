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
    public partial class UchEkzam : Form
    {
        public UchEkzam()
        {
            InitializeComponent();
        }

        int nomStr=0, nomStr2=0;

        public void Rabot()
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT r.kod_r, " +
                  " fio AS 'ФИО' " +
               "FROM Rabotni r"
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void Uch()
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q2 =
               " SELECT fio " +
               " FROM Soderzhanie sod " +
               " JOIN Rabotni rab ON rab.kod_r = sod.kod_r " +
               " JOIN Ekzamen ek ON ek.kod_ek = sod.kod_ek " +
               " WHERE ek.kod_ek = " + Dannie.KodEk2
            ;
            SqlDataAdapter adapter2 = new SqlDataAdapter(q2, conn);
            DataSet ds2 = new DataSet();
            conn.Open();
            adapter2.Fill(ds2);
            conn.Close();

            dataGridView2.DataSource = ds2.Tables[0];
           // dataGridView2.Columns[1].Width = 250;
            dataGridView2.RowHeadersVisible = false;
            //dataGridView2.Columns[0].Visible = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void UchEkzam_Load(object sender, EventArgs e)
        {
            Rabot();
            Uch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* Form1 formGlavn = new Form1();
            SqlConnection sc = new SqlConnection(formGlavn.connect);
            SqlCommand cmd;
            sc.Open();
            cmd = new SqlCommand("INSERT INTO Soderzhanie(kod_vop, kod_r, kod_ek, kod_otv) VALUES (" + 56 + ", " + Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString()) + " )", sc);
            cmd.ExecuteNonQuery();
            sc.Close();
            //Синхронизация с базой -------------------------------------------------
            LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
            Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
            //-----------------------------------------------------------------------
            this.Close();*/
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
          //  int nomStr = dataGridView1.CurrentCell.RowIndex;
           // int nomStr2 = dataGridView2.CurrentCell.RowIndex;
            
        }
    }
}
