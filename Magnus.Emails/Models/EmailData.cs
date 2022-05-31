namespace Magnus.Emails.Models
{
    public class EmailData
    {
        public EmailData(string subject, string siteName, string logoPath)
        {
            Subject = subject;
            SiteName = siteName;
            LogoPath = logoPath;
        }

        public string Subject { get; }
        public string SiteName { get; }
        public string LogoPath { get; }
    }
}