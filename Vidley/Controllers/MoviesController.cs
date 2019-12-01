using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using System.Data.Entity;
using Vidley.ViewModels;

namespace Vidley.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose
                ();
        }
        public ActionResult Random()
        {

            //var customer = new List<Customer>
            //{
            //    new Customer{Name = "Customer 1"},
            //    new Customer{Name = "Customer 1"}
            //};

            //var viewModel = new RandomMovieViewModel()
            //{
            //    Movie = movie,
            //    Customer = customer
            //};
            IEnumerable<Movie> movie = GetMovies();
            return View(movie);
            //return HttpNotFound();
            // return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult New()
        {
            var genreList = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel 
            {
                //Movie = new Movie(),
                Genre = genreList
            };
            return View("movieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    Genre = _context.Genres.ToList()
                };
            }
            if (movie.Id == 0)
            {
                movie.dateTime = DateTime.Now;
                _context.Movies.Add(movie);
            }
               
            else
	        {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.QtyStock = movie.QtyStock;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(x => x.Id == id);
            return View(movie);
        }

        public List<Movie> GetMovies()
        {
            var movie = new List<Movie>
            {
                new Movie { Id=1, Name = "Shark!" },
                new Movie { Id = 2, Name = "PK!" }
            };
            return movie;
        }
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12  )}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content("Year=" + year + "month =" + month);
        }

        public ContentResult Text()
        {
            return Content("Hello Bilal");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel(movie)
            {
                
                Genre = _context.Genres.ToList()
            };
            return View("movieForm", viewModel);
        }
        //movies
        //public ActionResult index(int? pageIndex,string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if (String.IsNullOrEmpty(sortBy))
        //        sortBy = "name";

        //    return Content(string.Format("PageIndex={0} & sortBy={1}", pageIndex, sortBy));
        //}

        // GET: Movies

    }
}