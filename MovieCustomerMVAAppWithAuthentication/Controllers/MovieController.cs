using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieCustomerMVAAppWithAuthentication.Models;
using System.Data.Entity;
using MovieCustomerMVAAppWithAuthentication.ViewModel;

namespace MovieCustomerMVAAppWithAuthentication.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Movie
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(a=>a.Genre).ToList();
            return View(movies);
            
        }
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewMod1 = new NewMovieViewModel
            {
                Genres = genre
            };
            return View(viewMod1);
        }
        //[HttpPost]
       // public ActionResult Create(Movie movie)
        //{
        //    


        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie=movie,
                    Genres=_context.Genres.ToList()
                };
                return View("New", viewModel);
            }
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var customerInDb = _context.Movies.Single(p => p.Id == movie.Id);
                customerInDb.Name = movie.Name;
                // customerInDb.DOB = customer.DOB;
                customerInDb.GenreId = movie.GenreId;
               
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
        public ActionResult Edit(int id)
        {
            var updateCust = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (updateCust == null)
            {
                return HttpNotFound();
            }
            var vm = new NewMovieViewModel
            {
                Movie = updateCust,
                Genres = _context.Genres.ToList()
            };
            return View("New", vm);
        }
        public ActionResult Delete(int id)
        {
            var delMov = _context.Movies.Find(id);
            _context.Movies.Remove(delMov);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
    }
}