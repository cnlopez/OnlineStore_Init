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
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetProduct(int productId);
        Task SaveProduct(ProductViewModel productViewModel);
        Task UpdateProduct(int productId, ProductViewModel productViewModel);
        Task DeleteProduct(int productId);
    }
}
