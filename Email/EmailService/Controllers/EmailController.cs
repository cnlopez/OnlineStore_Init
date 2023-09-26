using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmailService.Controllers
{
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        /// Get Email
        /// </summary>
        /// <returns></returns>
        [Route("email"), HttpPost]
        public async Task SendErrorNotification(string errorMessage)
        {
            await _emailService.SendErrorNotification(errorMessage);
        }

    }
}
