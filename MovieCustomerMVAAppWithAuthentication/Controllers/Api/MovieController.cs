using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCustomerMVAAppWithAuthentication.Models;

namespace MovieCustomerMVAAppWithAuthentication.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }
        //DELETE /api/movie/1
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
