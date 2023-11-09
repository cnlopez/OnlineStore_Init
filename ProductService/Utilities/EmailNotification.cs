using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class EmailNotification
    {
        public static void SendErrorNotification(string SmtpHost, int SmtpPort, string SmtpUsername, string SmtpPassword, string SenderEmail, string RecipientEmail, string errorMessage)
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
