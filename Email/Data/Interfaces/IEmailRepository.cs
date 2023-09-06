using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IEmailRepository
    {
        Task<IEnumerable<Email>> GetEmailAsync();
        Task<Email> GetEmailAsync(int emailId);
        Task SaveEmailAsync(Email email);
        Task UpdateEmail(int emailId, Email email);
        Task DeleteEmail(int emailId);
    }
}
