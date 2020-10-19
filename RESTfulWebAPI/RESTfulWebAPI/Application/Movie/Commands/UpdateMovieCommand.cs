using RESTfulWebAPI.Infrastructure;
using RESTfulWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebAPI.Application.Movie.Commands
{
    public class UpdateMovieCommand : IUpdateMovieCommand
    {
        private IDataBaseService _dataBaseService;

        public UpdateMovieCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public void Execute(MovieModel movieModel)
        {
            var movie = _dataBaseService.Movie.Where(p => p.id == movieModel.id).First();
            movie.title = movieModel.title;
            movie.film_director = movieModel.film_director;
            movie.release_date = movieModel.release_date;
            _dataBaseService.Save();

        }
    }
}
