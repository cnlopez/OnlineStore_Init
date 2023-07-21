using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _productService.GetProducts());
        }

        /// <summary>
        /// Get Product
        /// </summary>
        /// <returns></returns>
        [Route("products/{productId:int}"), HttpGet]
        public async Task<ActionResult> GetProduct(int productId)
        {
            return Ok(await _productService.GetProduct(productId));
        }

        /// <summary>
        /// Save Product
        /// </summary>
        /// <returns></returns>
        [Route("products"), HttpPost]
        public async Task SaveProduct()
        {
            await _productService.SaveProduct();
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <returns></returns>
        [Route("products"), HttpPut]
        public async Task<ActionResult> UpdateProduct()
        {
            return Ok(await _productService.GetProducts());
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <returns></returns>
        [Route("products"), HttpDelete]
        public async Task<ActionResult> DeleteProduct()
        {
            return Ok(await _productService.GetProducts());
        }
    }
}
