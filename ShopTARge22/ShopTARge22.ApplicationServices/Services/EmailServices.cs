using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Nancy.ModelBinding;
using ShopTARge22.Core.Dto.EmailDtos;
using ShopTARge22.Core.ServiceInterface;
using Twilio.TwiML.Messaging;

namespace ShopTARge22.ApplicationServices.Services
{
    public class EmailServices : IEmailServices

    {
        private readonly IConfiguration _config;
       
        public EmailServices(IConfiguration config) 
        {
            _config = config;
        }
        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("EmailUserName"));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = dto.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, false);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
