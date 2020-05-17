using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RokibPlusNet.Models;

namespace RokibPlusNet.Controllers
{
    public class AllMoviesController : Controller
    {
        // GET: AllMovies
        private ApplicationDbContext _context;
        public AllMoviesController()
        {
            _context = new ApplicationDbContext();
        }
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
            var movies = _context.Movies.SingleOrDefault(c=>c.MovieId==id);
            if(movies==null)
            {
                return HttpNotFound();
            }
            else
            return View(movies) ;
        }
        //private IEnumerable<Movie> GetAllMovies()
        //{
        //    var movies = new List<Movie>{
        //    new Movie{MovieId=1, MovieName="Wolverine one"},
        //    new Movie{MovieId=2, MovieName="Avengers Endgame"},
        //    new Movie{MovieId=3, MovieName="Crank"},
        //    new Movie{MovieId=4, MovieName="Escape Trace"}
        //    };
        //    return movies;
        //}
    }
}