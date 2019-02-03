using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using VideoStore.Models;
using VideoStore.Dtos;
using AutoMapper;

namespace VideoStore.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext context;
        public MoviesController()
        {
            context = new ApplicationDbContext();
        }
        //Get/Api/Movies
        public IHttpActionResult GetMovies()
        {
            var moviesDto = context.Movies
                .Include(m=> m.MoviesGenre)
                .ToList()
                .Select(Mapper.Map<Movies,MoviesDto>);
            return Ok(moviesDto);
        }
        //Get /Api/Movies/Id
        public IHttpActionResult GetMovies(int id)
        {
            var movies = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return NotFound();
            return Ok(Mapper.Map<Movies, MoviesDto>(movies));
        }
        //Post /Api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageData)]
        public IHttpActionResult CreateMovies(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MoviesDto, Movies>(moviesDto);
            context.Movies.Add(movie);
            context.SaveChanges();
            moviesDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id ),moviesDto);
        }
        //Update /Api/movies/id
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageData)]
        public void UpdateMovies(int id, MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var moviesInDb = context.Movies.SingleOrDefault(m => m.Id == id);
            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(moviesDto, moviesInDb);

            context.SaveChanges();            
        }
        //Delete /Api/movies/id
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageData)]
        public void DeleteMovies(int id)
        {
            var moviesInDb = context.Movies.SingleOrDefault(m => m.Id == id);
            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Movies.Remove(moviesInDb);
            context.SaveChanges();
        }

    }
}
