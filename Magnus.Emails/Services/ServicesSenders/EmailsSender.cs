using Magnus.Emails.Helpers;
using Magnus.Emails.Interfaces;
using Magnus.Emails.Models.DTOs;
using Magnus.Emails.Templates.Helpers;
using Magnus.Emails.Models.Interfaces;

namespace Magnus.Emails.Services.ServicesSenders
{
    public class EmailsSender
    {
        private readonly TemplateFactory _templateFactory;
        private readonly IViewRenderService _viewRenderService;

        public EmailsSender(TemplateFactory templateFactory, IViewRenderService viewRenderService)
        {
            _templateFactory = templateFactory;
            _viewRenderService = viewRenderService;
        }

        public async Task SendEmail(TemplateType templateType, IRequestDTO requestDTO)
        {
            var template = _templateFactory.InitTemplate(templateType, requestDTO);
            if (template != null)
            {
                template.Receiver = requestDTO.Email;
                template.CallbackToken = requestDTO.Token;
                await new GmailSmtpEmailsService(template, _viewRenderService).SendEmail();
            }
        }
    }
}
