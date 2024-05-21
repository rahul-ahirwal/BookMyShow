using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class Show
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public Guid TheatreId { get; set; }
        [ForeignKey("TheatreId")]
        [ValidateNever]
        public Theatre Theatre { get; set; }
        public Guid MovieId { get; set; }
        [ForeignKey("MovieId")]
        [ValidateNever]
        public Movie Movie { get; set; }
        public int MaxSeats { get; set; } = 100;
        public int AvailableSeats { get; set; } = 100;
        public int BookedSeats { get; set; } = 0;
        [Required]
        public string ShowType { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
