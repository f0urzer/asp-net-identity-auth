using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiController]
    public class TestController(IEmailSender emailSender) : ControllerBase
    {
        [HttpGet("sendMail")]
        public async Task SendEmail(string mail, string subject, string message)
        {
            try
            {
                await emailSender.SendEmailAsync(mail, subject, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
