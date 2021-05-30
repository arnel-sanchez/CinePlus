using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace CinePlus.Services
{
    public class EmailMessage
    {
        public MailboxAddress Sender { get; set; }
        public MailboxAddress Reciever { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }

    public class EmailSender : IEmailSender
    {
        private MimeMessage CreateMimeMessageFromEmailMessage(EmailMessage message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(message.Sender);
            mimeMessage.To.Add(message.Reciever);
            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            { Text = message.Content };
            return mimeMessage;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            EmailMessage message = new EmailMessage();
            message.Sender = new MailboxAddress("CinePlus", "arnelsanchezrodriguez@gmail.com");
            message.Reciever = new MailboxAddress("CinePlus", email);
            message.Subject = subject;
            message.Content = htmlMessage;
            var mimeMessage = CreateMimeMessageFromEmailMessage(message);
            using (SmtpClient smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync("smtp.gmail.com", 465, true);
                await smtpClient.AuthenticateAsync("c1n3plus.project@gmail.com", "SdB@5eDdatosII");
                await smtpClient.SendAsync(mimeMessage);
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
