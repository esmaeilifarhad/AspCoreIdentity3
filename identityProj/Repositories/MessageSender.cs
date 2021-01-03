using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace identityProj.Repositories
{
    public class MessageSender : IMessageSender
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                //نام فرستنده
                mail.From = new MailAddress("farhadsender1367@gmail.com");
                //آدرس گیرنده یا گیرندگان
                mail.To.Add(toEmail);
                //عنوان ایمیل
                mail.Subject =subject;
                //بدنه ایمیل
                mail.Body = message;
                //مشخص کرن پورت 
                SmtpServer.Port = 587;
                //username : به جای این کلمه نام کاربری ایمیل خود را قرار دهید
                //password : به جای این کلمه رمز عبور ایمیل خود را قرار دهید
                SmtpServer.Credentials = new System.Net.NetworkCredential("farhadsender1367", "861130928");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
               ex.ToString();
            }

            /*
            using (var client = new SmtpClient())
            {
 
                var credentials = new NetworkCredential()
                {
                    UserName = "farhadsender1367", // without @gmail.com
                    Password = "861130928"
                };
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;

                using var emailMessage = new MailMessage()
                {
                    To = { new MailAddress(toEmail) },
                    From = new MailAddress("farhadsender1367@gmail.com"), // with @gmail.com
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = isMessageHtml
                };

                client.Send(emailMessage);
            }
            */
            return Task.CompletedTask;
        }
    }
}
