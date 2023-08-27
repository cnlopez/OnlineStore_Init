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
    public class GetProductTest : ProductUnitTest
    {
        [Test]
        public async Task GetProduct_ReturnSuccess()
        {
            ProductRepositoryMock.Setup(x => x.GetProductAsync()).ReturnsAsync(ProductModel);
            var response = await ProductService.GetProduct();
            Assert.IsNotNull(response);
        }
    }
}
