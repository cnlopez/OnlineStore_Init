using AutoMapper;
using Business.Interfaces;
using Business.Mappers;
using Business.Settings;
using Data.Interfaces;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Base
{
    public abstract partial class ProductUnitTest
    {
        protected IProductService ProductService { get; set; }
        protected Mock<IProductRepository> ProductRepositoryMock { get; set; }
        protected IMapper Mapper { get; set; }
        protected IOptionsSnapshot<AppSettings> OptionsSnapshot { get; set; }

        protected ProductUnitTest()
        {
            var profiles = new Profile[] { new ProductProfile() };
            var mappingConfig = new MapperConfiguration(x => x.AddProfiles(profiles));
            Mapper = mappingConfig.CreateMapper();
        }
    }
}
