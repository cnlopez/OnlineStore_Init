using Data.Interfaces;
using Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            var product = Enumerable.Empty<Product>();
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                product = await sqlConnection.QueryAsync<Product>("spGetProducts", commandType: CommandType.StoredProcedure);
            }
            return product;
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            var product = new Product();
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                product = await sqlConnection.QueryFirstAsync<Product>("spGetProductById", new { @ProductId = productId }, commandType: CommandType.StoredProcedure);
            }
            return product;
        }

        public async Task SaveProductAsync(Product product)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spSaveProduct", new { product.ProductName }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateProduct(int productId, Product product)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spUpdateProduct", new { productId, product.ProductName }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteProduct(int productId)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spDeleteProduct", new { productId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
