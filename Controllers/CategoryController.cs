using Microsoft.AspNetCore.Mvc;
using WebApp.Models; // <-- Adicione esta linha para importar Product e Category

namespace WebApp.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category newCategory)
        {
            newCategory.Number = categories.Count + 1;
            categories.Add(newCategory);
            return Ok(newCategory);
        }

        [HttpGet("{categoryId}/products")]
        public IActionResult GetProducts(int categoryId)
        {
            var category = categories.FirstOrDefault(c => c.Number == categoryId);
            if (category == null) return NotFound("Category not found");
            return Ok(category.Products);
        }

        [HttpPost("{categoryId}/products")]
        public IActionResult AddProduct(int categoryId, [FromBody] Product newProduct)
        {
            var category = categories.FirstOrDefault(c => c.Number == categoryId);
            if (category == null) return NotFound("Category not found");

            newProduct.Number = category.Products.Count + 1;
            category.Products.Add(newProduct);
            return Ok(newProduct);
        }
    }
}
