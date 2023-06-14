using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var getUsers = await _userRepository.GetUsersAsync();
            var usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(getUsers);
            return usersViewModel;
        }
    }
}
