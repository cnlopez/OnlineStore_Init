using Business.Interfaces;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViewModels.Product;
using Data.Models;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProduct()
        {
            var getProduct = await _productRepository.GetProductAsync();
            var productViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(getProduct);
            return productViewModel;
        }

        public async Task<ProductViewModel> GetProduct(int productId)
        {
            var getProduct = await _productRepository.GetProductAsync(productId);
            var productViewModel = _mapper.Map<ProductViewModel>(getProduct);
            return productViewModel;
        }

        public async Task SaveProduct(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            await _productRepository.SaveProductAsync(product);
        }

        public async Task UpdateProduct(int productId, ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            await _productRepository.UpdateProduct(productId, product);
        }

        public async Task DeleteProduct(int productId)
        {
            await _productRepository.DeleteProduct(productId);
        }
    }
}
