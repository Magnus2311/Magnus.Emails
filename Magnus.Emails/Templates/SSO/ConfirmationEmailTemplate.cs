using Magnus.Emails.Models;

namespace Magnus.Emails.Templates.SSO
{
    public class ConfirmationEmailTemplate : BaseTemplate
    {
        public ConfirmationEmailTemplate(Credentials credentials) : base(credentials)
        {
        }
    }
}
