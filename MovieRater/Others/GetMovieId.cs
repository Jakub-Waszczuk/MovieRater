using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRater.Others
{
    public static class GetMovieId
    {
        //Translates episode id to movie id/movie id to episode id
        public static int TranslateIds(int episodeId)
        {
            switch (episodeId)
            {
                default:
                    {
                        throw new Exception();
                    }                
                case (1):
                    {
                        return 4;
                    }
                   
                case (2):
                    {
                        return 5;
                    } 
                case (3): 
                    {
                        return 6;
                    } 
                case (4): 
                    { 
                        return 1; 
                    } 
                case (5): 
                    { 
                        return 2; 
                    }
                case (6): 
                    { 
                        return 3; 
                    } 
            }
        }
       
    }
}
