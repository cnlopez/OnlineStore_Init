using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Base;

namespace Tests
{
    public class GetUsersTest : UserUnitTest
    {
        [Test]
        public async Task GetUsers_ReturnSuccess()
        {
            UserRepositoryMock.Setup(x => x.GetUsersAsync()).ReturnsAsync(UserModel);
            var response = await UserService.GetUsers();
            Assert.IsNotNull(response);
        }
    }
}
