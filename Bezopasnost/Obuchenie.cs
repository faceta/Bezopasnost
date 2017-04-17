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
    public partial class Obuchenie : Form
    {
        public Obuchenie()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public string tema = " ";

        private void Obuchenie_Activated(object sender, EventArgs e)
        {
            
         
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Obuchenie_Load(object sender, EventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Vertical;
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
            label1.Text = " ";
            
            //label2.Text = " ";
            lineShape1.Visible = false;

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //label1.Text = treeView1.Nodes.ToString();
            string punkti = " ";
                label1.Text = e.Node.Text;
                lineShape1.Visible = true;
                textBox1.Text = " ";
                //label2.MaximumSize = new Size(lineShape1.X2, lineShape1.X1);
                 
                Form1 formGlavn = new Form1();
                SqlConnection conn = new SqlConnection(formGlavn.connect);

                string sql =
                                " SELECT punkt " +
                                   " , p.soderzh s1 " +            
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
                    textBox1.Text = dta["s1"].ToString();
                    
                    string sql2 =
                                " SELECT podpunkti" +
                                    "  ,pp.soderzh s2 " +
                                " FROM Punkti p" +
                                " LEFT JOIN  PodPunkti pp ON p.kod_p = pp.kod_p " +
                                " WHERE punkt = '" + e.Node.Text + "'"
                                ;
                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                    DataTable dtTree2 = new DataTable();
                    conn.Open();
                    adapter2.Fill(dtTree2);
                    conn.Close();

                    foreach(DataRow dta2 in dtTree2.Rows){
                        punkti = " ";
                        punkti = "   " + dta2["podpunkti"].ToString() + " " + dta2["s2"].ToString();
                        textBox1.Text = textBox1.Text + "\r\n\r\n" + punkti;
                    }

                }
                textBox1.Text = textBox1.Text + "\r\n";
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

    

        private void tabPage3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flashRolic fl = new flashRolic();
            fl.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
