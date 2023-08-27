using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Category;

namespace Business.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetCategory();
        Task<CategoryViewModel> GetCategory(int categoryId);
        Task SaveCategory(CategoryViewModel categoryViewModel);
        Task UpdateCategory(int categoryId, CategoryViewModel categoryViewModel);
        Task DeleteCategory(int categoryId);
    }
}
