using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidley.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime dateTime { get; set; }
        [Display(Name ="Number in Stock")]
        [Required]
        [Range(1,20,ErrorMessage ="Qty should be between 1 & 20")]
        public int QtyStock { get; set; }


        public Genre Genre { get; set; }
        [Display(Name ="Genre")]
        [Required]
        public int GenreId { get; set; }
    }
}