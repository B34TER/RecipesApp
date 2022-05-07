#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Data;
using RecipesApp.Models;

namespace RecipesApp.Controllers
{
    public class RecipeAppliancesController : Controller
    {
        private readonly RecipesAppContext _context;

        public RecipeAppliancesController(RecipesAppContext context)
        {
            _context = context;
        }

        // GET: RecipeAppliances
        public async Task<IActionResult> Index()
        {
            var recipesAppContext = _context.RecipeAppliance.Include(r => r.Appliance).Include(r => r.Recipe);
            return View(await recipesAppContext.ToListAsync());
        }

        // GET: RecipeAppliances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeAppliance = await _context.RecipeAppliance
                .Include(r => r.Appliance)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipeAppliance == null)
            {
                return NotFound();
            }

            return View(recipeAppliance);
        }

        // GET: RecipeAppliances/Create
        public IActionResult Create()
        {
            ViewData["ApplianceId"] = new SelectList(_context.Appliances, "Id", "Name");
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Instruction");
            return View();
        }

        // POST: RecipeAppliances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,ApplianceId,Necessary")] RecipeAppliance recipeAppliance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeAppliance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplianceId"] = new SelectList(_context.Appliances, "Id", "Name", recipeAppliance.ApplianceId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Instruction", recipeAppliance.RecipeId);
            return View(recipeAppliance);
        }

        // GET: RecipeAppliances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeAppliance = await _context.RecipeAppliance.FindAsync(id);
            if (recipeAppliance == null)
            {
                return NotFound();
            }
            ViewData["ApplianceId"] = new SelectList(_context.Appliances, "Id", "Name", recipeAppliance.ApplianceId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Instruction", recipeAppliance.RecipeId);
            return View(recipeAppliance);
        }

        // POST: RecipeAppliances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,ApplianceId,Necessary")] RecipeAppliance recipeAppliance)
        {
            if (id != recipeAppliance.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeAppliance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeApplianceExists(recipeAppliance.RecipeId))
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
            ViewData["ApplianceId"] = new SelectList(_context.Appliances, "Id", "Name", recipeAppliance.ApplianceId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Instruction", recipeAppliance.RecipeId);
            return View(recipeAppliance);
        }

        // GET: RecipeAppliances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeAppliance = await _context.RecipeAppliance
                .Include(r => r.Appliance)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipeAppliance == null)
            {
                return NotFound();
            }

            return View(recipeAppliance);
        }

        // POST: RecipeAppliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeAppliance = await _context.RecipeAppliance.FindAsync(id);
            _context.RecipeAppliance.Remove(recipeAppliance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeApplianceExists(int id)
        {
            return _context.RecipeAppliance.Any(e => e.RecipeId == id);
        }
    }
}
