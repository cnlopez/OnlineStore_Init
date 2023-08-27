using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoryAsync();
        Task<Category> GetCategoryAsync(int categoryId);
        Task SaveCategoryAsync(Category category);
        Task UpdateCategory(int categoryId, Category category);
        Task DeleteCategory(int categoryId);
    }
}
