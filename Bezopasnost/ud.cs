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
    public partial class ud : Form
    {
        public ud()
        {
            InitializeComponent();
        }

        private void udRabotn_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dannie.Ud = "0";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Dannie.Ud == "1")
            {
                Form1 f1 = new Form1();
                SqlConnection conn = new SqlConnection(f1.connect);
                SqlCommand cmd;
                conn.Open();
                cmd = new SqlCommand("DELETE FROM Dolzhnost WHERE kod_d=" + "'" + Dannie.Id + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            if (Dannie.Ud == "2")
            {
                Form1 f1 = new Form1();
                SqlConnection conn = new SqlConnection(f1.connect);
                SqlCommand cmd;
                conn.Open();
                cmd = new SqlCommand("DELETE FROM Grup_bez WHERE kod_kv=" + "'" + Dannie.Id + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            if (Dannie.Ud == "3")
            {
                Form1 f1 = new Form1();
                SqlConnection conn = new SqlConnection(f1.connect);
                SqlCommand cmd;
                conn.Open();
                cmd = new SqlCommand("DELETE FROM Vidi_rabot WHERE kod_v=" + "'" + Dannie.Id + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            if (Dannie.Ud == "4")
            {
                Form1 f1 = new Form1();
                SqlConnection conn = new SqlConnection(f1.connect);
                SqlCommand cmd;
                conn.Open();
                cmd = new SqlCommand("DELETE FROM Rabotni WHERE kod_r=" + "'" + Dannie.KodR + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            this.Close();
        }

        private void ud_Activated(object sender, EventArgs e)
        {
            label1.Text = "Вы уверены, что хотите удалить запись?";
        }


    }
}
