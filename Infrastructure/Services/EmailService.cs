using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IConfiguration config, ILogger<EmailService> logger)
    {
        _config = config;
        _logger = logger;
    }

    public async Task SendUserInvitationAsync(string email, string temporaryPassword)
    {
        try
        {
            //var emailSettings = _config.GetSection("EmailSettings");
            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress(emailSettings["SenderName"], emailSettings["SenderEmail"]));
            //message.To.Add(new MailboxAddress("", email));
            //message.Subject = "Welcome to VOC Portal";

            //var bodyBuilder = new BodyBuilder
            //{
            //    HtmlBody = $@"<p>Hello,</p>
            //                <p>You have been invited to join the VOC Portal.</p>
            //                <p>Your temporary password is: <strong>{temporaryPassword}</strong></p>
            //                <p>Please login at: <a href='{emailSettings["LoginUrl"]}'>VOC Portal</a></p>
            //                <p>Note: This password is valid for 24 hours.</p>"
            //};

            //message.Body = bodyBuilder.ToMessageBody();

            //using var client = new SmtpClient();
            //await client.ConnectAsync(emailSettings["SmtpServer"],
            //    int.Parse(emailSettings["SmtpPort"]),
            //    SecureSocketOptions.StartTls);

            //await client.AuthenticateAsync(emailSettings["SmtpUsername"],
            //    emailSettings["SmtpPassword"]);

            //await client.SendAsync(message);
            //await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending invitation email");
            throw;
        }
    }
}