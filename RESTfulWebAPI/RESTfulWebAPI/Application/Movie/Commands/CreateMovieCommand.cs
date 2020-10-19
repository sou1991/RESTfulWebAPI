using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTfulWebAPI.Entities;
using RESTfulWebAPI.Infrastructure;
using RESTfulWebAPI.Models;

namespace RESTfulWebAPI.Application.Movie.Commands
{
    public class CreateMovieCommand : ICreateMovieCommand
    {
        private IDataBaseService _dataBaseService;

        public CreateMovieCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public void Execute(MovieModel movieModel)
        {
            var movieEntity = new MovieEntity()
            {
                title = movieModel.title,
                film_director = movieModel.film_director,
                release_date = DateTime.Now
            };

            _dataBaseService.Movie.Add(movieEntity);
            _dataBaseService.Save();
        }
    }
}
