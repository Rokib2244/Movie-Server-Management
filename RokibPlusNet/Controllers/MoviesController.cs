using RokibPlusNet.Models;
using RokibPlusNet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RokibPlusNet.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            //var movie = new Movie() { Name = "Shrek!" };
            var movies = new List<Movie> {
            new Movie{ MovieName ="Mission Immosible 1" },
            new Movie{ MovieName ="Escape Plan" },
            new Movie{ MovieName ="Lion King" },         
            };
            var customers = new List<Customer> { 
            new Customer { CustomerId =1, CustomerName=" Haris"},
            new Customer { CustomerId =2, CustomerName="Munna"},
            new Customer { CustomerId =1, CustomerName="Ashafak"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movies,
                Customers = customers
            };

            return View(viewModel);



            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page=1, sortBy = "Name" });
        }
        //public ActionResult AllCustomers()
        //{
        //    var customers = new List<Customer> {
        //    new Customer { CustomerId =1, CustomerName=" Sajjad"},
        //    new Customer { CustomerId =2, CustomerName="Hero"},
        //    new Customer { CustomerId =1, CustomerName="Mayin"},
        //    };
        //    //ViewBag.customers = customers;
        //    var viewModel = new RandomMovieViewModel
        //    {
                
        //        Customers = customers
        //    };
        //    return View(viewModel);
        //}
        //public ActionResult AllMoviess()
        //{
        //    var movie = new List<Movie> {
        //    new Movie{ MovieId=1, MovieName ="Mission Immosible 1" },
        //    new Movie{ MovieId=2, MovieName ="Escape Plan" },
        //    new Movie{ MovieId=3, MovieName ="Lion King" },
        //    new Movie{ MovieId=4, MovieName ="Jumanzi" },
        //    new Movie{ MovieId=5,MovieName ="Jack Reacher" },
        //    new Movie{ MovieId=6,MovieName ="Now you see mee" } };
        //    var viewModel = new RandomMovieViewModel
        //    {

        //        Movie = movie
        //    };
        //    return View(viewModel);
        //}
        
        //[Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/"+ month);
        }

        //public ActionResult edit(int movieId)
        //{
        //    return Content("id " + movieId);
        //}
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageInde={0}&sortBy={1} ",pageIndex, sortBy));
        //}


        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }
        public ActionResult AddMovie()
        {
            var genres = _context.Genres.ToList();
            var viewModels = new NewMovieViewModel {
                
              //Movie = new Movie(),  
              Genres = genres
             
            };

            return View(viewModels);
        }
        [HttpPost]
        public ActionResult AddNewMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    
                    Genres = _context.Genres.ToList()

                };
                return View("AddMovie", viewModel);
            }
            if (movie.MovieId==0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var moviesInDb = _context.Movies.SingleOrDefault(c => c.MovieId == movie.MovieId);
                moviesInDb.MovieName = movie.MovieName;
                moviesInDb.ReleaseDate = movie.ReleaseDate;
                //moviesInDb.DateAdded = movie.DateAdded;
                moviesInDb.NumberInStock = movie.NumberInStock;
                moviesInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        //public AllMoviesController()
        //{
        //    _context = new ApplicationDbContext();
        //}
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            else
                return View(movies);
        }
        public ActionResult EditMovie(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movies == null)
               return HttpNotFound();

            var viewModel = new NewMovieViewModel(movies) {
            
               
                Genres = _context.Genres.ToList()
               
            };
            return View("AddMovie", viewModel);
        }

    }
}
