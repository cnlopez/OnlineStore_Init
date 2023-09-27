using Business.Interfaces;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using Business.Settings;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;
        private readonly string SmtpHost;
        private readonly int SmtpPort; // SMTP port usually is 587 o 25
        private readonly string SmtpUsername;
        private readonly string SmtpPassword;
        private readonly string SenderEmail;
        private readonly string RecipientEmail;

        public EmailService(IEmailRepository emailRepository, IMapper mapper, IOptionsSnapshot<AppSettings> optionsSnapshot)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
            SmtpPort = optionsSnapshot.Value.SmtpPort;
            SmtpUsername = optionsSnapshot.Value.SmtpUsername;
            SmtpPassword = optionsSnapshot.Value.SmtpPassword;
            SenderEmail = optionsSnapshot.Value.SenderEmail;
            RecipientEmail = optionsSnapshot.Value.RecipientEmail;
        }

        public async Task SendErrorNotification(string errorMessage)
        {
            try
            {
                using (var client = new SmtpClient(SmtpHost, SmtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);

                    var message = new MailMessage(SenderEmail, RecipientEmail)
                    {
                        Subject = "Error in the API",
                        Body = errorMessage,
                        IsBodyHtml = false
                    };

                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error by sending notification email: {ex.Message}");
            }
        }
    }
}
