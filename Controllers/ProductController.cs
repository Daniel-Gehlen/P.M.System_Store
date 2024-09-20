using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product, int categoryNumber)
        {
            if (ProductService.AddProduct(categoryNumber, product.Name, product.Price))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{categoryId}/{productId}")]
        public IActionResult RemoveProduct(int categoryId, int productId)
        {
            if (ProductService.RemoveProduct(categoryId, productId))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{categoryId}/{productId}")]
        public IActionResult ModifyPrice(int categoryId, int productId, [FromBody] decimal newPrice)
        {
            if (ProductService.ModifyProductPrice(categoryId, productId, newPrice))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
