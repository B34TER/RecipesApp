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
        [Route("RecipeAppliances/Details/{applianceid:int}/{recipeid:int}")]
        public async Task<IActionResult> Details(int? applianceid, int? recipeid)
        {
            if (applianceid == null || recipeid == null)
            {
                return NotFound();
            }

            var recipeAppliance = await _context.RecipeAppliance
                .Include(r => r.Appliance)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.RecipeId == recipeid && m.ApplianceId == applianceid);
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
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Title");
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
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Title", recipeAppliance.RecipeId);
            return View(recipeAppliance);
        }

        // GET: RecipeAppliances/Edit/5
        [Route("RecipeAppliances/Edit/{applianceid:int}/{recipeid:int}")]
        public async Task<IActionResult> Edit(int? applianceid, int? recipeid)
        {
            if (applianceid == null || recipeid == null)
            {
                return NotFound();
            }

            var recipeAppliance = await _context.RecipeAppliance.FindAsync(recipeid, applianceid);
            if (recipeAppliance == null)
            {
                return NotFound();
            }
            ViewData["ApplianceId"] = new SelectList(_context.Appliances, "Id", "Name", recipeAppliance.ApplianceId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Title", recipeAppliance.RecipeId);
            return View(recipeAppliance);
        }

        // POST: RecipeAppliances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("RecipeAppliances/Edit/{applianceid:int}/{recipeid:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int applianceid, int recipeid, [Bind("RecipeId,ApplianceId,Necessary")] RecipeAppliance recipeAppliance)
        {
            if (applianceid != recipeAppliance.ApplianceId || recipeid != recipeAppliance.RecipeId)
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
                    if (!RecipeApplianceExists(recipeAppliance.ApplianceId, recipeAppliance.RecipeId))
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
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Title", recipeAppliance.RecipeId);
            return View(recipeAppliance);
        }

        // GET: RecipeAppliances/Delete/5
        [Route("RecipeAppliances/Delete/{applianceid:int}/{recipeid:int}")]
        public async Task<IActionResult> Delete(int? applianceid, int? recipeid)
        {
            if (applianceid == null || recipeid == null)
            {
                return NotFound();
            }

            var recipeAppliance = await _context.RecipeAppliance
                .Include(r => r.Appliance)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.ApplianceId == applianceid && m.RecipeId == recipeid);
            if (recipeAppliance == null)
            {
                return NotFound();
            }

            return View(recipeAppliance);
        }

        // POST: RecipeAppliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("RecipeAppliances/Delete/{applianceid:int}/{recipeid:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int applianceid, int recipeid)
        {
            var recipeAppliance = await _context.RecipeAppliance.FindAsync(recipeid, applianceid);
            _context.RecipeAppliance.Remove(recipeAppliance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeApplianceExists(int applianceid, int recipeid)
        {
            return _context.RecipeAppliance.Any(e => e.ApplianceId == applianceid && e.RecipeId == recipeid);
        }
    }
}
