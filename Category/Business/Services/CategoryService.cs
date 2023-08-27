using Business.Interfaces;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ViewModels.Category;
using Data.Models;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategory()
        {
            var getCategory = await _categoryRepository.GetCategoryAsync();
            var categoryViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(getCategory);
            return categoryViewModel;
        }

        public async Task<CategoryViewModel> GetCategory(int categoryId)
        {
            var getCategory = await _categoryRepository.GetCategoryAsync(categoryId);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(getCategory);
            return categoryViewModel;
        }

        public async Task SaveCategory(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            await _categoryRepository.SaveCategoryAsync(category);
        }

        public async Task UpdateCategory(int categoryId, CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            await _categoryRepository.UpdateCategory(categoryId, category);
        }

        public async Task DeleteCategory(int categoryId)
        {
            await _categoryRepository.DeleteCategory(categoryId);
        }
    }
}
