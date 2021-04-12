using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Fiction.Infrastructure;
using Microsoft.Extensions.Options;

namespace Fiction.Services
{
    public class EmailMessageSender : IMessageSender
    {
        private readonly IConfiguration _configuration;
        private readonly FictionConfiguration _fictionConfiguration;

        public EmailMessageSender(IConfiguration configuration,
            IOptions<FictionConfiguration> options)
        {
            _configuration = configuration;
            _fictionConfiguration = options.Value;
        }

        public void SendMessage()
        {
            //Add email message
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Admin", _fictionConfiguration.SenderEmailAddress);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User", "Recipient@gmail.com");
            message.To.Add(to);

            message.Subject = "This is email subject";

            //Add email body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
            bodyBuilder.TextBody = "Hello World!";

            message.Body = bodyBuilder.ToMessageBody();

            //Send message
            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, certChainType, errors) => true;
                // smtp-mail.outlook.com   587   MailKit.Security.SecureSocketOptions.StartTls
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(_fictionConfiguration.SenderEmailAddress, _fictionConfiguration.SenderEmailPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
