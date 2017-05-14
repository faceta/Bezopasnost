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
    public partial class dobKom : Form
    {
        public dobKom()
        {
            InitializeComponent();
        }

        public void ChliniKom()
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT kod_k," +
                  " fio AS 'Члены комиссии' " +
                  " ,dolzhnost AS 'Должность' " +
               "FROM Chleni_komissii "
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0];
            
            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ChliniEk();
        
            
        }

        public void ChliniEk()
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn2 = new SqlConnection(formGlavn.connect);
            string q2 =
               " SELECT k.kod_k, " +
                  " fio AS 'Комиссия экзамена' " +
                  
               " FROM Chleni_komissii ck " +
               " JOIN  Komissiya k ON ck.kod_k = k.kod_k " +
               " Where kod_ek = " + Dannie.KodEk
            ;
            SqlDataAdapter adapter2 = new SqlDataAdapter(q2, conn2);
            DataSet ds2 = new DataSet();
            conn2.Open();
            adapter2.Fill(ds2);
            conn2.Close();
            dataGridView2.DataSource = ds2.Tables[0];

            dataGridView2.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    
          
        }

        private void dobKom_Load(object sender, EventArgs e)
        {
            ChliniKom();
            
           
        }

        private void dobKom_Activated(object sender, EventArgs e)
        {
            ChliniKom();
            
           
        }

        private void dobKomis()
        {

                int nomStr = dataGridView1.CurrentCell.RowIndex;
                Form1 formGlavn = new Form1();
                SqlConnection sc = new SqlConnection(formGlavn.connect);
                SqlCommand cmd;
                sc.Open();
                cmd = new SqlCommand("INSERT INTO Komissiya(kod_ek, kod_k) VALUES (" + Dannie.KodEk + ", " + Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString()) + " )", sc);
                cmd.ExecuteNonQuery();
                sc.Close();
                //Синхронизация с базой -------------------------------------------------
                LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                //-----------------------------------------------------------------------
                ChliniEk(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dobKomis();
        }

        public void udEkKom() {
                int nomStr = dataGridView2.CurrentCell.RowIndex;
                Form1 f1 = new Form1();
                SqlConnection conn = new SqlConnection(f1.connect);
                SqlCommand cmd;
                conn.Open();
                cmd = new SqlCommand("DELETE FROM Komissiya WHERE kod_ek = " + Dannie.KodEk + " AND kod_k = " + Convert.ToInt32(dataGridView2.Rows[nomStr].Cells[0].Value.ToString()), conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                ChliniEk(); 
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            udEkKom();

        }
    }
}
