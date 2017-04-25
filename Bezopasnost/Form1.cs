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
            //справочникиToolStripMenuItem.Visible = false;
            //экзаменToolStripMenuItem.Visible = false;
           // обучениеToolStripMenuItem.Visible = false;
           // тестированиеToolStripMenuItem.Visible = false;
            //комиссияToolStripMenuItem.Visible = false;
            //загрузкаToolStripMenuItem.Visible = false;
            //журналСтатистикиToolStripMenuItem.Visible = false;
           // режимыToolStripMenuItem.Visible = false;
            
            this.IsMdiContainer = true; 
            Vhod vh = new Vhod();
            vh.ShowDialog();

            if (Dannie.Polzovatel == 0) {

                обучениеToolStripMenuItem.Visible = true;
                тестированиеToolStripMenuItem.Visible = true;
                справкаToolStripMenuItem.Visible = true;
            }

            if (Dannie.Polzovatel == 1) {
                справочникиToolStripMenuItem.Visible = true;
                загрузкаToolStripMenuItem.Visible = true;
                журналСтатистикиToolStripMenuItem.Visible = true;
            }

         

            Vid_r vdr = new Vid_r();
            vdr.MdiParent = this;
            vdr.Show();

            label1.Text = "Вы вошли как " + Dannie.login;
            
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
            Ekzam formEkzam = new Ekzam();
            formEkzam.MdiParent = this;
            formEkzam.Show();

            //InstrEk ek = new InstrEk();
            //ek.MdiParent = this;
            //ek.Show();
        }

        private void комиссияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dannie.Komiss = 1;
            Ekzam formEkzam = new Ekzam();
            formEkzam.MdiParent = this;
            formEkzam.Show();
            //Komissiya ko = new Komissiya();
            //ko.MdiParent = this;
            //ko.Show();
        }

        private void экзаменToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dannie.Komiss = 0;
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

    }
}
