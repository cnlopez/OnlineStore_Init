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
using Business.Settings;
using Microsoft.Extensions.Options;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly string SenderEmail;
        private readonly string RecipientMail;

        public ProductService(IProductRepository productRepository, IMapper mapper, IOptionsSnapshot<AppSettings> optionsSnapshot)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            SenderEmail = optionsSnapshot.Value.SenderEmail;
            RecipientMail = optionsSnapshot.Value.RecipientMail;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var getProducts = await _productRepository.GetProductsAsync();
            var productsViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(getProducts);
            return productsViewModel;
        }

        public async Task<ProductViewModel> GetProduct(int productId)
        {
            var getProduct = await _productRepository.GetProductAsync(productId);
            var productViewModel = _mapper.Map<ProductViewModel>(getProduct);
            return productViewModel;
        }

        public async Task SaveProduct(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Products>(productViewModel);
            await _productRepository.SaveProductAsync(product);
        }

        public async Task UpdateProduct(int productId, ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Products>(productViewModel);
            await _productRepository.UpdateProduct(productId, product);
        }

        public async Task DeleteProduct(int productId)
        {
            await _productRepository.DeleteProduct(productId);
        }
    }
}
