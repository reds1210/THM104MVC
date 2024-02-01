using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public SuppliersController(NorthwindContext context)
        {
            _context = context;
        }
        [HttpGet("total/{pagePerCount}")]
        public async Task<object> GetTotal(int pagePerCount = 20)
        {
            var total = _context.Suppliers.Count();
            decimal a = (decimal)total / (decimal)pagePerCount;
            return new
            {
                Total = total,
                TotalPages = pagePerCount,                
                TotalPage = Math.Ceiling(a)
            };
        }
        // GET: api/Suppliers
        [HttpGet("p/{page}")]
        public async Task<ActionResult<IEnumerable<SuppliersDto>>> GetSuppliers(int page = 1)
        {
            var pagePerCount = 20;
            if (_context.Suppliers == null)
            {
                return NotFound();
            }
            var temp = _context.Suppliers.Select(x => new SuppliersDto
            {
                CompanyName = x.CompanyName,
                SupplierId = x.SupplierId,
                Address = x.Address,
                Region = x.Region,
                City = x.City
            }).OrderBy(x=>x.SupplierId).Take(pagePerCount*page).Skip(pagePerCount * (page-1)).ToList();
            return temp;
            //return await _context.Suppliers.ToListAsync();
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuppliersDto>> GetSupplier(int id)
        {
            if (_context.Suppliers == null)
            {
                return NotFound();
            }
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return new SuppliersDto
            {
                CompanyName = supplier.CompanyName,
                SupplierId = supplier.SupplierId,
            };
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, SuppliersUpdateDto supplier)
        {
            #region old
            //var data = new Supplier
            //{
            //    SupplierId = id,
            //    CompanyName = supplier.CompanyName,
            //    ContactName = supplier.ContactName,
            //    ContactTitle = supplier.ContactTitle,
            //};
            //_context.Entry(data).State = EntityState.Modified;
            #endregion


            var data = _context.Suppliers.FirstOrDefault(x => x.SupplierId == id);
            //var data = _context.Suppliers.Find(id);

            data.CompanyName = supplier.CompanyName;
            data.ContactName = supplier.ContactName;
            data.ContactTitle = supplier.ContactTitle;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(SuppliersDto supplier)
        {
            if (_context.Suppliers == null)
            {
                return Problem("Entity set 'NorthwindContext.Suppliers'  is null.");
            }

            _context.Suppliers.Add(new Supplier
            {
                CompanyName = supplier.CompanyName
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplier", new { id = supplier.SupplierId }, supplier);
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            if (_context.Suppliers == null)
            {
                return NotFound();
            }
            #region old
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            #endregion
            //var d = new Supplier() { SupplierId = id };
            //_context.Suppliers.Attach(d);
            //_context.Entry(d).State = EntityState.Deleted;

            //var a = await _context.SaveChangesAsync();




            return NoContent();
        }

        private bool SupplierExists(int id)
        {
            return (_context.Suppliers?.Any(e => e.SupplierId == id)).GetValueOrDefault();
        }
    }
}
