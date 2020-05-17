using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RokibPlusNet.Models;

namespace RokibPlusNet.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movie> Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}