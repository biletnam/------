using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace kursach
{
    class OtpravkaEmail
    {
        public void otpravka(string email, string chto, int kolichestvo,string login,string pas)
        {
            Nastroiki n = new Nastroiki();
            SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 25);
            Smtp.Credentials = new NetworkCredential(login, pas);
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress(login );//от кого
            Message.To.Add(new MailAddress(email));//кому
            Message.Subject = "Заказ медикамента под названием " + chto;
            Message.Body = "Заказ от стоматологической клиники \nТовар " + chto + "\nКоличество " + kolichestvo.ToString() + " штук";
            Smtp.Send(Message);

        }
    }
}
