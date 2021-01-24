using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class MovieRatingModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        public int MovieId { get; set; }
    }
}
