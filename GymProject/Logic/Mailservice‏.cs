
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GymProject.Logic
{
    public class MailService
    {
        public string fullName;
        public string email;
        public static void SendEmail(string toEmail, string subject, string messBody, string description)
        {
            try
            {
                MailMessage Mes = new MailMessage();
                Mes.To.Add(toEmail); // הודעה ל;
                Mes.From = new MailAddress("ActiveYourselfOffice@gmail.com", "ActiveYourSelf"); //הודעה מ
                Mes.Subject = subject;  //נושא
                Mes.Body = messBody; //תוכן
                Mes.IsBodyHtml = true;  //שליחה בצורת HTML
                var smtp = new SmtpClient("smtp.gmail.com",587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential("ActiveYourselfOffice@gmail.com", "QWaszx!2")
                };              
                    smtp.Send(Mes);
            }
            catch (Exception e)
            {
                var a = 78;
            }

        }
    }
}

