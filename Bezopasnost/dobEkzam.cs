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
    public partial class dobEkzam : Form
    {
        public dobEkzam()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        private void dobEk()
        {

            
                Form1 formGlavn = new Form1();
                SqlConnection sc = new SqlConnection(formGlavn.connect);
                SqlCommand cmd;
                sc.Open();
                cmd = new SqlCommand("INSERT INTO Ekzamen(data) VALUES ('" + dateTimePicker1.Value.Date + "'" + " )", sc);
                cmd.ExecuteNonQuery();
                sc.Close();
                //Синхронизация с базой -------------------------------------------------
                LocalDataCache1SyncAgent syncAgent = new LocalDataCache1SyncAgent();
                Microsoft.Synchronization.Data.SyncStatistics syncStats = syncAgent.Synchronize();
                //-----------------------------------------------------------------------
                this.Close();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dobEk();
        }
    }
}
