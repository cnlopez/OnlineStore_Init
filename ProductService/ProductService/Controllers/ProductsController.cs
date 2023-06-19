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
    }
}
