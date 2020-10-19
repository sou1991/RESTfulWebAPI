using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTfulWebAPI.Infrastructure;
using RESTfulWebAPI.Models;

namespace RESTfulWebAPI.Application.Movie.Commands
{
    public class DeleteMovieCommand : IDeleteMovieCommand
    {
        private IDataBaseService _dataBaseService;

        public DeleteMovieCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public void Execute(MovieModel movieModel)
        {
            var selectMovie = _dataBaseService.Movie.Where(p => p.id == movieModel.id).First();
            _dataBaseService.Movie.Remove(selectMovie);
            _dataBaseService.Save();
        }
    }
}
