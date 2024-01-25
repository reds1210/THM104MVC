using System.Net.Mail;
using System.Net;
using System.Text;

namespace WebApplication1.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _password;
        private readonly string _googleID;
        private readonly SmtpClient _smtpClient;

        public EmailService()
        {
            _password = "jfdd asyf gpoh kchg";
            _googleID = "sbc39378@gmail.com"; 
            _smtpClient = new SmtpClient("smtp.gmail.com", 587);
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new NetworkCredential(_googleID, _password);
        }

        public void Send(string to, string subject, string Message)
        {
            MailMessage mms = new MailMessage();
            mms.From = new MailAddress(_googleID);
            mms.Subject = subject;
            mms.Body = Message;
            mms.IsBodyHtml = true;
            mms.SubjectEncoding = Encoding.UTF8;
            mms.To.Add(new MailAddress(to));

            _smtpClient.Send(mms);
        }
    }
}
