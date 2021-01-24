using MovieRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Proxy.Interface
{
    public interface IMovieProxy
    {
        public IEnumerable<MovieModel> films();
        public MovieModel films(int Id);
    }
}
