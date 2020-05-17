using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RokibPlusNet.Models;
using RokibPlusNet.Dtos;
using AutoMapper;

namespace RokibPlusNet.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movie == null)
                return NotFound();
            return Ok( Mapper.Map<Movie, MovieDto>( movie));
        }
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.MovieId = movie.MovieId;
            return Created(new Uri(Request.RequestUri + "/" + movie.MovieId), movieDto);
        }
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            Mapper.Map(movieDto, movieInDb);
            
            _context.SaveChanges();

        }
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
