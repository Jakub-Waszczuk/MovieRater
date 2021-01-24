using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MovieRatingContext context)
        {
            context.Database.EnsureCreated();

            if (context.MovieRatings.Any())
            {
                return;
            }
        }
    }
}
