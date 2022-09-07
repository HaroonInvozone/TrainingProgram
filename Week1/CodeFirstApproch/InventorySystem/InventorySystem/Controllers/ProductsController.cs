using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventorySystem.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace InventorySystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly InventoryDb _context;
        private object sqlParms;

        public ProductsController(InventoryDb context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'InventoryDb.Products'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Products products = new Products();
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var result = conn.Query(sql: "[dbo.sp_GetProductRecord]", param: new
                {
                    Id = id
                },
                commandType: CommandType.StoredProcedure);
                products = (Products)result;
            }

            //var result =  _context.Database.ExecuteSqlRaw($"sp_GetProductRecord {id}");
            //var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'InventoryDb.Products'  is null.");
            }
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                _context.Products.Remove(products);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
