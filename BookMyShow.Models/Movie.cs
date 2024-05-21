using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Cast { get; set; }
        public string Producer { get; set; }
        public string Director { get; set; }
        public string MusicDirector { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string AgeRating { get; set; }
        [Required]
        public DateOnly ReleaseDate { get; set; }
        [ValidateNever]
        IEnumerable<Theatre> Theatres { get; set; }
        public int MovieState { get; set; }
    }
}
