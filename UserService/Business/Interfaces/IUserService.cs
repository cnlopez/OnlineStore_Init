using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.User;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsers();
    }
}
