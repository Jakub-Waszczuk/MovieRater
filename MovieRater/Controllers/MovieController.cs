using Microsoft.AspNetCore.Mvc;
using MovieRater.Others;
using MovieRater.Proxy.Interface;
using MovieRater.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieProxy _movieProxy;
        private readonly IContextService _contextService;

        public MovieController(IMovieProxy movieProxy, IContextService contextService)
        {
            _movieProxy = movieProxy;
            _contextService = contextService;
        }
        public IActionResult Index()
        {
            var movies = _movieProxy.films();
            return View(movies.ToList());
        }

        public IActionResult Details(int id)
        {
            int Id;
            if (id == 0)
            {
                Id = GetMovieId.TranslateIds(_contextService.GetCurrentContext());
            }
            else
                Id = id;

            if (Id < 0 || Id > 6)
            {
                return NotFound();
            }

            var movieModel = _movieProxy.films(GetMovieId.TranslateIds(Id));
            if (movieModel == null)
            {
                return NotFound();
            }

            _contextService.Push(GetMovieId.TranslateIds(Id));

            return View(movieModel);
        }

        public IActionResult ReturnToMovieDetails()
        {
            return Details(_contextService.GetCurrentContext());
        }

        public IActionResult AddRating()
        {
            return RedirectToAction("Create", "MovieRatings");
        }
    }
}
