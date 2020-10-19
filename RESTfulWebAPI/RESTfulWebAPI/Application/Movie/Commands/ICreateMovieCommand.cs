using RESTfulWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebAPI.Application.Movie.Commands
{
    public interface ICreateMovieCommand
    {
        void Execute(MovieModel MovieModel);
    }
}
