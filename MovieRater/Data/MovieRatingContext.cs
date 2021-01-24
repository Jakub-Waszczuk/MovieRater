using Microsoft.EntityFrameworkCore;
using MovieRater.Models;

namespace MovieRater.Data
{
    public class MovieRatingContext : DbContext
    {
        public MovieRatingContext(DbContextOptions<MovieRatingContext> options) : base(options)
        {

        }

        public DbSet<MovieRatingModel> MovieRatings { get; set; }
    }
}
