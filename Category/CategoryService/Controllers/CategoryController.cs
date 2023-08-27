using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Category;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CategoryService.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Get Category
        /// </summary>
        /// <returns></returns>
        [Route("category"), HttpGet]
        public async Task<ActionResult> GetCategory()
        {
            return Ok(await _categoryService.GetCategory());
        }

        /// <summary>
        /// Get Category
        /// </summary>
        /// <returns></returns>
        [Route("category/{categoryId:int}"), HttpGet]
        public async Task<ActionResult> GetCategory(int categoryId)
        {
            return Ok(await _categoryService.GetCategory(categoryId));
        }

        /// <summary>
        /// Save Category
        /// </summary>
        /// <returns></returns>
        [Route("category"), HttpPost]
        public async Task SaveCategory(CategoryViewModel categoryViewModel)
        {
            await _categoryService.SaveCategory(categoryViewModel);
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <returns></returns>
        [Route("category/{categoryId:int}"), HttpPut]
        public async Task UpdateCategory(int categoryId, CategoryViewModel categoryViewModel)
        {
            await _categoryService.UpdateCategory(categoryId, categoryViewModel);
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <returns></returns>
        [Route("category/{categoryId:int}"), HttpDelete]
        public async Task DeleteCategory(int categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
        }
    }
}
