using Business.Interfaces;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Product;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var getProducts = _productRepository.GetProductsAsync();
            var productsViewModel = new List<ProductViewModel>();
            foreach (var item in await getProducts)
            {
                productsViewModel.Add(new ProductViewModel
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName
                });
            }
            return productsViewModel;
        }

    }
}
