namespace Services.Interfaces
{
    public interface ISmtpService
    {
        void SendEmail(string mailTo, string subject, string body);
    }
}
