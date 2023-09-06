using Data.Interfaces;
using Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Data
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _configuration;

        public EmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Email>> GetEmailAsync()
        {
            var email = Enumerable.Empty<Email>();
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                email = await sqlConnection.QueryAsync<Email>("spGetEmails", commandType: CommandType.StoredProcedure);
            }
            return email;
        }

        public async Task<Email> GetEmailAsync(int emailId)
        {
            var email = new Email();
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                email = await sqlConnection.QueryFirstAsync<Email>("spGetEmailById", new { @EmailId = emailId }, commandType: CommandType.StoredProcedure);
            }
            return email;
        }

        public async Task SaveEmailAsync(Email email)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spSaveEmail", new { email.EmailName }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateEmail(int emailId, Email email)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spUpdateEmail", new { emailId, email.EmailName }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteEmail(int emailId)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spDeleteEmail", new { emailId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
