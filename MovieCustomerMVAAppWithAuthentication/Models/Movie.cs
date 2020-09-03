using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMVAAppWithAuthentication.Models
{
    public class Movie
    {
        public int Id { get; set; }
      
        [Required(ErrorMessage = "Name field is Mandatory")]
        public string Name { get; set; }
       
        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Genre field is Required")]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Release Date field is Reuired")]
        public DateTime ReleaseDate { get; set; }
        [Range(1,20,ErrorMessage = "Field Number in stock must be between 1 to 20")]
        public int NoInStocks { get; set; }

    }
}