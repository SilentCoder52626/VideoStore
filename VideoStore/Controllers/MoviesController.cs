using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using VideoStore.Models;
using VideoStore.ViewModel;

namespace VideoStore.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext context;

        public MoviesController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Movies
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult New()
        {
            var genres = context.MoviesGenres.ToList();

            var viewModel = new MoviesFormViewModel
            {
                MoviesGenres = genres
            };

            return View("MoviesForm", viewModel);
        }

        public ActionResult MoviesForm()
        {
            var MoviesGenre = context.MoviesGenres.ToList();
            var ViewModel = new MoviesFormViewModel
            {
                MoviesGenres = MoviesGenre
            };
            return View("MoviesForm", ViewModel);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movies)
        {            
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movies)
                {
                    MoviesGenres = context.MoviesGenres.ToList()
                };
                return View("MoviesForm", viewModel);
            }
            if (movies.Id == 0)
            {
                movies.DateAdded = DateTime.Now;
                context.Movies.Add(movies);
            }
            else
            {
                var moviesinDb = context.Movies.Single(m => m.Id == movies.Id);
                moviesinDb.Name = movies.Name;
                moviesinDb.DateCreated = movies.DateCreated;
                moviesinDb.NumberInStock = movies.NumberInStock;
                moviesinDb.MoviesGenreId = movies.MoviesGenreId;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MoviesFormViewModel
            {               
                MoviesGenres = context.MoviesGenres.ToList()
            };

            return View("MoviesForm", viewModel);
        }

        
        public ActionResult Details(int id)
        {
            var movies = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();
            return View(movies);
        }
    }
}