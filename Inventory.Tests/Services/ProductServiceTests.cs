using AutoMapper;
using Inventory.Application.Interfaces;
using Inventory.Application.Services;
using Inventory.Infrastructure.Data;
using Inventory.Infrastructure.Models;
using Inventory.Tests.Utility;
using Moq;

namespace Inventory.Tests.Services
{
    public class ProductServiceTests 
    {
        [Fact]
        public void GetAllProducts_ReturnsCorrectCount()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            context.Products.Add(new Product { Name = "TestProduct",CategoryID=1 });
            context.SaveChanges();

            var service = new ProductService(context);

            // Act
            var result = service.GetAllProductsAsync();

            // Assert
            Assert.Single(result.Result);
        }        
        [Fact]
        public void AddProduct_ShouldAddProductSuccessfully()
        {
            // Arrange
            var context = TestDbContextFactory.Create();
            context.Products.Add(new Product { ID = 1, Name = "Product1", StockQuantity = 10 });
            context.SaveChanges();

            var service = new ProductService(context);

            // Act
            var result = service.GetProductByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Product1", result.Result.Name);
        }
    }
}
