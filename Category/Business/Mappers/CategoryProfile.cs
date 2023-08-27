using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Data.Models;
using ViewModels.Category;

namespace Business.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            DomainToViewModel();
        }

        public void DomainToViewModel()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
        }
    }
}
