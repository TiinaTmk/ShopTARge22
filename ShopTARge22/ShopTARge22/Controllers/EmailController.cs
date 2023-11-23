using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using ShopTARge22.Core.ServiceInterface;

namespace ShopTARge22.Controllers
{ 
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;
        
        public EmailController(IEmailServices emailServices)
        {
        _emailServices = emailServices;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailServices.SendEmail(request);
            return Ok();
        }
    }
}

