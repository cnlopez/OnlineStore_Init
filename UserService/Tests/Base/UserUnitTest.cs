using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.Mappers;
using Data.Interfaces;
using Moq;

namespace Tests.Base
{
    public abstract partial class UserUnitTest
    {
        protected IUserService UserService { get; set; }
        protected Mock<IUserRepository> UserRepositoryMock { get; set; }
        protected IMapper Mapper { get; set; }

        protected UserUnitTest()
        {
            var profiles = new Profile[] { new UserProfile() };
            var mappingConfig = new MapperConfiguration(x => x.AddProfiles(profiles));
            Mapper = mappingConfig.CreateMapper();
        }
    }
}
