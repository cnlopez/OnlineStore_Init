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
    public abstract partial class EmailUnitTest
    {
        protected IEmailService EmailService { get; set; }
        protected Mock<IEmailRepository> EmailRepositoryMock { get; set; }
        protected IMapper Mapper { get; set; }

        protected EmailUnitTest()
        {
            var profiles = new Profile[] { new EmailProfile() };
            var mappingConfig = new MapperConfiguration(x => x.AddProfiles(profiles));
            Mapper = mappingConfig.CreateMapper();
        }
    }
}
