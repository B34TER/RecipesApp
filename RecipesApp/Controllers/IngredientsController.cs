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
    public class IngredientsController : Controller
    {
        private readonly RecipesAppContext _context;

        public IngredientsController(RecipesAppContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var recipesAppContext = _context.Ingredients.Include(i => i.Product).Include(i => i.Recipe);
            return View(await recipesAppContext.ToListAsync());
        }

        // GET: Ingredients/Details/5
        [Route("Ingredients/Details/{productid:int}/{recipeid:int}")]
        public async Task<IActionResult> Details(int? productid, int? recipeid)
        {
            if (productid == null || recipeid == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .Include(i => i.Product)
                .Include(i => i.Recipe)
                .FirstOrDefaultAsync(m => m.RecipeId == recipeid && m.ProductId == productid);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Title");
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,RecipeId,Amount,Necessary")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", ingredient.ProductId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Title", ingredient.RecipeId);
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        [Route("Ingredients/Edit/{productid:int}/{recipeid:int}")]
        public async Task<IActionResult> Edit(int? productid, int? recipeid)
        {
            if (productid == null || recipeid == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.FindAsync(productid, recipeid);
            if (ingredient == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", ingredient.ProductId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Title", ingredient.RecipeId);
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Ingredients/Edit/{productid:int}/{recipeid:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int productid, int recipeid, [Bind("ProductId,RecipeId,Amount,Necessary")] Ingredient ingredient)
        {
            if (productid != ingredient.ProductId || recipeid != ingredient.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.ProductId, ingredient.RecipeId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", ingredient.ProductId);
            ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Title", ingredient.RecipeId);
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        [Route("Ingredients/Delete/{productid:int}/{recipeid:int}")]
        public async Task<IActionResult> Delete(int? productid, int? recipeid)
        {
            if (productid == null || recipeid == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .Include(i => i.Product)
                .Include(i => i.Recipe)
                .FirstOrDefaultAsync(m => m.RecipeId == recipeid && m.ProductId == productid);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Ingredients/Delete/{productid:int}/{recipeid:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int productid, int recipeid)
        {
            var ingredient = await _context.Ingredients.FindAsync(productid, recipeid);
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int productid, int recipeid)
        {
            return _context.Ingredients.Any(e => e.ProductId == productid && e.RecipeId == recipeid);
        }
    }
}
