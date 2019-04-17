using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace firstwebapp.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SENDGRID_APIKEY, subject, message, email);
        }
        public Task Execute(string apiKey, string subject, string message, string email)
        {
            SendGridClient client = new SendGridClient(apiKey);
            SendGridMessage msg = new SendGridMessage()
            {
                From = new EmailAddress("system@emailservice.org", "System Email Service"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}