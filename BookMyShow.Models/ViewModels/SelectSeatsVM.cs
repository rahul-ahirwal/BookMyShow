using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Models.ViewModels
{
    public class SelectSeatsVM
    {
        public Show Show { get; set; }
        public string MovieName { get; set; }
        public BookingCart BookingCart { get; set; }
    }
}
