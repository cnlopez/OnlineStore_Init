using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Data.Models;
using ViewModels.Email;

namespace Business.Mappers
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            DomainToViewModel();
        }

        public void DomainToViewModel()
        {
            CreateMap<Email, EmailViewModel>();
            CreateMap<EmailViewModel, Email>();
        }
    }
}
