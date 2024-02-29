using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sprint_Week_1.Models;


namespace Sprint_Week_1.Controllers
{
    public class InventoryController : Controller
    {
        private readonly BookStorecontext _context;

        public InventoryController(BookStoreContext context)
        {
            _context = context;
        }

        // GET: Module
        public async Task<IActionResult> Index()
        {
            var timeappContext = _context.inventory.Include(u => u.UsernameNavigation);
            return View(await timeappContext.ToListAsync());
        }

        // GET: Module/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.inventory
                .Include(u => u.UsernameNavigation)
                .FirstOrDefaultAsync(m => m.Code == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // GET: Module/Create
        public IActionResult Create()
        {
            ViewData["Username"] = new SelectList(_context.Registers, "Username", "Username");
            return View();
        }

        // POST: Module/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Username,ModulesName,Credits,ClassHours,NumberOfWeeks,StartDate")] System.Reflection.Module @module)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@module);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Username"] = new SelectList(_context.Registers, "Username", "Username", @module);
            return View(@module);
        }

        // GET: Module/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.invetory.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }
            ViewData["Username"] = new SelectList(_context.Registers, "Username", "Username", @module.Username);
            return View(@module);
        }

        // POST: Module/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Price")] System.Reflection.Module @module)
        {
            if (id == null)
            {
                return (IActionResult)(@module = null);
            }
            else
            {

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@module);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModuleExists(@module))
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
            ViewData["Username"] = new SelectList(_context.Registers, "Username", "Username", @module);
            return View(@module);
        }

        private bool ModuleExists(object code)
        {
            throw new NotImplementedException();
        }

        // GET: Module/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @module = await _context.inventory
                .Include(u => u.UsernameNavigation)
                .FirstOrDefaultAsync(m => m.Code == id);
            if (@module == null)
            {
                return NotFound();
            }

            return View(@module);
        }

        // POST: Module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var @module = await _context.inventory.FindAsync(id);
            if (@module != null)
            {
                _context.inventory.Remove(@module);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModuleExists(string id)
        {
            return _context.inventory.Any(e => e.Code == id);
        }
    }
    public IActionResult Index()
        {
            return View();
        }
}
