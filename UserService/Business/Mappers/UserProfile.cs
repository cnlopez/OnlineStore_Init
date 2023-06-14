using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using ViewModels.User;


namespace Business.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            DomainToViewModel();
        }

        public void DomainToViewModel()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
