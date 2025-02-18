﻿using Data.Interfaces;
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

        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            var products = Enumerable.Empty<Products>();
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                products = await sqlConnection.QueryAsync<Products>("spGetProducts", commandType: CommandType.StoredProcedure);
            }
            return products;
        }

        public async Task<Products> GetProductAsync(int productId)
        {
            var product = new Products();
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                product = await sqlConnection.QueryFirstAsync<Products>("spGetProductsById", new { @ProductId = productId }, commandType: CommandType.StoredProcedure);
            }
            return product;
        }

        public async Task SaveProductAsync(Products product)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spSaveProducts", new { product.ProductName }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateProductAsync(int productId, Products product)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spUpdateProducts", new { productId, product.ProductName }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spDeleteProducts", new { productId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
