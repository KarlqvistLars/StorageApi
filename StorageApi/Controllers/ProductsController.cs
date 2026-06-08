using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.DbContext;
using StorageApi.Models;

namespace StorageApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _product;

        public ProductsController(ProductContext product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _product.Products.ToListAsync());
        }
    }
}
