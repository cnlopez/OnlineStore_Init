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
using Utilities;
using Services2.Interfaces;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly string SmtpHost;
        private readonly int SmtpPort; // SMTP port usually is 587 o 25
        private readonly string SmtpUsername;
        private readonly string SmtpPassword;
        private readonly string SenderEmail;
        private readonly string RecipientEmail;
        private readonly IEmailService _emailService;

        public ProductService(IProductRepository productRepository, IMapper mapper, IOptionsSnapshot<AppSettings> optionsSnapshot, IEmailService emailService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            SenderEmail = optionsSnapshot.Value.SenderEmail;
            RecipientEmail = optionsSnapshot.Value.RecipientEmail;
            SmtpHost = optionsSnapshot.Value.SmtpHost;
            SmtpPort = optionsSnapshot.Value.SmtpPort;
            SmtpUsername = optionsSnapshot.Value.SmtpUsername;
            SmtpPassword = optionsSnapshot.Value.SmtpPassword;
            _emailService = emailService;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            try
            {
                var getProducts = await _productRepository.GetProductsAsync();
                var productsViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(getProducts);
                return productsViewModel;
            }
            catch (Exception ex)
            {
                EmailNotification.SendErrorNotification(SmtpHost, SmtpPort, SmtpUsername, SmtpPassword, SenderEmail, RecipientEmail, ex.Message.ToString());
                throw;
            }
        }

        public async Task<ProductViewModel> GetProduct(int productId)
        {
            try
            {
                var getProduct = await _productRepository.GetProductAsync(productId);
                var productViewModel = _mapper.Map<ProductViewModel>(getProduct);
                return productViewModel;
            }
            catch (Exception ex)
            {
                await _emailService.SendErrorNotification(ex.Message.ToString());
                throw;
            }
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
