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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            var category = Enumerable.Empty<Category>();
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                category = await sqlConnection.QueryAsync<Category>("spGetCategorys", commandType: CommandType.StoredProcedure);
            }
            return category;
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            var category = new Category();
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                category = await sqlConnection.QueryFirstAsync<Category>("spGetCategoryById", new { @CategoryId = categoryId }, commandType: CommandType.StoredProcedure);
            }
            return category;
        }

        public async Task SaveCategoryAsync(Category category)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spSaveCategory", new { category.CategoryName }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateCategory(int categoryId, Category category)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spUpdateCategory", new { categoryId, category.CategoryName }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteCategory(int categoryId)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("API_OnlineStoreInit")))
            {
                await sqlConnection.ExecuteAsync("spDeleteCategory", new { categoryId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
