using Microsoft.AspNetCore.Mvc;
using RESTfulWebAPI.Application;
using RESTfulWebAPI.Application.Movie.Commands;
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
        IUpdateMovieCommand _updateMovieCommand;

        public MovieController(ISearchMovieQuery serachMovieQuery, IUpdateMovieCommand updateMovieCommand)
        {
            this._serachMovieQuery = serachMovieQuery;
            this._updateMovieCommand = updateMovieCommand;
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

        [HttpPut]
        public IActionResult Update(MovieModel movieModel)
        {
            try
            {
                _updateMovieCommand.Execute(movieModel);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
