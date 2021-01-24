using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class MovieModel
    {
        [DisplayName("Title")]
        public string title { get; set; }
        public int episode_id { get; set; }
        [DisplayName("Opening Crawl")]
        public string opening_crawl { get; set; }
        [DisplayName("Director")]
        public string director { get; set; }
        [DisplayName("Producer")]
        public string producer { get; set; }
        [DisplayName("Release Date")]
        public string release_date { get; set; }
        public List<string> characters { get; set; }
        public List<string> planets { get; set; }
        public List<string> starships { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> species { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<MovieModel> results { get; set; }
    }
}
