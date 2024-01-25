namespace WebApplication1.Services
{
    public interface IEmailService
    {
        public void Send(string to, string subject,string Message);
    }
}
