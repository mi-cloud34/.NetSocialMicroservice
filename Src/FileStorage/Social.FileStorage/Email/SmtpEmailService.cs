using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Social.Shared.Email
{
    public class SmtpEmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("mymail", "hcom *** *** *** ***");
                client.Port = 587;
                client.EnableSsl = true;
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("mymail"),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email);
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
