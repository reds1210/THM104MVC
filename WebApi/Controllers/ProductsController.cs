using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Entity;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }


        [HttpGet("order/{id}")]
        public async Task<object> GetProducts2(int id)
        {
            var order = _context.Orders
                //.Include(x=>x.OrderDetails)
                //.ThenInclude(x=>x.Product)
                //.ThenInclude(x=>x.Category)
                .FirstOrDefault(x => x.OrderId == id);
            if (order == null) { return NotFound(); }

            return new
            {
                order.OrderId,
                order.OrderDate,
                order.ShipName,
                order.ShipAddress,
                order.ShipCity,
                order.ShipRegion,
                order.ShipPostalCode,
                Detail = order.OrderDetails.Select(z => new
                {
                    z.UnitPrice,
                    z.Quantity,
                    z.Product.ProductName,
                    z.Product.Category.CategoryName,
                    categoryDescription = z.Product.Category.Description
                })
            };
        }


        [HttpGet("{xxx}/{ooo}")]
        public async Task<IActionResult> GetProducts2()
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var data  =await _context.Products.ToListAsync();
            

            return Ok(JsonSerializer.Serialize(data));
            //return await _context.Products.ToListAsync();
        }

        [HttpGet("json/{ooo}")]
        public ActionResult<object> GetProducts3(string ooo)
        {
            if (ooo == "null") 
            {
                return NotFound();
            }
            if (ooo == "prod")
            {
               return _context.Products.ToList();
            }
            if (ooo == "emp")
            {
                return _context.Employees.Select(x=> new 
                {
                    id=x.EmployeeId,
                    name = x.LastName+x.FirstName,
                    address = x.Address

                }).ToList();
            }
            return _context.Categories.ToList();

        }


        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            return await _context.Products.ToListAsync();
        }




        // GET: api/Products/5
        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(statusCode:StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDto product)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'NorthwindContext.Products'  is null.");
            }

            var data = new Product
            {
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                ReorderLevel = product.ReorderLevel,
                SupplierId = product.SupplierId,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
            };

            _context.Products.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = data.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
