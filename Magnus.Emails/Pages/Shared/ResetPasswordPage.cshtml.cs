using Magnus.Emails.Models;
using Magnus.Emails.Templates.SSO;
using Microsoft.AspNetCore.Mvc;

namespace Magnus.Emails.Pages
{
    [IgnoreAntiforgeryToken]
    public class ResetPasswordPageModel : BasePageModel
    {
        public ResetPasswordPageModel(ResetPasswordTemplate template, string contentId)
        {
            Template = template;
            ContentId = contentId;
        }

        public ResetPasswordTemplate Template { get; }
        public string ContentId { get; }
    }
}