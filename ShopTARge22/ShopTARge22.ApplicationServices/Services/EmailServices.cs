using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
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
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("tixy84@gmail.com"));
            email.To.Add(MailboxAddress.Parse("request.To"));
            email.Subject = "request.Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("tixy84@gmail.com", "Kevad231");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
