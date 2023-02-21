using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Отправка электронного письма 
        /// </summary>
        /// <param name="AddressFrom">Адрес отправителя</param>
        /// <param name="Name">Имя отправителя</param>
        /// <param name="Password">Пароль отправителя</param>
        /// <param name="AddressTo">Адрес получателя</param>
        /// <param name="Subject">Тема письма</param>
        /// <param name="Text">Содержание письма</param>
        void Sending(string AddressFrom, string Name, string Password, string AddressTo, string Subject, string Text)
        {
            MailAddress from = new MailAddress(AddressFrom, Name);
            MailAddress to = new MailAddress(AddressTo);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            m.Subject = Subject;
            m.Body = Text;
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(AddressFrom, Password);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                Sending(
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    textBox4.Text,
                    textBox5.Text,
                    textBox6.Text);
                MessageBox.Show("Отправлено");
            }
            catch
            {
                MessageBox.Show("Возникла ошибка!");
            }
        }

        private void Email_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
