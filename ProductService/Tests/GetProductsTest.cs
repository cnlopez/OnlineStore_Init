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
    public class GetProductsTest : ProductUnitTest
    {
        [Test]
        public async Task GetProducts_ReturnSuccess()
        {
            ProductRepositoryMock.Setup(x => x.GetProductsAsync()).ReturnsAsync(ProductsModel);
            var response = await ProductService.GetProducts();
            Assert.IsNotNull(response);
        }
    }
}
