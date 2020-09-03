﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieCustomerMVAAppWithAuthentication.Models;

namespace MovieCustomerMVAAppWithAuthentication.ViewModel
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}