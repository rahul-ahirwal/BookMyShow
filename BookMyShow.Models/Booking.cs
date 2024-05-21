using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookMyShow.Models
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public IdentityUser User { get; set; }
        public DateTime BookingTime { get; set; }
        public double TotalPrice { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentRefId { get; set; }
        public Guid ShowId { get; set; }
        [ForeignKey("ShowId")]
        [ValidateNever]
        public Show Show { get; set; }
        public Guid TheatreId { get; set; }
        public Guid MovieId { get; set; }
        public int NoOfSeats { get; set; }
        public string SeatNumbers { get; set; }
    }
}
