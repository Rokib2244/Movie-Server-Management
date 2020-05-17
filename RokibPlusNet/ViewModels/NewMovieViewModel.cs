using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RokibPlusNet.Models;

namespace RokibPlusNet.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre>  Genres { get; set; }
        //public Movie Movie { get; set; }
        public int? MovieId { get; set; }
        [Required]
        [StringLength(255)]
        public string MovieName { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        //public DateTime DateAdded { get; set; }
        [Required(ErrorMessage = "Number In Stock Should be between 1 to 20")]
        [DisplayName("Number In Stock")]
        public int? NumberInStock { get; set; }
        [Required]
        [DisplayName("Genre")]
        public int? GenreId { get; set; }
        //[Required]
       
        public string Title
        {
            get
            {
                //if(MovieId != 0)
                //{
                //    return "Edit Movie";
                //}
                //else
                //{
                //    return "New Movie";
                //}
                return MovieId !=0 ? "Edit Movie" : "New Movie";
            }
        }
        public NewMovieViewModel()
        {
            MovieId = 0;

        }
        public NewMovieViewModel(Movie movie)
        {
            MovieId = movie.MovieId;
            MovieName = movie.MovieName;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }


    }
}