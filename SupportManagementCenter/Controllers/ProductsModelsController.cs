using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportManagementCenter.Models;

namespace SupportManagementCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsModelsController : ControllerBase
    {
        private readonly SupportManagementCenterDBContext _context;

        public ProductsModelsController(SupportManagementCenterDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductsModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsModel>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/ProductsModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsModel>> GetProductsModel(long id)
        {
            var productsModel = await _context.Products.FindAsync(id);

            if (productsModel == null)
            {
                return NotFound();
            }

            return productsModel;
        }

        // PUT: api/ProductsModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsModel(long id, ProductsModel productsModel)
        {
            if (id != productsModel.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsModelExists(id))
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

        // POST: api/ProductsModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductsModel>> PostProductsModel(ProductsModel productsModel)
        {
            _context.Products.Add(productsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsModel", new { id = productsModel.ProductId }, productsModel);
        }

        // DELETE: api/ProductsModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsModel>> DeleteProductsModel(long id)
        {
            var productsModel = await _context.Products.FindAsync(id);
            if (productsModel == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productsModel);
            await _context.SaveChangesAsync();

            return productsModel;
        }

        private bool ProductsModelExists(long id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
