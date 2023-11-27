using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public async Task SendErrorNotification(string errorMessage)
        {
            using var httpClient = new HttpClient();

            string apiUrl = _configuration["ServicesEndPoint:EmailService"]?.ToString() + errorMessage;

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
