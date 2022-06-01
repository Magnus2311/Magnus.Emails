using Magnus.Emails.Models.DTOs;
using Magnus.Emails.Services.ServicesSenders;
using Magnus.Emails.Templates.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Magnus.Emails.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailsController : ControllerBase
    {
        private readonly EmailsSender _emailsSender;

        public EmailsController(EmailsSender emailsSender)
        {
            _emailsSender = emailsSender;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> SendRegistrationEmail(RegistrationEmailDTO registrationEmailDTO)
        {
            await _emailsSender.SendEmail(TemplateType.SsoRegistrationDefault, registrationEmailDTO);
            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> SendResetPasswordEmail(ResetPasswordEmailDTO resetPasswordEmailDTO)
        {
            await _emailsSender.SendEmail(TemplateType.ResetPasswordDefault, resetPasswordEmailDTO);
            return Ok();
        }
    }
}
