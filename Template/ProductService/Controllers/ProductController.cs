using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <returns></returns>
        [Route("product"), HttpGet]
        public async Task<ActionResult> GetProduct()
        {
            return Ok(await _productService.GetProduct());
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <returns></returns>
        [Route("product/{productId:int}"), HttpGet]
        public async Task<ActionResult> GetProduct(int productId)
        {
            return Ok(await _productService.GetProduct(productId));
        }

        /// <summary>
        /// Save Product
        /// </summary>
        /// <returns></returns>
        [Route("product"), HttpPost]
        public async Task SaveProduct(ProductViewModel productViewModel)
        {
            await _productService.SaveProduct(productViewModel);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <returns></returns>
        [Route("product/{productId:int}"), HttpPut]
        public async Task UpdateProduct(int productId, ProductViewModel productViewModel)
        {
            await _productService.UpdateProduct(productId, productViewModel);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <returns></returns>
        [Route("product/{productId:int}"), HttpDelete]
        public async Task DeleteProduct(int productId)
        {
            await _productService.DeleteProduct(productId);
        }
    }
}
