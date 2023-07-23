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
        Task<IEnumerable<Products>> GetProductsAsync();
        Task<Products> GetProductAsync(int productId);
        Task SaveProductAsync(Products product);
        Task UpdateProduct(int productId, Products product);
        Task DeleteProduct(int productId);
    }
}
