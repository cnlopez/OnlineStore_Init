using AutoMapper;
using Business.Interfaces;
using Business.Mappers;
using Data.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Base
{
    public abstract partial class CategoryUnitTest
    {
        protected ICategoryService CategoryService { get; set; }
        protected Mock<ICategoryRepository> CategoryRepositoryMock { get; set; }
        protected IMapper Mapper { get; set; }

        protected CategoryUnitTest()
        {
            var profiles = new Profile[] { new CategoryProfile() };
            var mappingConfig = new MapperConfiguration(x => x.AddProfiles(profiles));
            Mapper = mappingConfig.CreateMapper();
        }
    }
}
