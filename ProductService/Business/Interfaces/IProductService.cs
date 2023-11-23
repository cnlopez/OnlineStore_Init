using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Product;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync();
        Task<ProductViewModel> GetProductAsync(int productId);
        Task SaveProductAsync(ProductViewModel productViewModel);
        Task UpdateProductAsync(int productId, ProductViewModel productViewModel);
        Task DeleteProductAsync(int productId);
    }
}
