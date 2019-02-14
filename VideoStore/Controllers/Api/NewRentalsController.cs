using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoStore.Dtos;
using VideoStore.Models;

namespace VideoStore.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext context;
        public NewRentalsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not Available");

                var rental = new Rental
                {
                    Customers = customer,
                    Movies = movie,
                    DateRented = DateTime.Now
                };
                movie.NumberAvailable--;
                customer.NumberOfMoviesRented++;

                context.NewRentals.Add(rental);
            }
            context.SaveChanges();

            return Ok();
        }
    }
}
