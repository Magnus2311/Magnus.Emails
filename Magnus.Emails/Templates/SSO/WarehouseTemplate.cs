using Magnus.Emails.Models;

namespace Magnus.Emails.Templates.SSO
{
    public class RegistrationDefaultTemplate : BaseTemplate
    {
        public RegistrationDefaultTemplate(Credentials credentials, EmailData emailData) : base(credentials)
        {
            Subject = emailData.Subject;
            SiteName = emailData.SiteName;
            LogoPath = emailData.LogoPath;
        }
    }
}
