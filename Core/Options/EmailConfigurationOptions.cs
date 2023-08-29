namespace Core.Options
{
    public class EmailConfigurationOptions
    {
        public const string EmailConfiguration = "EmailConfiguration";
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public string From { get; set; }
        public string UrlButon { get; set; }
        public bool Ssl { get; set; }
    }
}
