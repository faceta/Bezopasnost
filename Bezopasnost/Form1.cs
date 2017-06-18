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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string connect = "Data Source=localhost;Initial Catalog=bezopasn;Integrated Security=True";
        private void Form1_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            Vhod vh = new Vhod();
            vh.ShowDialog();
            Vid_r vdr = new Vid_r();
            vdr.MdiParent = this;
            vdr.Show();

        }

        private void работникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rabotniki formRabot = new Rabotniki();
            formRabot.MdiParent = this;
            formRabot.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dolzhn formRabot = new Dolzhn();
            formRabot.MdiParent = this;
            formRabot.Show();
        }

        private void членыКомиссииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void группыБезопасностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grupBez formRabot = new grupBez();
            formRabot.MdiParent = this;
            formRabot.Show();
        }

        private void видыРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VidRabot formRabot = new VidRabot();
            formRabot.MdiParent = this;
            formRabot.Show();
        }

        private void членыКомиссииToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChleniKomis formRabot = new ChleniKomis();
            formRabot.MdiParent = this;
            formRabot.Show();
        }

        private void инструкцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void журналСтатистикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZhurnalStatist formZhurnalStatist = new ZhurnalStatist();
            formZhurnalStatist.MdiParent = this;
            formZhurnalStatist.Show();
        }

        private void обучениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Obuchenie formObuchenie = new Obuchenie();
            formObuchenie.MdiParent = this;
            formObuchenie.Show();
        }

        private void тестированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RezhimTest formRezhimTest = new RezhimTest();
            formRezhimTest.MdiParent = this;
            formRezhimTest.Show();
        }

        private void уведомленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uvedomleniya uv = new Uvedomleniya();
            uv.MdiParent = this;
            uv.Show();
        }

        private void экзаменToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dannie.Komiss = 1;
            Ekzam formEkzam = new Ekzam();
            formEkzam.MdiParent = this;
            formEkzam.Show();

            //InstrEk ek = new InstrEk();
            //ek.MdiParent = this;
            //ek.Show();
        }

        private void комиссияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dannie.Komiss = 0;
            Ekzam formEkzam = new Ekzam();
            formEkzam.MdiParent = this;
            formEkzam.Show();
            //Komissiya ko = new Komissiya();
            //ko.MdiParent = this;
            //ko.Show();
        }

        private void экзаменToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dannie.Komiss = 2;
            Ekzam formEkzam = new Ekzam();
            formEkzam.MdiParent = this;
            formEkzam.Show();
            
        }

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nastrojki nast = new Nastrojki();
            nast.MdiParent = this;
            nast.Show();
        }

        private void вопросыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DobVop dVop = new DobVop();
            //dVop.MdiParent = this;
            dVop.Show();
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void режимыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vhod vhod = new Vhod();
            vhod.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            справочникиToolStripMenuItem.Visible = false;
            режимыToolStripMenuItem.Visible = false;
            журналСтатистикиToolStripMenuItem.Visible = false;
            комиссияToolStripMenuItem.Visible = false;
            уведомленияToolStripMenuItem.Visible = false;
            загрузкаToolStripMenuItem.Visible = false;
            справкаToolStripMenuItem.Visible = false;
            настройкаToolStripMenuItem.Visible = false;
            экзаменToolStripMenuItem.Visible = false;


            

            if (Dannie.Polzovatel == 0)
            {
                справочникиToolStripMenuItem.Visible = false;
                обучениеToolStripMenuItem.Visible = true;
                тестированиеToolStripMenuItem.Visible = true;
                справкаToolStripMenuItem.Visible = true;
                режимыToolStripMenuItem.Visible = true;
                журналСтатистикиToolStripMenuItem.Visible = false;
                комиссияToolStripMenuItem.Visible = false;
                уведомленияToolStripMenuItem.Visible = false;
                загрузкаToolStripMenuItem.Visible = false;
                настройкаToolStripMenuItem.Visible = false;
                экзаменToolStripMenuItem.Visible = false;

            }

            if (Dannie.Polzovatel == 1)
            {
                справочникиToolStripMenuItem.Visible = true;
                загрузкаToolStripMenuItem.Visible = true;
                журналСтатистикиToolStripMenuItem.Visible = true;
                уведомленияToolStripMenuItem.Visible = true;
                настройкаToolStripMenuItem.Visible = true;
                справкаToolStripMenuItem.Visible = true;
                режимыToolStripMenuItem.Visible = false;
                комиссияToolStripMenuItem.Visible = false;
            }
            if (Dannie.Polzovatel == 2)
            {
                настройкаToolStripMenuItem.Visible = false;
                справочникиToolStripMenuItem.Visible = false;
                режимыToolStripMenuItem.Visible = true;
                обучениеToolStripMenuItem.Visible = true;
                тестированиеToolStripMenuItem.Visible = true;
                экзаменToolStripMenuItem.Visible = true;
                справкаToolStripMenuItem.Visible = true;
                комиссияToolStripMenuItem.Visible = false;
                уведомленияToolStripMenuItem.Visible = false;
            }
            if (Dannie.Polzovatel == 3)
            {
                настройкаToolStripMenuItem.Visible = false;
                комиссияToolStripMenuItem.Visible = true;
                справкаToolStripMenuItem.Visible = true;
                режимыToolStripMenuItem.Visible = false;
                уведомленияToolStripMenuItem.Visible = false;
                справочникиToolStripMenuItem.Visible = false;
            }

           
            label1.Text = "Вы вошли как " + Dannie.login;
            //textBox1.Text = Dannie.login;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
