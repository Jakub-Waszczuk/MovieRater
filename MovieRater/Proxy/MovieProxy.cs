using MovieRater.Models;
using MovieRater.Proxy.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieRater.Proxy
{
    public class MovieProxy : IMovieProxy
    {
        private HttpClient httpClient = new HttpClient();

        private const string URL = "https://swapi.dev/api/films/";
        public MovieProxy()
        {
            httpClient.BaseAddress = new Uri(URL);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<MovieModel> films()
        {
            HttpResponseMessage response = httpClient.GetAsync("").Result;
            httpClient.Dispose();

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                List<MovieModel> result = JsonConvert.DeserializeObject<Root>(json).results;
                return result;
            }
            else
            {
                throw new Exception();
            }
        }

        public MovieModel films(int Id)
        {              
            HttpResponseMessage response = httpClient.GetAsync($"{Id}/").Result;
            httpClient.Dispose();

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                MovieModel result = JsonConvert.DeserializeObject<MovieModel>(json);
                return result;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
