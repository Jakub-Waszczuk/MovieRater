using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRater.Data;
using MovieRater.Models;
using MovieRater.Others;
using MovieRater.Services.Interface;

namespace MovieRater.Controllers
{
    public class MovieRatingsController : Controller
    {
        private readonly MovieRatingContext _context;
        private readonly IContextService _contextService;

        public MovieRatingsController(MovieRatingContext context, IContextService contextService)
        {
            _context = context;
            _contextService = contextService;
        }

        // GET: MovieRatings
        public async Task<IActionResult> Index()
        {
            return View(await _context.MovieRatings.ToListAsync());
        }

        // GET: MovieRatings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRatingModel = await _context.MovieRatings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieRatingModel == null)
            {
                return NotFound();
            }

            return View(movieRatingModel);
        }

        // GET: MovieRatings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Rating,MovieId")] MovieRatingModel movieRatingModel)
        {
            if (string.IsNullOrWhiteSpace(movieRatingModel.Username))
                movieRatingModel.Username = "Anonymous";
            movieRatingModel.MovieId = _contextService.GetCurrentContext();
            
            if (ModelState.IsValid)
            {
                movieRatingModel.Id = Guid.NewGuid();
                _context.Add(movieRatingModel);              
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Movie", _contextService.GetCurrentContext());

            }
            return View(movieRatingModel);
        }

        // GET: MovieRatings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRatingModel = await _context.MovieRatings.FindAsync(id);
            if (movieRatingModel == null)
            {
                return NotFound();
            }
            return View(movieRatingModel);
        }

        // POST: MovieRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Username,Rating,MovieId")] MovieRatingModel movieRatingModel)
        {
            if (id != movieRatingModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieRatingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieRatingModelExists(movieRatingModel.Id))
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
            return View(movieRatingModel);
        }

        // GET: MovieRatings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieRatingModel = await _context.MovieRatings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieRatingModel == null)
            {
                return NotFound();
            }

            return View(movieRatingModel);
        }

        // POST: MovieRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var movieRatingModel = await _context.MovieRatings.FindAsync(id);
            _context.MovieRatings.Remove(movieRatingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieRatingModelExists(Guid id)
        {
            return _context.MovieRatings.Any(e => e.Id == id);
        }
    }
}
