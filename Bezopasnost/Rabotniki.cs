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
    public partial class Rabotniki : Form
    {
        public Rabotniki()
        {
            InitializeComponent();
        }

        public void Rabot() {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);
            string q =
               "SELECT r.kod_r, " +
                  " fio AS 'ФИО' " +
                  ", nom_ud AS 'Номер удостоверения' " +
                  ", otm_o_sdch AS 'Отметка о сдачи' " +
                  ", data_psl_ek AS 'Дата последнего экзамена' " +
                  ", dolzhn AS 'Должность' " +
                  ", kvalif AS 'Квалификация' " +
                  ", vid_rabot AS 'Вид работы' " +
                  ", email AS 'E-mail' " +
                  ", Password1 AS 'Пароль' " +
               "FROM Rabotni r" +
                  " LEFT JOIN Dolzhnost d ON r.kod_dolzh = d.kod_d " +
                  " LEFT JOIN Grup_bez g ON r.kod_kv = g.kod_kv " +
                  " LEFT JOIN Raspredelenie rasp ON r.kod_r = rasp.kod_r " +
                  " LEFT JOIN Vidi_rabot vr ON rasp.kod_v = vr.kod_v "
            ;
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            conn.Open();
            adapter.Fill(ds);
            conn.Close();

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i <= dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Height = 35;
            }
            
        }

        private void Rabotniki_Activated(object sender, EventArgs e)
        {

            Rabot();
           
        }

        private void Rabotniki_Load(object sender, EventArgs e)
        {
            Rabot();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dobRabotn formDobRabotn = new dobRabotn();
            formDobRabotn.MdiParent = this.MdiParent;
            formDobRabotn.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            redRabotn formDobRabotn = new redRabotn();
            formDobRabotn.MdiParent = this.MdiParent;
            formDobRabotn.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ud u = new ud();
            u.MdiParent = this.MdiParent;
            Dannie.Ud = "4";
            u.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int nomStr = dataGridView1.CurrentCell.RowIndex;
            Dannie.KodR = Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString());
        }
    }
}
