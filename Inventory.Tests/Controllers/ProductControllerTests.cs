using Inventory.Infrastructure.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;

namespace Inventory.Tests.Controllers
{
    public class ProductsApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductsApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/products");
            response.EnsureSuccessStatusCode();
        }
       
        [Fact]
        public async Task Post_AddsNewProduct()
        {
            var productDto = new ProductDTO
            {
                CategoryId=1, 
                Name = "Test Product",
                Price = 99.99m,
                StockQuantity=6,
            };

            var json = JsonConvert.SerializeObject(productDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/products", content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var returnedProduct = JsonConvert.DeserializeObject<ProductDTO>(responseContent);

            Assert.Equal(productDto.Name, returnedProduct.Name);
            Assert.Equal(productDto.Price, returnedProduct.Price);
        }
    }    

}
