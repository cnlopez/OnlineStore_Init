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
    public class GetCategoryTest : CategoryUnitTest
    {
        [Test]
        public async Task GetCategory_ReturnSuccess()
        {
            CategoryRepositoryMock.Setup(x => x.GetCategoryAsync()).ReturnsAsync(CategoryModel);
            var response = await CategoryService.GetCategory();
            Assert.IsNotNull(response);
        }
    }
}
