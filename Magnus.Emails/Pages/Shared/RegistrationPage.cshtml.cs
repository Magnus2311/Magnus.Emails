using Magnus.Emails.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Magnus.Emails.Pages
{
    [IgnoreAntiforgeryToken]
    public class RegistrationPageModel : PageModel
    {
        public RegistrationPageModel(ITemplate template, string contentId)
        {
            Template = template;
            ContentId = contentId;
        }

        public ITemplate Template { get; }
        public string ContentId { get; }
    }
}