using RESTfulWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebAPI.Application
{
    public interface ISearchMovieQuery
    {
        List<MovieModel> Execute(MovieModel movie);
    }
}
