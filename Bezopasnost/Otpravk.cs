using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Bezopasnost
{
    public partial class Otpravk : Form
    {
        public Otpravk()
        {
            InitializeComponent();
        }
        public string email, pass;
        public string em;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // Uvedomleniya v = new Uvedomleniya();
            string vl;
            if (label1.Text != null) vl = label1.Text; else vl = null;
      //      for (int i = 1; i < comboBox1.Items.Count; i++) //comboBox1.Items.Count
     //       {
      //          if (comboBox1.Items[i].ToString() != "")
     //           {
            SendMail("smtp.gmail.com", "faceta17@gmail.com", "1993kzkz1k9z9k3z", "faceta2009@mail.ru", textBox1.Text, textBox2.Text, vl);
                    
         //       }
       //     }

            MessageBox.Show("Сообщения успешно отправлены");
            //MessageBox.Show(email);
        }

        /// <summary>
        /// Отправка письма на почтовый ящик C# mail send
        /// </summary>
        /// <param name="smtpServer">Имя SMTP-сервера</param>
        /// <param name="from">Адрес отправителя</param>
        /// <param name="password">пароль к почтовому ящику отправителя</param>
        /// <param name="mailto">Адрес получателя</param>
        /// <param name="caption">Тема письма</param>
        /// <param name="message">Сообщение</param>
        /// <param name="attachFile">Присоединенный файл</param>
        /// 

        public static void SendMail(string smtpServer, string from, string password, string mailto, string caption, string message, string attachFile)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = true;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                label1.Text = ofd.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



    }
}
