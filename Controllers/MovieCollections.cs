using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviePro.Data;
using MoviePro.Models.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePro.Controllers
{
    public class MovieCollectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieCollectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            id ??= (await _context.Collection.FirstOrDefaultAsync(c => c.Name.ToUpper() == "ALL")).Id;

            ViewData["CollectionId"] = new SelectList(_context.Collection, "Id", "Name", id);

            // go out to the Db, go to the movie table, and select just the id property for all the records, and then turn it into a list asynchronosly
            var allMovieIds = await _context.Movie.Select(mbox => mbox.Id).ToListAsync();

            var movieIdsInCollection = await _context.MovieCollection
                                                     .Where(m => m.CollectionId == id)
                                                     .OrderBy(m => m.Order)
                                                     .Select(m => m.MovieId)
                                                     .ToListAsync();

            var movieIdsNotInCollection = allMovieIds.Except(movieIdsInCollection);

            var moviesInCollection = new List<Movie>();
            movieIdsInCollection.ForEach(movieId => moviesInCollection.Add(_context.Movie.Find(movieId)));

            ViewData["IdsInCollection"] = new MultiSelectList(moviesInCollection, "Id", "Title");

            return View();
        }
    }
}
