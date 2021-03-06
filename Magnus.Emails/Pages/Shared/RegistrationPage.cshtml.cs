using Magnus.Emails.Models;
using Magnus.Emails.Templates.SSO;
using Microsoft.AspNetCore.Mvc;

namespace Magnus.Emails.Pages
{
    [IgnoreAntiforgeryToken]
    public class RegistrationPageModel : BasePageModel
    {
        public RegistrationPageModel(RegistrationDefaultTemplate template, string contentId)
        {
            Template = template;
            ContentId = contentId;
        }

        public RegistrationDefaultTemplate Template { get; }
        public string ContentId { get; }
    }
}