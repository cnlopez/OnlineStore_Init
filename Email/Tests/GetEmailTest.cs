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
    public class GetEmailTest : EmailUnitTest
    {
        [Test]
        public async Task GetEmail_ReturnSuccess()
        {
            EmailRepositoryMock.Setup(x => x.GetEmailAsync()).ReturnsAsync(EmailModel);
            var response = await EmailService.GetEmail();
            Assert.IsNotNull(response);
        }
    }
}
