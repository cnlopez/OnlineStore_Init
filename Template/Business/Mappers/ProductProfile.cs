using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Data.Models;
using ViewModels.Product;

namespace Business.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            DomainToViewModel();
        }

        public void DomainToViewModel()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
