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
    public partial class InstrEk : Form
    {
        public InstrEk()
        {
            InitializeComponent();
        }

        private void InstrEk_Load(object sender, EventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);

            string sql =
               " SELECT kod_inst " +
                  " , instrukc " +
               " FROM Instrukcii i " +
               " JOIN  Vidi_rabot vr ON i.kod_v = vr.kod_v " +
               " Where  i.kod_v = " + Dannie.KodVid
            ;

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();
            comboBox1.DataSource = ds.Tables[0];

            comboBox1.DisplayMember = "instrukc";
            comboBox1.ValueMember = "kod_inst";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dannie.KodInst = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            
            Ekzamen ek = new Ekzamen();
            ek.Show();
            this.Close();
        }
    }
}
