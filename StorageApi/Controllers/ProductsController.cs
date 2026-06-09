using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageApi.DTOs;
using StorageApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly StorageApiContext _context;
    public ProductsController(StorageApiContext context)
    {
        _context = context;
    }

    // GET: api/Product
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProduct()
    {
        var products = await _context.Products
            .OrderBy(p => p.Name)
            .Select(p => new ProductDto {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                Shelf = p.Shelf,
                Count = p.Count,
                Description = p.Description
            })
            .ToListAsync();

        return Ok(products);
    }

    // GET: api/Product/3
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        var productDto = new ProductDto {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = product.Category,
            Shelf = product.Shelf,
            Count = product.Count,
            Description = product.Description
        };

        return Ok(productDto);
    }

    // PUT: api/Product/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
    {
        if (id != productDto.Id)
        {
            return BadRequest();
        }

        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.Category = productDto.Category;
        product.Shelf = productDto.Shelf;
        product.Count = productDto.Count;
        product.Description = productDto.Description;

        try
        {
            await _context.SaveChangesAsync();
        } catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }

            return Conflict("Produkten har ändrats eller tagits bort sedan den hämtades.");
        }

        return NoContent();
    }

    // POST: api/Product
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<IActionResult> PostProduct(ProductDto productDto)
    {
        var product = new Product {
            Id = productDto.Id,
            Name = productDto.Name,
            Price = productDto.Price,
            Category = productDto.Category,
            Shelf = productDto.Shelf,
            Count = productDto.Count,
            Description = productDto.Description
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    // DELETE: api/Product/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // PATCH: api/Product/5
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchProduct(
        int id,
        JsonPatchDocument<ProductDto> patchDocument)
    {
        if (patchDocument == null)
        {
            return BadRequest();
        }

        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        var productDto = new ProductDto {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Category = product.Category,
            Shelf = product.Shelf,
            Count = product.Count,
            Description = product.Description
        };

        patchDocument.ApplyTo(productDto, ModelState);

        if (!TryValidateModel(productDto))
        {
            return ValidationProblem(ModelState);
        }

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.Category = productDto.Category;
        product.Shelf = productDto.Shelf;
        product.Count = productDto.Count;
        product.Description = productDto.Description;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int? id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
}
