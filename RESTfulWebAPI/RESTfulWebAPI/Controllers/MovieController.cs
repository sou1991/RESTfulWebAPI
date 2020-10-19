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
        ICreateMovieCommand _createMovieCommand;
        IDeleteMovieCommand _deleteMovieCommand;

        public MovieController(ISearchMovieQuery serachMovieQuery, 
            IUpdateMovieCommand updateMovieCommand,
            ICreateMovieCommand createMovieCommand,
            IDeleteMovieCommand deleteMovieCommand)
        {
            this._serachMovieQuery = serachMovieQuery;
            this._updateMovieCommand = updateMovieCommand;
            this._createMovieCommand = createMovieCommand;
            this._deleteMovieCommand = deleteMovieCommand;
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

        [HttpPost]
        public ActionResult<MovieModel> Create(MovieModel movieModel)
        {
            try
            {
                _createMovieCommand.Execute(movieModel);
                 return CreatedAtAction(nameof(Get), new { prmID = movieModel.id }, movieModel);
            }
            catch
            {
                return BadRequest();
            }
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

        [HttpDelete("{prmID}")]
        public ActionResult Delete(int prmID)
        {
            try
            {
                _deleteMovieCommand.Execute(new MovieModel { id = prmID });
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
