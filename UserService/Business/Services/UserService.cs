using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.User;

namespace Business.Services
{
    public class UserService : IUserService
    {
        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            List<UserViewModel> lst = new List<UserViewModel>();
            return lst;
        }
    }
}
