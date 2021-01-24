using MovieRater.Others;
using System;
using Xunit;

namespace MovieRater.Tests
{
    public class GetMovieIdTest
    {
        [Fact]
        public void EpIdToMovieId()
        {
            var movieId = GetMovieId.TranslateIds(1);
            Assert.Equal(4, movieId);
        }

        [Fact]
        public void MovieIdToEpId()
        {
            var movieId = GetMovieId.TranslateIds(4);
            Assert.Equal(1, movieId);
        }
    }
}
