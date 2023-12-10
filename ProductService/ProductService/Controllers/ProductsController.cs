using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>
        [Route("products"), HttpGet]
        [Authorize]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _productService.GetProductsAsync());
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <returns></returns>
        [Route("products/{productId:int}"), HttpGet]
        public async Task<ActionResult> GetProduct(int productId)
        {
            return Ok(await _productService.GetProductAsync(productId));
        }

        /// <summary>
        /// Save Product
        /// </summary>
        /// <returns></returns>
        [Route("products"), HttpPost]
        public async Task SaveProduct(ProductViewModel productViewModel)
        {
            await _productService.SaveProductAsync(productViewModel);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <returns></returns>
        [Route("products/{productId:int}"), HttpPut]
        public async Task UpdateProduct(int productId, ProductViewModel productViewModel)
        {
            await _productService.UpdateProductAsync(productId, productViewModel);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <returns></returns>
        [Route("products/{productId:int}"), HttpDelete]
        public async Task DeleteProduct(int productId)
        {
            await _productService.DeleteProductAsync(productId);
        }
    }
}
