using Microsoft.AspNetCore.Mvc;
using MovieRater.Data;
using MovieRater.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.ViewComponents
{
    public class MovieRatingsListViewComponent : ViewComponent
    {
        private readonly MovieRatingContext context;
        private readonly IContextService _contextService;

        public MovieRatingsListViewComponent(MovieRatingContext _context, IContextService contextService)
        {
            context = _context;
            _contextService = contextService;
        }

        public IViewComponentResult Invoke()
        {
            var result = context.MovieRatings.Where(x => x.MovieId == _contextService.GetCurrentContext());
            return View(result);
        }
    }
}
