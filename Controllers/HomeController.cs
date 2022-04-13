using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviePro.Data;
using MoviePro.Models;
using MoviePro.Models.ViewModels;
using MoviePro.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MoviePro.Enums;

namespace MoviePro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IRemoteMovieService _tmdbMovieService;  //service allows me to reach out to TMDB Api and grab the movie data I'm interested in

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IRemoteMovieService tmdbMovieService)
        {
            _logger = logger;
            _context = context;
            _tmdbMovieService = tmdbMovieService;
        }

        public async Task<IActionResult> Index()
        {
            const int count = 16;
            var data = new LandingPageVM()  // data = to a new instance of LandingPageVM
            {
                

                // filling out the properties
                CustomCollections = await _context.Collection
                                                  .Include(c => c.MovieCollections)  // include movieCollections that are related to it
                                                  .ThenInclude(mc => mc.Movie)  // include the movies inside those movie collections
                                                  .ToListAsync(),  // return the whole list asynchronously
                NowPlaying = await _tmdbMovieService.SearchMovieAsync(MovieCategory.now_playing, count),
                Popular = await _tmdbMovieService.SearchMovieAsync(MovieCategory.popular, count),
                TopRated = await _tmdbMovieService.SearchMovieAsync(MovieCategory.top_rated, count),
                Upcoming = await _tmdbMovieService.SearchMovieAsync(MovieCategory.upcoming, count)
            };



            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
