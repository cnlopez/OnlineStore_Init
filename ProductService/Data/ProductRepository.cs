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
            var products = new List<Products>();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spGetProducts", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = await sqlCommand.ExecuteReaderAsync();
                while (rd.Read())
                {
                    products.Add(new Products
                    {
                        ProductId = rd.GetInt32("ProductId"),
                        ProductName = rd["ProductName"].ToString()
                    });
                }
            }
            return products;
        }
    }
}
