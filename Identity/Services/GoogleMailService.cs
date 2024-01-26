using Humanizer;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Identity.Services
{
    public class GoogleMailService : IEmailSender
    {
        private readonly string _password;
        private readonly string _googleID;
        private readonly SmtpClient _smtpClient;

        public GoogleMailService()
        {
            _password = "jfdd asyf gpoh kchg";
            _googleID = "sbc39378@gmail.com";
            _smtpClient = new SmtpClient("smtp.gmail.com", 587);
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new NetworkCredential(_googleID, _password);
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailMessage mms = new MailMessage();
            mms.From = new MailAddress(_googleID);
            mms.Subject = subject;
            mms.Body = htmlMessage;
            mms.IsBodyHtml = true;
            mms.SubjectEncoding = Encoding.UTF8;
            mms.To.Add(new MailAddress(email));

            _smtpClient.SendAsync(mms,"mail1");
        }
    }
}
