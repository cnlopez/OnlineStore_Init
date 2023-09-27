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

        public static async Task SendErrorNotification(string errorMessage)
        {
            using var httpClient = new HttpClient();

            string apiUrl = "https://localhost:7268/email?errorMessage=" + errorMessage;

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Server response");
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"The request failed with status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error in requets HTTP: {e.Message}");
            }
        }
    }
}
