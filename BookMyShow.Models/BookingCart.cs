using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models
{
    public class BookingCart
    {
        [Key]
        public Guid BookingCartId { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
        public Guid TheatreId { get; set; }
        public Guid ShowId { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
