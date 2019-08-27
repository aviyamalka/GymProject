
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
        public static void SendEmail(string toEmail, string subjecta, string bodya, string description)
        {
            try
            {
                var fromAddress = new MailAddress("ActiveYourselfOffice@gmail.com", "efartttt");
                var toAddress = new MailAddress("efratgr10@gmail.com", "user");
                const string fromPassword = "Asdfg!234";
                const string subject = "sdssss";
                const string body = "bbbbbbbbbbb";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception e)
            {
                var a = 78;
            }

        }
    }
}

