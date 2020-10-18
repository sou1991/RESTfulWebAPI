using Microsoft.AspNetCore.Mvc;
using RESTfulWebAPI.Application;
using RESTfulWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        ISearchMovieQuery _serachMovieQuery;
        public MovieController(ISearchMovieQuery serachMovieQuery)
        {
            this._serachMovieQuery = serachMovieQuery;
        }


        [HttpGet("{prmID}")]
        public ActionResult<IEnumerable<MovieModel>> Get(int prmID)
        {
            var result = _serachMovieQuery.Execute(new MovieModel { id = prmID });
            if(!result.Any())
            {
                return NotFound();
            }
            return result;
        }
    }
}
