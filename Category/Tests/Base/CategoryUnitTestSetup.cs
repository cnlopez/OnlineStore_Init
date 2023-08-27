using Business.Services;
using Data;
using Data.Interfaces;
using Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tests.Base
{
    public partial class CategoryUnitTest
    {
        private const string JsonBasePath = "Json/";
        public IEnumerable<Category> CategoryModel { get; set; }

        public virtual void Init()
        {
            CategoryRepositoryMock = new Mock<ICategoryRepository>();
            CategoryService = new CategoryService(CategoryRepositoryMock.Object, Mapper);
        }

        [SetUp]
        public virtual void Setup()
        {
            Init();
            PopulateDatabase();
        }

        public static T LoadFromJsonFile<T>(string route)
        {
            var path = Path.GetFullPath(route);
            using var reader = new StreamReader(path);
            var json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<T>(json);
        }

        private void PopulateDatabase()
        {
            CategoryModel = LoadFromJsonFile<IEnumerable<Category>>(JsonBasePath + "Category.json");
        }
    }
}
