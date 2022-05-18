using Magnus.Emails.Helpers;
using Magnus.Emails.Interfaces;
using Magnus.Emails.Models.DTOs;

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

        public async Task SendEmail(RegistrationEmailDTO registrationEmailDTO)
        {
            var template = _templateFactory.InitTemplate(registrationEmailDTO.TemplateType, registrationEmailDTO.SenderType);
            template.Receiver = registrationEmailDTO.Email;
            template.CallbackToken = registrationEmailDTO.Token;
            await new GmailSmtpEmailsService(template, _viewRenderService).SendEmail();
        }
    }
}
