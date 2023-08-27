using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetProductAsync(int productId);
        Task SaveProductAsync(Product product);
        Task UpdateProduct(int productId, Product product);
        Task DeleteProduct(int productId);
    }
}
