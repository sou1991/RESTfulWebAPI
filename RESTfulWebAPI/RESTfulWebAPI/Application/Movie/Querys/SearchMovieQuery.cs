using RESTfulWebAPI.Infrastructure;
using RESTfulWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebAPI.Application.Movie.Querys
{
    public class SearchMovieQuery : ISearchMovieQuery
    {
        IDataBaseService _dataBaseService;

        public SearchMovieQuery(IDataBaseService dataBaseService)
        {
            this._dataBaseService = dataBaseService;
        }
        public List<MovieModel> Execute(MovieModel movieModel)
        {
            var selectMovie = _dataBaseService.Movie.Where(p => p.id == movieModel.id);

            var movie = selectMovie.Select(p => new MovieModel()
            {
                id = p.id,
                title = p.title,
                film_director = p.film_director,
                release_date = p.release_date
            });

            return movie.ToList();

        }
    }
}
