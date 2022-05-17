using Magnus.Emails.Models.DTOs;
using Magnus.Emails.Services.ServicesSenders;
using Microsoft.AspNetCore.Mvc;

namespace Magnus.Emails.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailsController
    {
        private readonly EmailsSender _emailsSender;

        public EmailsController(EmailsSender emailsSender)
        {
            _emailsSender = emailsSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendRegistrationEmail(RegistrationEmailDTO registrationEmailDTO)
        {
            await _emailsSender.SendEmail(registrationEmailDTO);
        }
    }
}
