using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidley.Models;

namespace Vidley.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genre  { get; set; }

        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        
        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20, ErrorMessage = "Qty should be between 1 & 20")]
        public int? QtyStock { get; set; }


       
        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        
        public string Title
        {
            get
            {
                return  Id != 0 ? "Edit Movie"  : "New Movie";
            }
        }

        public NewMovieViewModel()
        {
            Id = 0;
        }

        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            QtyStock = movie.QtyStock;
            GenreId = movie.GenreId;
        }
    }
}