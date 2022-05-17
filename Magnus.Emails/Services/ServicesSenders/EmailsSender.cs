using Magnus.Emails.Helpers;
using Magnus.Emails.Models.DTOs;

namespace Magnus.Emails.Services.ServicesSenders
{
    public class EmailsSender
    {
        private readonly TemplateFactory _templateFactory;

        public EmailsSender(TemplateFactory templateFactory)
        {
            _templateFactory = templateFactory;
        }

        public async Task SendEmail(RegistrationEmailDTO registrationEmailDTO)
        {
            var template = _templateFactory.InitTemplate(registrationEmailDTO.TemplateType, registrationEmailDTO.SenderType);
            await new GmailSmtpEmailsService(template).SendEmail(registrationEmailDTO.Email!, registrationEmailDTO.Token!);
        }
    }
}
