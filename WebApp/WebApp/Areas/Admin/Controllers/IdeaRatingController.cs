#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App;
using Domain.App;

namespace WebApp.Areas_Admin_Controllers
{
    public class IdeaRatingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdeaRatingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IdeaRating
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IdeaRatings.Include(i => i.ProjectIdea).Include(i => i.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IdeaRating/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaRating = await _context.IdeaRatings
                .Include(i => i.ProjectIdea)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideaRating == null)
            {
                return NotFound();
            }

            return View(ideaRating);
        }

        // GET: IdeaRating/Create
        public IActionResult Create()
        {
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: IdeaRating/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rating,UserId,ProjectIdeaId")] IdeaRating ideaRating)
        {
            if (ModelState.IsValid)
            {
                ideaRating.Id = Guid.NewGuid();
                _context.Add(ideaRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation", ideaRating.ProjectIdeaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ideaRating.UserId);
            return View(ideaRating);
        }

        // GET: IdeaRating/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaRating = await _context.IdeaRatings.FindAsync(id);
            if (ideaRating == null)
            {
                return NotFound();
            }
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation", ideaRating.ProjectIdeaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ideaRating.UserId);
            return View(ideaRating);
        }

        // POST: IdeaRating/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Rating,UserId,ProjectIdeaId")] IdeaRating ideaRating)
        {
            if (id != ideaRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ideaRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdeaRatingExists(ideaRating.Id))
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
            ViewData["ProjectIdeaId"] = new SelectList(_context.ProjectIdeas, "Id", "Explanation", ideaRating.ProjectIdeaId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", ideaRating.UserId);
            return View(ideaRating);
        }

        // GET: IdeaRating/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ideaRating = await _context.IdeaRatings
                .Include(i => i.ProjectIdea)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ideaRating == null)
            {
                return NotFound();
            }

            return View(ideaRating);
        }

        // POST: IdeaRating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ideaRating = await _context.IdeaRatings.FindAsync(id);
            _context.IdeaRatings.Remove(ideaRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdeaRatingExists(Guid id)
        {
            return _context.IdeaRatings.Any(e => e.Id == id);
        }
    }
}
