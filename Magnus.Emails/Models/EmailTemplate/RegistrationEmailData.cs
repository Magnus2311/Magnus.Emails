using Magnus.Emails.Models.Interfaces;

namespace Magnus.Emails.Models.EmailTemplates
{
    public class RegistrationEmailData : IEmailData
    {
        public RegistrationEmailData(string subject, string siteName, string logoPath)
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