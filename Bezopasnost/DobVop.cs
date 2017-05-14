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
    public partial class DobVop : Form
    {
        public DobVop()
        {
            InitializeComponent();
        }

        private void DobVop_Load(object sender, EventArgs e)
        {
           

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Form1 formGlavn = new Form1();
            SqlConnection conn = new SqlConnection(formGlavn.connect);

            string sql =
                            " SELECT punkt " +
                               " , p.kod_p s1 " +
                        " FROM Punkti p" +
                        " WHERE punkt = '" + e.Node.Text + "'"
                        ;


            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dtTree = new DataTable();
            conn.Open();
            adapter.Fill(dtTree);
            conn.Close();
            foreach (DataRow dta in dtTree.Rows)
            {
                //textBox1.Text = dta["s1"].ToString();

                Dannie.KodP2 = Convert.ToInt32(dta["s1"].ToString());
                string sql2 =
                   " SELECT kod_vop," +
                      " vopros AS 'Вопросы' " +
                   " FROM Voprosi " +
                   " WHERE kod_p = " + dta["s1"]
                   ;
                ;
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                DataSet ds2 = new DataSet();
                conn.Open();
                adapter2.Fill(ds2);
                conn.Close();
                dataGridView1.DataSource = ds2.Tables[0];
                dataGridView1.RowHeadersVisible = false;
                //dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
           

                if (dataGridView1.Rows.Count == 0)
                {
                    string sql3 =
                          " SELECT kod_otv," +
                             " otvet AS 'Ответы' " +
                          " FROM Otveti " +
                          " WHERE kod_vop = " + 0
                          ;
                    ;
                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                    DataSet ds3 = new DataSet();
                    conn.Open();
                    adapter3.Fill(ds3);
                    conn.Close();
                    dataGridView2.DataSource = ds3.Tables[0];
                    dataGridView2.Columns[0].Visible = false;
                    dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {

                int nomStr = dataGridView1.CurrentCell.RowIndex;
                Dannie.KodV = Convert.ToInt32(dataGridView1.Rows[nomStr].Cells[0].Value.ToString());
                Dannie.VopP = dataGridView1.Rows[nomStr].Cells[1].Value.ToString();
                Form1 formGlavn = new Form1();
                SqlConnection conn = new SqlConnection(formGlavn.connect);

                string sql3 =
                      " SELECT kod_otv," +
                         " otvet AS 'Ответы' " +
                      " FROM Otveti " +
                      " WHERE kod_vop = " + Dannie.KodV
                      ;
                ;
                SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                DataSet ds3 = new DataSet();
                conn.Open();
                adapter3.Fill(ds3);
                conn.Close();
                dataGridView2.DataSource = ds3.Tables[0];
                dataGridView2.RowHeadersVisible = false;
                //dataGridView1.ColumnHeadersVisible = false;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void DobVop_Activated(object sender, EventArgs e)
        {
            //textBox1.ScrollBars = ScrollBars.Vertical;
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
            DataTable dtTree = new DataTable();
            conn.Open();
            adapter.Fill(dtTree);
            conn.Close();
            //label1.Text = " ";

            //label2.Text = " ";
            //lineShape1.Visible = false;

            foreach (DataRow dta in dtTree.Rows)
            {

                TreeNode childNode = new TreeNode(dta["instrukc"].ToString());
                treeView1.Nodes.Add(childNode);

                string sql2 =
                    " SELECT kod_tm " +
                       " , tema " +
                    " FROM Temi " +
                    " Where kod_inst = " + dta["kod_inst"]
                ;

                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                DataTable dtTree2 = new DataTable();
                conn.Open();
                adapter2.Fill(dtTree2);
                conn.Close();


                foreach (DataRow dta2 in dtTree2.Rows)
                {
                    TreeNode childNode2 = new TreeNode(dta2["tema"].ToString());
                    childNode.Nodes.Add(childNode2);

                    string sql3 =
                    " SELECT kod_ptm " +
                       " , podtema " +
                    " FROM Podtemi " +
                    " Where kod_tm = " + dta2["kod_tm"]
                    ;

                    SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, conn);
                    DataTable dtTree3 = new DataTable();
                    conn.Open();
                    adapter3.Fill(dtTree3);
                    conn.Close();


                    foreach (DataRow dta3 in dtTree3.Rows)
                    {
                        TreeNode childNode3 = new TreeNode(dta3["podtema"].ToString());
                        childNode2.Nodes.Add(childNode3);

                        string sql5 =
                            " SELECT kod_p " +
                               " , punkt " +
                        " FROM Punkti " +
                        " Where kod_ptm = " + dta3["kod_ptm"]
                        ;

                        SqlDataAdapter adapter5 = new SqlDataAdapter(sql5, conn);
                        DataTable dtTree5 = new DataTable();
                        conn.Open();
                        adapter5.Fill(dtTree5);
                        conn.Close();


                        foreach (DataRow dta5 in dtTree5.Rows)
                        {
                            TreeNode childNode5 = new TreeNode(dta5["punkt"].ToString());
                            childNode3.Nodes.Add(childNode5);

                        }
                    }

                    string sql4 =
                    " SELECT kod_p " +
                       " , punkt " +
                    " FROM Punkti " +
                    " Where kod_tm = " + dta2["kod_tm"]
                    ;

                    SqlDataAdapter adapter4 = new SqlDataAdapter(sql4, conn);
                    DataTable dtTree4 = new DataTable();
                    conn.Open();
                    adapter4.Fill(dtTree4);
                    conn.Close();


                    foreach (DataRow dta4 in dtTree4.Rows)
                    {
                        TreeNode childNode4 = new TreeNode(dta4["punkt"].ToString());
                        childNode2.Nodes.Add(childNode4);

                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dobVop2 dv2 = new dobVop2();
            dv2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            redVop2 rv2 = new redVop2();
            rv2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EkzamVoprosi ek2 = new EkzamVoprosi();
            //ek2.MdiParent = this;
            ek2.Show();
        }
    }
}
