using asp_dotnet8_core_web_api_linq_practice.Models;

using Microsoft.AspNetCore.Mvc;

namespace asp_dotnet8_core_web_api_linq_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        private readonly List<Models.Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200.00M, Category = "Electronics" },
            new Product { Id = 2, Name = "Smartphone", Price = 800.00M, Category = "Electronics" },
            new Product { Id = 3, Name = "Tablet", Price = 300.00M, Category = "Electronics" },
            new Product { Id = 4, Name = "Headphones", Price = 150.00M, Category = "Electronics" },
            new Product { Id = 5, Name = "Smartwatch", Price = 200.00M, Category = "Electronics" },
            new Product { Id = 6, Name = "Camera", Price = 700.00M, Category = "Electronics" },
            new Product { Id = 7, Name = "Monitor", Price = 250.00M, Category = "Electronics" },
            new Product { Id = 8, Name = "Keyboard", Price = 50.00M, Category = "Electronics" },
            new Product { Id = 9, Name = "Mouse", Price = 25.00M, Category = "Electronics" },
            new Product { Id = 10, Name = "Charger", Price = 30.00M, Category = "Electronics" },
            new Product { Id = 11, Name = "T-shirt", Price = 20.00M, Category = "Clothing" },
            new Product { Id = 12, Name = "Jeans", Price = 50.00M, Category = "Clothing" },
            new Product { Id = 13, Name = "Jacket", Price = 100.00M, Category = "Clothing" },
            new Product { Id = 14, Name = "Shoes", Price = 75.00M, Category = "Clothing" },
            new Product { Id = 15, Name = "Hat", Price = 25.00M, Category = "Clothing" },
            new Product { Id = 16, Name = "Apple", Price = 1.00M, Category = "Groceries" },
            new Product { Id = 17, Name = "Milk", Price = 1.50M, Category = "Groceries" },
            new Product { Id = 18, Name = "Bread", Price = 2.00M, Category = "Groceries" },
            new Product { Id = 19, Name = "Eggs", Price = 3.00M, Category = "Groceries" },
            new Product { Id = 20, Name = "Butter", Price = 2.50M, Category = "Groceries" }
        };

        // Get all products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(products);
        }

        // Get products ordered by price
        [HttpGet("orderbyprice")]
        public ActionResult<IEnumerable<Product>> GetProductsOrderedByPrice()
        {
            var orderedProducts = products.OrderBy(p => p.Price).ToList();
            return Ok(orderedProducts);
        }

        // Get products filtered by category
        [HttpGet("category/{category}")]
        public ActionResult<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            var filteredProducts = products.Where(p => p.Category.ToLower() == category.ToLower()).ToList();
            return Ok(filteredProducts);
        }

        // Get products with price greater than a specified value
        [HttpGet("pricegreaterthan/{price}")]
        public ActionResult<IEnumerable<Product>> GetProductsByPriceGreaterThan(decimal price)
        {
            var filteredProducts = products.Where(p => p.Price > price).ToList();
            return Ok(filteredProducts);
        }

        // Get product names and their prices (mapping)
        [HttpGet("namesandprices")]
        public ActionResult<IEnumerable<object>> GetProductNamesAndPrices()
        {
            var namesAndPrices = products.Select(p => new { p.Name, p.Price }).ToList();
            return Ok(namesAndPrices);
        }

        // Get product names ordered by name
        [HttpGet("orderbyname")]
        public ActionResult<IEnumerable<string>> GetProductNamesOrderedByName()
        {
            var orderedNames = products.OrderBy(p => p.Name).Select(p => p.Name).ToList();
            return Ok(orderedNames);
        }

        // Get the most expensive product
        [HttpGet("mostexpensive")]
        public ActionResult<Product> GetMostExpensiveProduct()
        {
            var mostExpensiveProduct = products.OrderByDescending(p => p.Price).FirstOrDefault();
            return Ok(mostExpensiveProduct);
        }

        // Get the cheapest product
        [HttpGet("cheapest")]
        public ActionResult<Product> GetCheapestProduct()
        {
            var cheapestProduct = products.OrderBy(p => p.Price).FirstOrDefault();
            return Ok(cheapestProduct);
        }
    }
}
