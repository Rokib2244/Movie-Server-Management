using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RokibPlusNet.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        [StringLength(255)]
        public string MovieName { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        //public DateTime DateAdded { get; set; }
        [Required (ErrorMessage ="Number In Stock Should be between 1 to 20")]
        [DisplayName("Number In Stock")]
        public int NumberInStock { get; set; }
        [Required]
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        //[Required]
        public virtual Genre Genre { get; set; }




        //public static implicit operator Movie(List<Movie> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}